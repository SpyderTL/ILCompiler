using ILCompiler.Library.C64;
using ILCompiler.Platform.C64;
using ILCompiler.Platform.Mos6502;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ILCompiler
{
	internal class ConsoleProgram
	{
		internal static void Start()
		{
			Stack.Pointer = 0x9e00;
			Stack.Address = 0x9d00;
			Heap.Address = 0x8000;

			Compiler.Reset();

			Heap.Reset();

			var assembly = AssemblyDefinition.ReadAssembly(Arguments.Source);
			var assemblyMethods = assembly.Modules.SelectMany(x => x.Types).SelectMany(x => x.Methods).ToDictionary(x => x.FullName);

			var methods = new List<string>();

			Compiler.Imports.Add(assembly.EntryPoint.FullName);

			while (methods.Count < Compiler.Imports.Count)
			{
				var name = Compiler.Imports[methods.Count];

				if (!methods.Contains(name))
				{
					methods.Add(name);

					if (assemblyMethods.TryGetValue(name, out MethodDefinition assemblyMethod))
					{
						Compiler.Label(name);

						var stackSize = assemblyMethod.Body.Variables.Count << 2;

						Cpu.CopyStackPointerToX();
						Cpu.CopyXToA();

						Library.C64.Math.SubtractFromA((byte)stackSize);

						Cpu.CopyAToX();
						Cpu.CopyXToStackPointer();

						foreach (var instruction in assemblyMethod.Body.Instructions)
						{
							Compiler.Label(name + "::" + instruction.Offset);

							switch (instruction.OpCode.Code)
							{
								case Mono.Cecil.Cil.Code.Call:
									var methodReference = instruction.Operand as MethodReference;

									Cpu.Call(methodReference.FullName);
									break;

								case Mono.Cecil.Cil.Code.Callvirt:
									methodReference = instruction.Operand as MethodReference;

									Cpu.Call(methodReference.FullName);
									break;

								case Mono.Cecil.Cil.Code.Nop:
									break;

								case Mono.Cecil.Cil.Code.Ldc_I4:
									var intValue = (int)instruction.Operand;

									Cpu.A = (intValue >> 24) & 0xff;
									Stack.PushA();
									Cpu.A = (intValue >> 16) & 0xff;
									Stack.PushA();
									Cpu.A = (intValue >> 8) & 0xff;
									Stack.PushA();
									Cpu.A = (intValue >> 0) & 0xff;
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Ldc_I4_0:
									Cpu.A = 0x00;
									Stack.PushA();
									Stack.PushA();
									Stack.PushA();
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Ldc_I4_1:
									Cpu.A = 0x00;
									Stack.PushA();
									Stack.PushA();
									Stack.PushA();
									Cpu.A = 0x01;
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Ldc_I4_2:
									Cpu.A = 0x00;
									Stack.PushA();
									Stack.PushA();
									Stack.PushA();
									Cpu.A = 0x02;
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Stloc_0:
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x02);
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x03);
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x04);
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x05);

									Cpu.CopyStackPointerToX();

									Cpu.CopyZeroPageToA(0x02);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);

									Cpu.CopyZeroPageToA(0x03);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);

									Cpu.CopyZeroPageToA(0x04);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);

									Cpu.CopyZeroPageToA(0x05);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);
									break;

								case Mono.Cecil.Cil.Code.Stloc_1:
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x02);
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x03);
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x04);
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x05);

									Cpu.CopyStackPointerToX();

									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();

									Cpu.CopyZeroPageToA(0x02);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);

									Cpu.CopyZeroPageToA(0x03);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);

									Cpu.CopyZeroPageToA(0x04);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);

									Cpu.CopyZeroPageToA(0x05);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);
									break;

								case Mono.Cecil.Cil.Code.Stloc_2:
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x02);
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x03);
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x04);
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x05);

									Cpu.CopyStackPointerToX();

									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();

									Cpu.CopyZeroPageToA(0x02);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);

									Cpu.CopyZeroPageToA(0x03);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);

									Cpu.CopyZeroPageToA(0x04);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);

									Cpu.CopyZeroPageToA(0x05);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);
									break;

								case Mono.Cecil.Cil.Code.Stloc_3:
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x02);
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x03);
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x04);
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x05);

									Cpu.CopyStackPointerToX();

									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();

									Cpu.CopyZeroPageToA(0x02);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);

									Cpu.CopyZeroPageToA(0x03);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);

									Cpu.CopyZeroPageToA(0x04);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);

									Cpu.CopyZeroPageToA(0x05);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);
									break;

								case Mono.Cecil.Cil.Code.Stloc_S:
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x02);
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x03);
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x04);
									Stack.PullA();
									Cpu.CopyAToZeroPage(0x05);

									Cpu.CopyStackPointerToX();

									var variable = instruction.Operand as Mono.Cecil.Cil.VariableDefinition;

									for (int x = 0; x < variable.Index; x++)
									{
										Cpu.IncrementX();
										Cpu.IncrementX();
										Cpu.IncrementX();
										Cpu.IncrementX();
									}

									Cpu.CopyZeroPageToA(0x02);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);

									Cpu.CopyZeroPageToA(0x03);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);

									Cpu.CopyZeroPageToA(0x04);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);

									Cpu.CopyZeroPageToA(0x05);
									Cpu.IncrementX();
									Cpu.CopyAToAbsolutePlusX(0x100);
									break;

								case Mono.Cecil.Cil.Code.Ldloc_0:
									Cpu.CopyStackPointerToX();

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x02);

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x03);

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x04);

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x05);

									Cpu.CopyZeroPageToA(0x05);
									Stack.PushA();

									Cpu.CopyZeroPageToA(0x04);
									Stack.PushA();

									Cpu.CopyZeroPageToA(0x03);
									Stack.PushA();

									Cpu.CopyZeroPageToA(0x02);
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Ldloc_1:
									Cpu.CopyStackPointerToX();

									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x02);

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x03);

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x04);

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x05);

									Cpu.CopyZeroPageToA(0x05);
									Stack.PushA();

									Cpu.CopyZeroPageToA(0x04);
									Stack.PushA();

									Cpu.CopyZeroPageToA(0x03);
									Stack.PushA();

									Cpu.CopyZeroPageToA(0x02);
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Ldloc_2:
									Cpu.CopyStackPointerToX();

									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x02);

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x03);

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x04);

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x05);

									Cpu.CopyZeroPageToA(0x05);
									Stack.PushA();

									Cpu.CopyZeroPageToA(0x04);
									Stack.PushA();

									Cpu.CopyZeroPageToA(0x03);
									Stack.PushA();

									Cpu.CopyZeroPageToA(0x02);
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Ldloc_3:
									Cpu.CopyStackPointerToX();

									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();
									Cpu.IncrementX();

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x02);

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x03);

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x04);

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x05);

									Cpu.CopyZeroPageToA(0x05);
									Stack.PushA();

									Cpu.CopyZeroPageToA(0x04);
									Stack.PushA();

									Cpu.CopyZeroPageToA(0x03);
									Stack.PushA();

									Cpu.CopyZeroPageToA(0x02);
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Ldloc_S:
									Cpu.CopyStackPointerToX();

									variable = instruction.Operand as Mono.Cecil.Cil.VariableDefinition;

									for (int x = 0; x < variable.Index; x++)
									{
										Cpu.IncrementX();
										Cpu.IncrementX();
										Cpu.IncrementX();
										Cpu.IncrementX();
									}

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x02);

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x03);

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x04);

									Cpu.IncrementX();
									Cpu.CopyAbsolutePlusXToA(0x100);
									Cpu.CopyAToZeroPage(0x05);

									Cpu.CopyZeroPageToA(0x05);
									Stack.PushA();

									Cpu.CopyZeroPageToA(0x04);
									Stack.PushA();

									Cpu.CopyZeroPageToA(0x03);
									Stack.PushA();

									Cpu.CopyZeroPageToA(0x02);
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Ldstr:
									var stringValue = instruction.Operand as string;

									Cpu.CopyAbsoluteToX(Stack.Pointer);

									Cpu.A = 0;

									Cpu.DecrementX();

									Cpu.CopyAToAbsolutePlusX(Stack.Address);

									Cpu.DecrementX();

									Cpu.CopyAToAbsolutePlusX(Stack.Address);

									Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
									Compiler.StringHighReference(stringValue);

									Cpu.DecrementX();

									Cpu.CopyAToAbsolutePlusX(Stack.Address);

									Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
									Compiler.StringLowReference(stringValue);

									Cpu.DecrementX();

									Cpu.CopyAToAbsolutePlusX(Stack.Address);

									Cpu.CopyXToAbsolute(Stack.Pointer);
									break;

								case Mono.Cecil.Cil.Code.Add:
									Stack.PullZeroPage32(0x02);
									Stack.PullZeroPage32(0x06);

									Cpu.ClearCarryFlag();

									Cpu.CopyZeroPageToA(0x02);
									Cpu.AddZeroPagePlusCarryToA(0x06);
									Cpu.CopyAToZeroPage(0x02);

									Cpu.CopyZeroPageToA(0x03);
									Cpu.AddZeroPagePlusCarryToA(0x07);
									Cpu.CopyAToZeroPage(0x03);

									Cpu.CopyZeroPageToA(0x04);
									Cpu.AddZeroPagePlusCarryToA(0x08);
									Cpu.CopyAToZeroPage(0x04);

									Cpu.CopyZeroPageToA(0x05);
									Cpu.AddZeroPagePlusCarryToA(0x09);
									Cpu.CopyAToZeroPage(0x05);

									Cpu.CopyZeroPageToA(0x05);
									Stack.PushA();
									Cpu.CopyZeroPageToA(0x04);
									Stack.PushA();
									Cpu.CopyZeroPageToA(0x03);
									Stack.PushA();
									Cpu.CopyZeroPageToA(0x02);
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Mul:
									Cpu.Call("System.Int32 System.Int32::Multiply(System.Int32,System.Int32)");
									break;

								case Mono.Cecil.Cil.Code.Div:
									Cpu.Call("System.Int32 System.Int32::Divide(System.Int32,System.Int32)");
									break;

								case Mono.Cecil.Cil.Code.Rem:
									Cpu.Call("System.Int32 System.Int32::Modulus(System.Int32,System.Int32)");
									break;

								case Mono.Cecil.Cil.Code.Conv_U1:
									break;

								case Mono.Cecil.Cil.Code.Dup:
									Stack.PullZeroPage32(0x02);
									Stack.PushZeroPage32(0x02);
									Stack.PushZeroPage32(0x02);
									break;

								case Mono.Cecil.Cil.Code.Br_S:
									var target = instruction.Operand as Mono.Cecil.Cil.Instruction;

									Cpu.Jump(name + "::" + target.Offset);
									break;

								case Mono.Cecil.Cil.Code.Ret:
									Cpu.CopyStackPointerToX();
									Cpu.CopyXToA();

									Library.C64.Math.AddToA((byte)stackSize);

									Cpu.CopyAToX();
									Cpu.CopyXToStackPointer();

									Cpu.Return();
									break;

								default:
									throw new Exception("Unsupported OpCode: " + instruction.OpCode.Code);
							}
						}
					}
					else
					{
						Compiler.Label(name);

						Function.Name = name;

						switch (name)
						{
							case "System.Void System.Console::Write(System.String)":
								Library.C64.Console.WriteString();
								break;

							case "System.Void System.Console::WriteLine(System.String)":
								Library.C64.Console.WriteLineString();
								break;

							case "System.Void System.Console::WriteLine(System.Int32)":
								Library.C64.Console.WriteLineInt();
								break;

							case "System.String System.Console::ReadLine()":
								Library.C64.Console.ReadLine();
								break;

							case "System.Void System.Console::Write(System.Int32)":
								Library.C64.Console.WriteInt();
								break;

							case "System.Int32 System.Int32::Parse(System.String)":
								Library.C64.Int32.Parse();
								break;

							case "System.Int32 System.Int32::Multiply(System.Int32,System.Int32)":
								Library.C64.Int32.Multiply();
								break;

							case "System.Int32 System.Int32::Divide(System.Int32,System.Int32)":
								Library.C64.Int32.Divide();
								break;

							case "System.Int32 System.Int32::Modulus(System.Int32,System.Int32)":
								Library.C64.Int32.Modulus();
								break;

							case "System.String System.String::Concat(System.String,System.String)":
								Library.C64.String.Concat();
								break;

							case "System.Int32 System.String::get_Length()":
								Library.C64.String.get_Length();
								break;

							default:
								throw new Exception("Method Not Found: " + name);
						}
					}
				}
			}

			foreach (var value in Compiler.Strings)
			{
				Compiler.Labels["String(" + value + ")"] = Compiler.Stream.Position;

				Compiler.Writer.Write(Petscii.GetBytes(value));
				Compiler.Writer.Write((byte)0);
			}

			// Update References
			Compiler.BaseAddress = 0x0810;

			Compiler.UpdateReferences();

			// Write C64 Program Header
			using var stream2 = File.Create(Arguments.Destination);
			using var writer2 = new BinaryWriter(stream2);

			writer2.Write((ushort)0x0801);
			writer2.Write((byte)0x0b);
			writer2.Write((byte)0x08);
			writer2.Write((byte)0x0a);
			writer2.Write((byte)0x00);
			writer2.Write((byte)0x9e);
			writer2.Write(Encoding.ASCII.GetBytes("2064"));
			writer2.Write((byte)0x00);
			writer2.Write((byte)0x00);
			writer2.Write((byte)0x00);
			writer2.Write((byte)0x00);
			writer2.Write((byte)0x00);
			writer2.Write((byte)0x00);

			writer2.Write(Compiler.Stream.ToArray());
			writer2.Flush();
		}

		private static int VariableSize(Mono.Cecil.Cil.VariableDefinition variable)
		{
			switch (variable.VariableType.FullName)
			{
				case "Byte":
					return 1;

				default:
					return 4;
			}
		}
	}
}