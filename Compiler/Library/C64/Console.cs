using System;
using System.Collections.Generic;
using System.Text;
using ILCompiler.Platform.C64;
using ILCompiler.Platform.Mos6502;

namespace ILCompiler.Library.C64
{
	public static class Console
	{
		public static void WriteString(string name)
		{
			Compiler.Label(name);

			Stack.PullZeroPage16(0x02);

			Compiler.Label(name + "ForEachCharacter");

			Cpu.Y = 0;

			Cpu.CopyZeroPagePointerPlusYToA(0x02);

			Cpu.IfZero(name + "Done");

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.IncrementZeroPage(0x02);

			Cpu.IfNotZero(name + "Skip");

			Cpu.IncrementZeroPage(0x03);

			Compiler.Label(name + "Skip");

			Cpu.Jump(name + "ForEachCharacter");

			Compiler.Label(name + "Done");

			Cpu.Return();
		}

		public static void WriteLineString(string name)
		{
			Compiler.Label(name);

			Stack.PullZeroPage16(0x02);

			Compiler.Label(name + "ForEachCharacter");

			Cpu.Y = 0;

			Cpu.CopyZeroPagePointerPlusYToA(0x02);

			Cpu.IfZero(name + "Done");

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.IncrementZeroPage(0x02);

			Cpu.IfNotZero(name + "Skip");

			Cpu.IncrementZeroPage(0x03);

			Compiler.Label(name + "Skip");

			Cpu.Jump(name + "ForEachCharacter");

			Compiler.Label(name + "Done");

			Cpu.A = Petscii.NewLine;

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.Return();
		}

		public static void WriteLineInt(string name)
		{
			Compiler.Label(name);

			var value = (byte)0x02;
			var digitValue = (byte)0x06;
			var digitValuePointer = (byte)0x0a;
			var character = (byte)0x0c;

			// Get Value
			Stack.PullZeroPage32(value);

			// Check For Zero
			Cpu.CopyZeroPageToA(value);
			Cpu.OrAWithZeroPage((byte)(value + 1));
			Cpu.OrAWithZeroPage((byte)(value + 2));
			Cpu.OrAWithZeroPage((byte)(value + 3));

			Cpu.IfNotZero(name + "FindFirstDigit");

			Cpu.A = Petscii.GetBytes("0")[0];

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.Return();

			Compiler.Label(name + "FindFirstDigit");

			Cpu.A = Petscii.GetBytes("1")[0];

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.Return();

			// Find First Digit
			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			Compiler.LowReference(name + "DigitValues");

			Cpu.CopyAToZeroPage(digitValuePointer);

			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			Compiler.HighReference(name + "DigitValues");

			Cpu.CopyAToZeroPage((byte)(digitValuePointer + 1));

			Compiler.Label(name + "ForEachDigit");

			Cpu.Y = 0;
			Cpu.CopyZeroPagePointerPlusYToA(digitValuePointer);
			Cpu.CopyAToZeroPage(digitValue);

			Cpu.IncrementY();
			Cpu.CopyZeroPagePointerPlusYToA(digitValuePointer);
			Cpu.CopyAToZeroPage((byte)(digitValue + 1));

			Cpu.IncrementY();
			Cpu.CopyZeroPagePointerPlusYToA(digitValuePointer);
			Cpu.CopyAToZeroPage((byte)(digitValue + 2));

			Cpu.IncrementY();
			Cpu.CopyZeroPagePointerPlusYToA(digitValuePointer);
			Cpu.CopyAToZeroPage((byte)(digitValue + 3));

			Cpu.IfNotZero(name + "DrawDigits");



			Compiler.Label(name + "DrawDigits");

			Cpu.A = Petscii.GetBytes("0")[0];

			Cpu.CopyAToZeroPage(character);


			Compiler.Label(name + "ForEachCharacter");

			Cpu.Y = 0;

			Cpu.CopyZeroPagePointerPlusYToA(0x02);

			Cpu.IfZero(name + "Done");

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.IncrementZeroPage(0x02);

			Cpu.IfNotZero(name + "Skip");

			Cpu.IncrementZeroPage(0x03);

			Compiler.Label(name + "Skip");

			Cpu.Jump(name + "ForEachCharacter");

			Compiler.Label(name + "Done");

			Cpu.A = Petscii.NewLine;

			Cpu.Call(Kernal.WriteCharacter);

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
