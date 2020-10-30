using System;
using ILCompiler.Platform.C64;
using ILCompiler.Platform.Mos6502;

namespace ILCompiler.Library.C64
{
	internal static class Int32
	{
		internal static void ToString(string name)
		{
			Compiler.Label(name);

			Stack.PullZeroPage32(0x02);

			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			Compiler.StringHighReference("0");

			Stack.PushA();

			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			Compiler.StringLowReference("0");

			Stack.PushA();

			//Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			//Compiler.LowReference(name + "DigitValues");

			//Cpu.CopyAToZeroPage(0x06);

			//Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			//Compiler.HighReference(name + "DigitValues");

			//Cpu.CopyAToZeroPage(0x07);

			Cpu.Return();

			Compiler.Label(name + "DigitValues");

			Compiler.Writer.Write(1000000000);
			Compiler.Writer.Write(100000000);
			Compiler.Writer.Write(10000000);
			Compiler.Writer.Write(1000000);
			Compiler.Writer.Write(100000);
			Compiler.Writer.Write(10000);
			Compiler.Writer.Write(1000);
			Compiler.Writer.Write(100);
			Compiler.Writer.Write(10);
			Compiler.Writer.Write(1);
		}
	}
}