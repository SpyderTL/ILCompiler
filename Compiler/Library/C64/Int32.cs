using System;
using ILCompiler.Platform.C64;
using ILCompiler.Platform.Mos6502;

namespace ILCompiler.Library.C64
{
	internal static class Int32
	{
		//internal static void ToString(string name)
		//{
		//	Compiler.Label(name);

		//	Cpu.Return();

		//	Compiler.Label(name + "DigitValues");

		//	Compiler.Writer.Write(1000000000);
		//	Compiler.Writer.Write(100000000);
		//	Compiler.Writer.Write(10000000);
		//	Compiler.Writer.Write(1000000);
		//	Compiler.Writer.Write(100000);
		//	Compiler.Writer.Write(10000);
		//	Compiler.Writer.Write(1000);
		//	Compiler.Writer.Write(100);
		//	Compiler.Writer.Write(10);
		//	Compiler.Writer.Write(1);
		//}

		internal static void Parse(string name)
		{
			Compiler.Label(name);

			var stringPointer = 0x02;
			var value = 0x04;
			var digitValuePointer = 0x08;
			var digitValue = 0x0a;
			var digit = 0x0e;

			Stack.PullZeroPage16(stringPointer);

			Cpu.A = 0;

			Cpu.CopyAToZeroPage(value);
			Cpu.CopyAToZeroPage(value + 1);
			Cpu.CopyAToZeroPage(value + 2);
			Cpu.CopyAToZeroPage(value + 3);

			// Get Length
			Cpu.Y = 0;

			Compiler.Label(name + "GetLength");

			Cpu.CopyZeroPagePointerPlusYToA(stringPointer);

			Cpu.IfZero(name + "CheckLength");

			Cpu.IncrementY();

			Cpu.Jump(name + "GetLength");

			// Check Length
			Compiler.Label(name + "CheckLength");

			Cpu.CompareYToValue(0);

			Cpu.IfEqual(name + "Done");

			// Get Digit Values
			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			Compiler.LowReference(name + "DigitValues");

			Cpu.CopyAToZeroPage(digitValuePointer);

			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			Compiler.HighReference(name + "DigitValues");

			Cpu.CopyAToZeroPage(digitValuePointer + 1);

			// Add Digits
			Compiler.Label(name + "AddDigit");

			Cpu.DecrementY();

			Cpu.CopyZeroPagePointerPlusYToA(stringPointer);

			Cpu.CompareAToValue(Petscii.GetBytes("0")[0]);

			Cpu.IfEqual(name + "NextDigit");

			Cpu.CopyAToZeroPage(digit);

			// Get Digit Value
			Cpu.CopyYToA();
			Cpu.CopyAToX();

			Cpu.Y = 0;
			Cpu.CopyZeroPagePointerPlusYToA(digitValuePointer);
			Cpu.CopyAToZeroPage(digitValue + 0);

			Cpu.IncrementY();
			Cpu.CopyZeroPagePointerPlusYToA(digitValuePointer);
			Cpu.CopyAToZeroPage(digitValue + 1);

			Cpu.IncrementY();
			Cpu.CopyZeroPagePointerPlusYToA(digitValuePointer);
			Cpu.CopyAToZeroPage(digitValue + 2);

			Cpu.IncrementY();
			Cpu.CopyZeroPagePointerPlusYToA(digitValuePointer);
			Cpu.CopyAToZeroPage(digitValue + 3);

			Cpu.CopyXToA();
			Cpu.CopyAToY();

			// Add Digit Value
			Compiler.Label(name + "Loop");

			Cpu.ClearCarryFlag();

			Cpu.CopyZeroPageToA(value + 0);
			Cpu.AddZeroPagePlusCarryToA(digitValue + 0);
			Cpu.CopyAToZeroPage(value + 0);

			Cpu.CopyZeroPageToA(value + 1);
			Cpu.AddZeroPagePlusCarryToA(digitValue + 1);
			Cpu.CopyAToZeroPage(value + 1);

			Cpu.CopyZeroPageToA(value + 2);
			Cpu.AddZeroPagePlusCarryToA(digitValue + 2);
			Cpu.CopyAToZeroPage(value + 2);

			Cpu.CopyZeroPageToA(value + 3);
			Cpu.AddZeroPagePlusCarryToA(digitValue + 3);
			Cpu.CopyAToZeroPage(value + 3);

			Cpu.DecrementZeroPage(digit);

			Cpu.A = Petscii.GetBytes("0")[0];

			Cpu.CompareAToZeroPage(digit);

			Cpu.IfNotEqual(name + "Loop");

			Compiler.Label(name + "NextDigit");

			Cpu.ClearCarryFlag();

			Cpu.CopyZeroPageToA(digitValuePointer + 0);
			Cpu.AddValuePlusCarryToA(4);
			Cpu.CopyAToZeroPage(digitValuePointer + 0);

			Cpu.CopyZeroPageToA(digitValuePointer + 1);
			Cpu.AddValuePlusCarryToA(0);
			Cpu.CopyAToZeroPage(digitValuePointer + 1);

			Cpu.CopyZeroPageToA(digitValuePointer + 2);
			Cpu.AddValuePlusCarryToA(0);
			Cpu.CopyAToZeroPage(digitValuePointer + 2);

			Cpu.CopyZeroPageToA(digitValuePointer + 3);
			Cpu.AddValuePlusCarryToA(0);
			Cpu.CopyAToZeroPage(digitValuePointer + 3);

			Cpu.CompareYToValue(0);

			Cpu.IfNotEqual(name + "AddDigit");

			// Return Value
			Compiler.Label(name + "Done");

			Stack.PushZeroPage32(value);

			Cpu.Return();

			Compiler.Label(name + "DigitValues");

			Compiler.Writer.Write(1);
			Compiler.Writer.Write(10);
			Compiler.Writer.Write(100);
			Compiler.Writer.Write(1000);
			Compiler.Writer.Write(10000);
			Compiler.Writer.Write(100000);
			Compiler.Writer.Write(1000000);
			Compiler.Writer.Write(10000000);
			Compiler.Writer.Write(100000000);
			Compiler.Writer.Write(1000000000);
		}
	}
}