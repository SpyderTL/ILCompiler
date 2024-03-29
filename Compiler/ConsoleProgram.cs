﻿using ILCompiler.Library.C64;
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
		internal const int FramePointer = 0xfb;

		internal static void Start()
		{
			Stack.Pointer = 0x9e00;
			Stack.Address = 0x9d00;
			Heap.Address = 0x8000;

			Compiler.Reset();

			Heap.Reset();

			var assemblies = new List<AssemblyDefinition>();
			var newAssemblies = new Queue<string>();

			newAssemblies.Enqueue(Arguments.Source);

			while (newAssemblies.Count > 0)
			{
				var name = newAssemblies.Dequeue();
				var assembly = AssemblyDefinition.ReadAssembly(name);

				assemblies.Add(assembly);

				if(assemblies.Count == 1)
					Compiler.Imports.Add(assembly.EntryPoint.FullName);

				foreach (var module in assembly.Modules)
				{
					foreach (var reference in module.AssemblyReferences)
					{
						var path = Path.Combine(Path.GetDirectoryName(Arguments.Source), reference.Name + ".dll");

						if (File.Exists(path))
						{
							var assembly2 = System.Reflection.Assembly.Load(File.ReadAllBytes(path));

							if (assembly2 == null)
								throw new Exception("Could not load assembly: " + reference.Name);

							newAssemblies.Enqueue(path);
						}
					}
				}
			}

			var assemblyTypes = assemblies.SelectMany(x => x.Modules).SelectMany(x => x.Types).ToArray();
			var assemblyMethods = assemblyTypes.SelectMany(x => x.Methods).ToDictionary(x => x.FullName);

			var methods = new List<string>();

			foreach (var constructor in assemblyTypes.SelectMany(x => x.Methods).Where(x => x.IsConstructor && x.IsStatic))
				Cpu.Call(constructor.FullName);

			while (methods.Count < Compiler.Imports.Count)
			{
				var name = Compiler.Imports[methods.Count];

				if (!methods.Contains(name))
				{
					methods.Add(name);

					if (assemblyMethods.TryGetValue(name, out MethodDefinition assemblyMethod))
					{
						// Label Method
						Compiler.Label(name);

						// Save Old Frame Pointer
						Stack.PushZeroPage16(FramePointer);

						// Set New Frame Pointer
						Cpu.CopyAbsoluteToA(Stack.Pointer);
						Cpu.CopyAToZeroPage(FramePointer);

						// Allocate Variable Stack Space
						var stackSize = assemblyMethod.Body.Variables.Count << 2;

						if (stackSize > 0)
						{
							Cpu.CopyStackPointerToX();
							Cpu.CopyXToA();

							Library.C64.Math.SubtractFromA((byte)stackSize);

							Cpu.CopyAToX();
							Cpu.CopyXToStackPointer();
						}

						foreach (var instruction in assemblyMethod.Body.Instructions)
						{
							// Label Instruction By Offset
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

								case Mono.Cecil.Cil.Code.Ldc_I4_S:
									var sbyteValue = (sbyte)instruction.Operand;

									Cpu.A = (sbyteValue >> 24) & 0xff;
									Stack.PushA();
									Cpu.A = (sbyteValue >> 16) & 0xff;
									Stack.PushA();
									Cpu.A = (sbyteValue >> 8) & 0xff;
									Stack.PushA();
									Cpu.A = (sbyteValue >> 0) & 0xff;
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

								case Mono.Cecil.Cil.Code.Ldc_I4_3:
									Cpu.A = 0x00;
									Stack.PushA();
									Stack.PushA();
									Stack.PushA();
									Cpu.A = 0x03;
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Ldc_I4_4:
									Cpu.A = 0x00;
									Stack.PushA();
									Stack.PushA();
									Stack.PushA();
									Cpu.A = 0x04;
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Ldc_I4_5:
									Cpu.A = 0x00;
									Stack.PushA();
									Stack.PushA();
									Stack.PushA();
									Cpu.A = 0x05;
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Ldc_I4_6:
									Cpu.A = 0x00;
									Stack.PushA();
									Stack.PushA();
									Stack.PushA();
									Cpu.A = 0x06;
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Ldc_I4_7:
									Cpu.A = 0x00;
									Stack.PushA();
									Stack.PushA();
									Stack.PushA();
									Cpu.A = 0x07;
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Ldc_I4_8:
									Cpu.A = 0x00;
									Stack.PushA();
									Stack.PushA();
									Stack.PushA();
									Cpu.A = 0x08;
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Stloc_0:
									Cpu.Call("Stloc_0");
									break;

								case Mono.Cecil.Cil.Code.Stloc_1:
									Cpu.Call("Stloc_1");
									break;

								case Mono.Cecil.Cil.Code.Stloc_2:
									Cpu.Call("Stloc_2");
									break;

								case Mono.Cecil.Cil.Code.Stloc_3:
									Cpu.Call("Stloc_3");
									break;

								case Mono.Cecil.Cil.Code.Stloc_S:
									var variable = instruction.Operand as Mono.Cecil.Cil.VariableDefinition;
									Cpu.A = variable.Index;
									Cpu.Call("Stloc_S");
									break;

								case Mono.Cecil.Cil.Code.Ldloc_0:
									Cpu.Call("Ldloc_0");
									break;

								case Mono.Cecil.Cil.Code.Ldloc_1:
									Cpu.Call("Ldloc_1");
									break;

								case Mono.Cecil.Cil.Code.Ldloc_2:
									Cpu.Call("Ldloc_2");
									break;

								case Mono.Cecil.Cil.Code.Ldloc_3:
									Cpu.Call("Ldloc_3");
									break;

								case Mono.Cecil.Cil.Code.Ldloc_S:
									variable = instruction.Operand as Mono.Cecil.Cil.VariableDefinition;
									Cpu.A = variable.Index;
									Cpu.Call("Ldloc_S");
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
									Cpu.Call("System.Int32 System.Int32::Add(System.Int32,System.Int32)");
									break;

								case Mono.Cecil.Cil.Code.Sub:
									Cpu.Call("System.Int32 System.Int32::Subtract(System.Int32,System.Int32)");
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

								case Mono.Cecil.Cil.Code.And:
									Cpu.Call("System.Int32 System.Int32::And(System.Int32,System.Int32)");
									break;

								case Mono.Cecil.Cil.Code.Or:
									Cpu.Call("System.Int32 System.Int32::Or(System.Int32,System.Int32)");
									break;

								case Mono.Cecil.Cil.Code.Shr:
									Cpu.Call("Shr");
									break;

								case Mono.Cecil.Cil.Code.Shl:
									Cpu.Call("Shl");
									break;

								case Mono.Cecil.Cil.Code.Conv_U1:
									break;

								case Mono.Cecil.Cil.Code.Dup:
									Stack.PullZeroPage32(0x02);
									Stack.PushZeroPage32(0x02);
									Stack.PushZeroPage32(0x02);
									break;

								case Mono.Cecil.Cil.Code.Br:
								case Mono.Cecil.Cil.Code.Br_S:
									var target = instruction.Operand as Mono.Cecil.Cil.Instruction;

									Cpu.Jump(name + "::" + target.Offset);
									break;

								case Mono.Cecil.Cil.Code.Ret:
									// Deallocate Local Variables
									if (stackSize > 0)
									{
										Cpu.CopyStackPointerToX();
										Cpu.CopyXToA();

										Library.C64.Math.AddToA((byte)stackSize);

										Cpu.CopyAToX();
										Cpu.CopyXToStackPointer();
									}

									// Save Return Value
									if (assemblyMethod.ReturnType.FullName != "System.Void")
										Stack.PullZeroPage32(0x02);

									// Restore Old Argument Pointer
									Stack.PullZeroPage16(FramePointer);

									// Remove Parameters From Stack
									if (assemblyMethod.Parameters.Any())
									{
										Cpu.CopyAbsoluteToA(Stack.Pointer);
										Library.C64.Math.AddToA((byte)(assemblyMethod.Parameters.Count * 4));
										Cpu.CopyAToAbsolute(Stack.Pointer);
									}

									// Restore Return Value
									if (assemblyMethod.ReturnType.FullName != "System.Void")
										Stack.PushZeroPage32(0x02);

									Cpu.Return();
									break;

								case Mono.Cecil.Cil.Code.Conv_I:
									break;

								case Mono.Cecil.Cil.Code.Conv_U:
									break;

								case Mono.Cecil.Cil.Code.Ldind_U1:
									Stack.PullZeroPage32(0x02);
									Cpu.A = 0;
									Stack.PushA();
									Stack.PushA();
									Stack.PushA();
									Cpu.Y = 0;
									Cpu.CopyZeroPagePointerPlusYToA(0x02);
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Stind_I1:
									Stack.PullZeroPage32(0x02);
									Stack.PullZeroPage32(0x06);
									Cpu.CopyZeroPageToA(0x02);
									Cpu.Y = 0;
									Cpu.CopyAToZeroPagePointerPlusY(0x06);
									break;

								case Mono.Cecil.Cil.Code.Stind_I2:
									Stack.PullZeroPage32(0x02);
									Stack.PullZeroPage32(0x06);

									Cpu.CopyZeroPageToA(0x02);
									Cpu.Y = 0;
									Cpu.CopyAToZeroPagePointerPlusY(0x06);

									Cpu.CopyZeroPageToA(0x03);
									Cpu.IncrementY();
									Cpu.CopyAToZeroPagePointerPlusY(0x06);
									break;

								case Mono.Cecil.Cil.Code.Ceq:
									Cpu.Call("Ceq");
									break;

								case Mono.Cecil.Cil.Code.Clt:
									Cpu.Call("Clt");
									break;

								case Mono.Cecil.Cil.Code.Cgt:
								case Mono.Cecil.Cil.Code.Cgt_Un:
									Cpu.Call("Cgt");
									break;

								case Mono.Cecil.Cil.Code.Brtrue:
								case Mono.Cecil.Cil.Code.Brtrue_S:
									Stack.PullZeroPage32(0x02);

									Cpu.A = 0;

									Cpu.CompareAToZeroPage(0x02);

									Cpu.IfNotEqual(name + ":True_" + instruction.Offset);

									Cpu.CompareAToZeroPage(0x03);

									Cpu.IfNotEqual(name + ":True_" + instruction.Offset);

									Cpu.CompareAToZeroPage(0x04);

									Cpu.IfNotEqual(name + ":True_" + instruction.Offset);

									Cpu.CompareAToZeroPage(0x05);

									Cpu.IfEqual(name + ":NotTrue_" + instruction.Offset);

									Compiler.Label(name + ":True_" + instruction.Offset);

									target = instruction.Operand as Mono.Cecil.Cil.Instruction;

									Cpu.Jump(name + "::" + target.Offset);

									Compiler.Label(name + ":NotTrue_" + instruction.Offset);
									break;

								case Mono.Cecil.Cil.Code.Brfalse:
								case Mono.Cecil.Cil.Code.Brfalse_S:
									Stack.PullZeroPage32(0x02);

									Cpu.A = 0;

									Cpu.CompareAToZeroPage(0x02);

									Cpu.IfNotEqual(name + ":NotFalse_" + instruction.Offset);

									Cpu.CompareAToZeroPage(0x03);

									Cpu.IfNotEqual(name + ":NotFalse_" + instruction.Offset);

									Cpu.CompareAToZeroPage(0x04);

									Cpu.IfNotEqual(name + ":NotFalse_" + instruction.Offset);

									Cpu.CompareAToZeroPage(0x05);

									Cpu.IfNotEqual(name + ":NotFalse_" + instruction.Offset);

									target = instruction.Operand as Mono.Cecil.Cil.Instruction;

									Cpu.Jump(name + "::" + target.Offset);

									Compiler.Label(name + ":NotFalse_" + instruction.Offset);
									break;

								case Mono.Cecil.Cil.Code.Ldarg_0:
									Cpu.CopyZeroPageToX(FramePointer);
									Cpu.CopyAbsolutePlusXToA(Stack.Address + 2 + (assemblyMethod.Parameters.Count * 4) - 1);
									Stack.PushA();

									Cpu.CopyZeroPageToX(FramePointer);
									Cpu.CopyAbsolutePlusXToA(Stack.Address + 2 + (assemblyMethod.Parameters.Count * 4) - 2);
									Stack.PushA();

									Cpu.CopyZeroPageToX(FramePointer);
									Cpu.CopyAbsolutePlusXToA(Stack.Address + 2 + (assemblyMethod.Parameters.Count * 4) - 3);
									Stack.PushA();

									Cpu.CopyZeroPageToX(FramePointer);
									Cpu.CopyAbsolutePlusXToA(Stack.Address + 2 + (assemblyMethod.Parameters.Count * 4) - 4);
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Ldarg_1:
									Cpu.CopyZeroPageToX(FramePointer);
									Cpu.CopyAbsolutePlusXToA(Stack.Address + 2 + (assemblyMethod.Parameters.Count * 4) - 5);
									Stack.PushA();

									Cpu.CopyZeroPageToX(FramePointer);
									Cpu.CopyAbsolutePlusXToA(Stack.Address + 2 + (assemblyMethod.Parameters.Count * 4) - 6);
									Stack.PushA();

									Cpu.CopyZeroPageToX(FramePointer);
									Cpu.CopyAbsolutePlusXToA(Stack.Address + 2 + (assemblyMethod.Parameters.Count * 4) - 7);
									Stack.PushA();

									Cpu.CopyZeroPageToX(FramePointer);
									Cpu.CopyAbsolutePlusXToA(Stack.Address + 2 + (assemblyMethod.Parameters.Count * 4) - 8);
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Ldarg_2:
									Cpu.CopyZeroPageToX(FramePointer);
									Cpu.CopyAbsolutePlusXToA(Stack.Address + 2 + (assemblyMethod.Parameters.Count * 4) - 9);
									Stack.PushA();

									Cpu.CopyZeroPageToX(FramePointer);
									Cpu.CopyAbsolutePlusXToA(Stack.Address + 2 + (assemblyMethod.Parameters.Count * 4) - 10);
									Stack.PushA();

									Cpu.CopyZeroPageToX(FramePointer);
									Cpu.CopyAbsolutePlusXToA(Stack.Address + 2 + (assemblyMethod.Parameters.Count * 4) - 11);
									Stack.PushA();

									Cpu.CopyZeroPageToX(FramePointer);
									Cpu.CopyAbsolutePlusXToA(Stack.Address + 2 + (assemblyMethod.Parameters.Count * 4) - 12);
									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Ldsfld:
									var fieldDefinition = (FieldDefinition)instruction.Operand;

									Cpu.Y = 3;

									Compiler.Writer.Write((byte)OpCodes.CopyImmediate16PlusYAddressToA);
									Compiler.AbsoluteReference(fieldDefinition.FullName);

									Stack.PushA();

									Cpu.DecrementY();

									Compiler.Writer.Write((byte)OpCodes.CopyImmediate16PlusYAddressToA);
									Compiler.AbsoluteReference(fieldDefinition.FullName);

									Stack.PushA();

									Cpu.DecrementY();

									Compiler.Writer.Write((byte)OpCodes.CopyImmediate16PlusYAddressToA);
									Compiler.AbsoluteReference(fieldDefinition.FullName);

									Stack.PushA();

									Cpu.DecrementY();

									Compiler.Writer.Write((byte)OpCodes.CopyImmediate16PlusYAddressToA);
									Compiler.AbsoluteReference(fieldDefinition.FullName);

									Stack.PushA();
									break;

								case Mono.Cecil.Cil.Code.Stsfld:
									fieldDefinition = (FieldDefinition)instruction.Operand;

									Cpu.Y = 0;

									Stack.PullA();

									Compiler.Writer.Write((byte)OpCodes.CopyAToImmediate16PlusYAddress);
									Compiler.AbsoluteReference(fieldDefinition.FullName);

									Cpu.IncrementY();

									Stack.PullA();

									Compiler.Writer.Write((byte)OpCodes.CopyAToImmediate16PlusYAddress);
									Compiler.AbsoluteReference(fieldDefinition.FullName);

									Cpu.IncrementY();

									Stack.PullA();

									Compiler.Writer.Write((byte)OpCodes.CopyAToImmediate16PlusYAddress);
									Compiler.AbsoluteReference(fieldDefinition.FullName);

									Cpu.IncrementY();

									Stack.PullA();

									Compiler.Writer.Write((byte)OpCodes.CopyAToImmediate16PlusYAddress);
									Compiler.AbsoluteReference(fieldDefinition.FullName);
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
							case "Ldloc_0":
								Library.C64.Cil.Ldloc_0();
								break;

							case "Ldloc_1":
								Library.C64.Cil.Ldloc_1();
								break;

							case "Ldloc_2":
								Library.C64.Cil.Ldloc_2();
								break;

							case "Ldloc_3":
								Library.C64.Cil.Ldloc_3();
								break;

							case "Ldloc_S":
								Library.C64.Cil.Ldloc_S();
								break;

							case "Stloc_0":
								Library.C64.Cil.Stloc_0();
								break;

							case "Stloc_1":
								Library.C64.Cil.Stloc_1();
								break;

							case "Stloc_2":
								Library.C64.Cil.Stloc_2();
								break;

							case "Stloc_3":
								Library.C64.Cil.Stloc_3();
								break;

							case "Stloc_S":
								Library.C64.Cil.Stloc_S();
								break;

							case "Clt":
								Library.C64.Cil.Clt();
								break;

							case "Cgt":
								Library.C64.Cil.Cgt();
								break;

							case "Ceq":
								Library.C64.Cil.Ceq();
								break;

							case "Shr":
								Library.C64.Cil.Shr();
								break;

							case "Shl":
								Library.C64.Cil.Shl();
								break;

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

							case "System.Int32 System.Int32::Add(System.Int32,System.Int32)":
								Library.C64.Int32.Add();
								break;

							case "System.Int32 System.Int32::Subtract(System.Int32,System.Int32)":
								Library.C64.Int32.Subtract();
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

							case "System.Int32 System.Int32::And(System.Int32,System.Int32)":
								Library.C64.Int32.And();
								break;

							case "System.Int32 System.Int32::Or(System.Int32,System.Int32)":
								Library.C64.Int32.Or();
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

			// Static Fields
			foreach (var type in assemblyTypes)
			{
				foreach (var field in type.Fields.Where(x => x.IsStatic))
				{
					Compiler.Label(field.FullName);

					switch (field.FieldType.FullName)
					{
						case "System.Int32":
						case "System.Uint32":
							Compiler.Writer.Write(0);
							break;

						default:
							throw new Exception("Static field type not supported: " + field.FieldType.FullName);
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

			writer2.Close();
			stream2.Close();

			File.WriteAllLines(Arguments.Destination + ".labels.txt", Compiler.Labels
				.Select(x => $"{Compiler.BaseAddress + x.Value:X4}\t{x.Key}"));
		}

		//private static int VariableSize(Mono.Cecil.Cil.VariableDefinition variable)
		//{
		//	switch (variable.VariableType.FullName)
		//	{
		//		case "Byte":
		//			return 1;

		//		default:
		//			return 4;
		//	}
		//}
	}
}