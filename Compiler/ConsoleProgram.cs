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
			Compiler.Reset();

			var assembly = AssemblyDefinition.ReadAssembly(Arguments.Source);
			var assemblyMethods = assembly.Modules.SelectMany(x => x.Types).SelectMany(x => x.Methods).ToDictionary(x => x.FullName);

			var methods = new List<string>();

			var branches = new List<string>
			{
				assembly.EntryPoint.FullName
			};

			while (branches.Count != 0)
			{
				var name = branches[0];

				branches.RemoveAt(0);

				methods.Add(name);

				if (assemblyMethods.TryGetValue(name, out MethodDefinition assemblyMethod))
				{
					Compiler.Label(name);

					foreach (var instruction in assemblyMethod.Body.Instructions)
					{
						switch (instruction.OpCode.Code)
						{
							case Mono.Cecil.Cil.Code.Call:
								var methodReference = instruction.Operand as MethodReference;
								branches.Add(methodReference.FullName);
								Compiler.Writer.Write((byte)0x20);   // JSR
								Compiler.AbsoluteReference(methodReference.FullName);
								break;

							case Mono.Cecil.Cil.Code.Nop:
								break;

							case Mono.Cecil.Cil.Code.Ldstr:
								var value = instruction.Operand as string;

								Compiler.Writer.Write((byte)0xAE);   // LDX $9C00
								Compiler.Writer.Write((ushort)0x9C00);

								Compiler.Writer.Write((byte)0xA9);   // LDA imm
								Compiler.StringLowReference(value);

								Compiler.Writer.Write((byte)0xCA);   // DEX

								Compiler.Writer.Write((byte)0x9D);   // STA $9C01, X
								Compiler.Writer.Write((ushort)0x9C01);

								Compiler.Writer.Write((byte)0xA9);   // LDA imm
								Compiler.StringHighReference(value);

								Compiler.Writer.Write((byte)0xCA);   // DEX

								Compiler.Writer.Write((byte)0x9D);   // STA $9C01, X
								Compiler.Writer.Write((ushort)0x9C01);

								Compiler.Writer.Write((byte)0x8E);   // STX $9C00
								Compiler.Writer.Write((ushort)0x9C00);
								break;

							case Mono.Cecil.Cil.Code.Ret:
								Compiler.Writer.Write((byte)0x60);   // RET
								break;

							default:
								throw new Exception("Unsupported OpCode: " + instruction.OpCode.Code);
						}
					}
				}
				else if (name == "System.Void System.Console::WriteLine(System.String)")
				{
					Library.C64.Console.WriteLine(name);
				}
			}

			foreach (var value in Compiler.Strings)
			{
				Compiler.Labels["String(" + value + ")"] = Compiler.Stream.Position;

				Compiler.Writer.Write(Encoding.ASCII.GetBytes(value));
				Compiler.Writer.Write((byte)0);
			}

			Compiler.BaseAddress = 0x0810;

			Compiler.UpdateReferences();

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
	}
}