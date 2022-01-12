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

		//	Compiler.Label(Function.Label("DigitValues"));

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

		internal static void Parse()
		{
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

			Compiler.Label(Function.Label("GetLength"));

			Cpu.CopyZeroPagePointerPlusYToA(stringPointer);

			Cpu.IfZero(Function.Label("CheckLength"));

			Cpu.IncrementY();

			Cpu.Jump(Function.Label("GetLength"));

			// Check Length
			Compiler.Label(Function.Label("CheckLength"));

			Cpu.CompareYToValue(0);

			Cpu.IfEqual(Function.Label("Done"));

			// Get Digit Values
			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			Compiler.LowReference(Function.Label("DigitValues"));

			Cpu.CopyAToZeroPage(digitValuePointer);

			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			Compiler.HighReference(Function.Label("DigitValues"));

			Cpu.CopyAToZeroPage(digitValuePointer + 1);

			// Add Digits
			Compiler.Label(Function.Label("AddDigit"));

			Cpu.DecrementY();

			Cpu.CopyZeroPagePointerPlusYToA(stringPointer);

			Cpu.CompareAToValue(Petscii.GetBytes("0")[0]);

			Cpu.IfEqual(Function.Label("NextDigit"));

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
			Compiler.Label(Function.Label("Loop"));

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

			Cpu.IfNotEqual(Function.Label("Loop"));

			Compiler.Label(Function.Label("NextDigit"));

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

			Cpu.IfNotEqual(Function.Label("AddDigit"));

			// Return Value
			Compiler.Label(Function.Label("Done"));

			Stack.PushZeroPage32(value);

			Cpu.Return();

			// Digit Value Table
			Compiler.Label(Function.Label("DigitValues"));

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

		internal static void Add()
		{
			Stack.PullZeroPage32(0x06);
			Stack.PullZeroPage32(0x02);

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

			Cpu.Return();
		}

		internal static void Subtract()
		{
			Stack.PullZeroPage32(0x06);
			Stack.PullZeroPage32(0x02);

			Cpu.SetCarryFlag();

			Cpu.CopyZeroPageToA(0x02);
			Cpu.SubtractZeroPagePlusCarryFromA(0x06);
			Cpu.CopyAToZeroPage(0x02);

			Cpu.CopyZeroPageToA(0x03);
			Cpu.SubtractZeroPagePlusCarryFromA(0x07);
			Cpu.CopyAToZeroPage(0x03);

			Cpu.CopyZeroPageToA(0x04);
			Cpu.SubtractZeroPagePlusCarryFromA(0x08);
			Cpu.CopyAToZeroPage(0x04);

			Cpu.CopyZeroPageToA(0x05);
			Cpu.SubtractZeroPagePlusCarryFromA(0x09);
			Cpu.CopyAToZeroPage(0x05);

			Cpu.CopyZeroPageToA(0x05);
			Stack.PushA();
			Cpu.CopyZeroPageToA(0x04);
			Stack.PushA();
			Cpu.CopyZeroPageToA(0x03);
			Stack.PushA();
			Cpu.CopyZeroPageToA(0x02);
			Stack.PushA();

			Cpu.Return();
		}

		internal static void Multiply()
		{
			var value1 = 0x02;
			var value2 = 0x06;
			var result = 0x0a;

			// Result = 0;
			Cpu.A = 0;

			Cpu.CopyAToZeroPage(result + 0);
			Cpu.CopyAToZeroPage(result + 1);
			Cpu.CopyAToZeroPage(result + 2);
			Cpu.CopyAToZeroPage(result + 3);

			Stack.PullZeroPage32(value2);
			Stack.PullZeroPage32(value1);

			Cpu.CopyZeroPageToA(value1 + 0);
			Cpu.OrAWithZeroPage(value1 + 1);
			Cpu.OrAWithZeroPage(value1 + 2);
			Cpu.OrAWithZeroPage(value1 + 3);

			Cpu.IfZero(Function.Label("Done"));

			Cpu.CopyZeroPageToA(value2 + 0);
			Cpu.OrAWithZeroPage(value2 + 1);
			Cpu.OrAWithZeroPage(value2 + 2);
			Cpu.OrAWithZeroPage(value2 + 3);

			Cpu.IfZero(Function.Label("Done"));

			Compiler.Label(Function.Label("Loop"));

			Cpu.ClearCarryFlag();

			Cpu.CopyZeroPageToA(result + 0);
			Cpu.AddZeroPagePlusCarryToA(value1 + 0);
			Cpu.CopyAToZeroPage(result + 0);

			Cpu.CopyZeroPageToA(result + 1);
			Cpu.AddZeroPagePlusCarryToA(value1 + 1);
			Cpu.CopyAToZeroPage(result + 1);

			Cpu.CopyZeroPageToA(result + 2);
			Cpu.AddZeroPagePlusCarryToA(value1 + 2);
			Cpu.CopyAToZeroPage(result + 2);

			Cpu.CopyZeroPageToA(result + 3);
			Cpu.AddZeroPagePlusCarryToA(value1 + 3);
			Cpu.CopyAToZeroPage(result + 3);

			// Decrement Value 2
			Cpu.SetCarryFlag();

			Cpu.CopyZeroPageToA(value2 + 0);
			Cpu.SubtractValuePlusCarryFromA(1);
			Cpu.CopyAToZeroPage(value2 + 0);

			Cpu.CopyZeroPageToA(value2 + 1);
			Cpu.SubtractValuePlusCarryFromA(0);
			Cpu.CopyAToZeroPage(value2 + 1);

			Cpu.CopyZeroPageToA(value2 + 2);
			Cpu.SubtractValuePlusCarryFromA(0);
			Cpu.CopyAToZeroPage(value2 + 2);

			Cpu.CopyZeroPageToA(value2 + 3);
			Cpu.SubtractValuePlusCarryFromA(0);
			Cpu.CopyAToZeroPage(value2 + 3);

			Cpu.OrAWithZeroPage(value2 + 2);
			Cpu.OrAWithZeroPage(value2 + 1);
			Cpu.OrAWithZeroPage(value2 + 0);

			Cpu.IfNotZero(Function.Label("Loop"));

			// Done
			Compiler.Label(Function.Label("Done"));

			Stack.PushZeroPage32(result);

			Cpu.Return();
		}

		internal static void Divide()
		{
			var value1 = 0x02;
			var value2 = 0x06;
			var result = 0x0a;

			// Result = 0;
			Cpu.A = 0;

			Cpu.CopyAToZeroPage(result + 0);
			Cpu.CopyAToZeroPage(result + 1);
			Cpu.CopyAToZeroPage(result + 2);
			Cpu.CopyAToZeroPage(result + 3);

			Stack.PullZeroPage32(value2);
			Stack.PullZeroPage32(value1);

			Cpu.CopyZeroPageToA(value1 + 0);
			Cpu.OrAWithZeroPage(value1 + 1);
			Cpu.OrAWithZeroPage(value1 + 2);
			Cpu.OrAWithZeroPage(value1 + 3);

			Cpu.IfZero(Function.Label("Done"));

			Cpu.CopyZeroPageToA(value2 + 0);
			Cpu.OrAWithZeroPage(value2 + 1);
			Cpu.OrAWithZeroPage(value2 + 2);
			Cpu.OrAWithZeroPage(value2 + 3);

			Cpu.IfZero(Function.Label("Done"));

			Compiler.Label(Function.Label("Loop"));

			Cpu.ClearCarryFlag();

			Cpu.CopyZeroPageToA(result + 0);
			Cpu.AddZeroPagePlusCarryToA(value1 + 0);
			Cpu.CopyAToZeroPage(result + 0);

			Cpu.CopyZeroPageToA(result + 1);
			Cpu.AddZeroPagePlusCarryToA(value1 + 1);
			Cpu.CopyAToZeroPage(result + 1);

			Cpu.CopyZeroPageToA(result + 2);
			Cpu.AddZeroPagePlusCarryToA(value1 + 2);
			Cpu.CopyAToZeroPage(result + 2);

			Cpu.CopyZeroPageToA(result + 3);
			Cpu.AddZeroPagePlusCarryToA(value1 + 3);
			Cpu.CopyAToZeroPage(result + 3);

			// Decrement Value 2
			Cpu.SetCarryFlag();

			Cpu.CopyZeroPageToA(value2 + 0);
			Cpu.SubtractValuePlusCarryFromA(1);
			Cpu.CopyAToZeroPage(value2 + 0);

			Cpu.CopyZeroPageToA(value2 + 1);
			Cpu.SubtractValuePlusCarryFromA(0);
			Cpu.CopyAToZeroPage(value2 + 1);

			Cpu.CopyZeroPageToA(value2 + 2);
			Cpu.SubtractValuePlusCarryFromA(0);
			Cpu.CopyAToZeroPage(value2 + 2);

			Cpu.CopyZeroPageToA(value2 + 3);
			Cpu.SubtractValuePlusCarryFromA(0);
			Cpu.CopyAToZeroPage(value2 + 3);

			Cpu.OrAWithZeroPage(value2 + 2);
			Cpu.OrAWithZeroPage(value2 + 1);
			Cpu.OrAWithZeroPage(value2 + 0);

			Cpu.IfNotZero(Function.Label("Loop"));

			// Done
			Compiler.Label(Function.Label("Done"));

			Stack.PushZeroPage32(result);

			Cpu.Return();
		}

		internal static void Modulus()
		{
			var value1 = 0x02;
			var value2 = 0x06;
			var result = 0x0a;

			// Result = 0;
			Cpu.A = 0;

			Cpu.CopyAToZeroPage(result + 0);
			Cpu.CopyAToZeroPage(result + 1);
			Cpu.CopyAToZeroPage(result + 2);
			Cpu.CopyAToZeroPage(result + 3);

			Stack.PullZeroPage32(value2);
			Stack.PullZeroPage32(value1);

			Cpu.CopyZeroPageToA(value1 + 0);
			Cpu.OrAWithZeroPage(value1 + 1);
			Cpu.OrAWithZeroPage(value1 + 2);
			Cpu.OrAWithZeroPage(value1 + 3);

			Cpu.IfZero(Function.Label("Done"));

			Cpu.CopyZeroPageToA(value2 + 0);
			Cpu.OrAWithZeroPage(value2 + 1);
			Cpu.OrAWithZeroPage(value2 + 2);
			Cpu.OrAWithZeroPage(value2 + 3);

			Cpu.IfZero(Function.Label("Done"));

			Compiler.Label(Function.Label("Loop"));

			Cpu.ClearCarryFlag();

			Cpu.CopyZeroPageToA(result + 0);
			Cpu.AddZeroPagePlusCarryToA(value1 + 0);
			Cpu.CopyAToZeroPage(result + 0);

			Cpu.CopyZeroPageToA(result + 1);
			Cpu.AddZeroPagePlusCarryToA(value1 + 1);
			Cpu.CopyAToZeroPage(result + 1);

			Cpu.CopyZeroPageToA(result + 2);
			Cpu.AddZeroPagePlusCarryToA(value1 + 2);
			Cpu.CopyAToZeroPage(result + 2);

			Cpu.CopyZeroPageToA(result + 3);
			Cpu.AddZeroPagePlusCarryToA(value1 + 3);
			Cpu.CopyAToZeroPage(result + 3);

			// Decrement Value 2
			Cpu.SetCarryFlag();

			Cpu.CopyZeroPageToA(value2 + 0);
			Cpu.SubtractValuePlusCarryFromA(1);
			Cpu.CopyAToZeroPage(value2 + 0);

			Cpu.CopyZeroPageToA(value2 + 1);
			Cpu.SubtractValuePlusCarryFromA(0);
			Cpu.CopyAToZeroPage(value2 + 1);

			Cpu.CopyZeroPageToA(value2 + 2);
			Cpu.SubtractValuePlusCarryFromA(0);
			Cpu.CopyAToZeroPage(value2 + 2);

			Cpu.CopyZeroPageToA(value2 + 3);
			Cpu.SubtractValuePlusCarryFromA(0);
			Cpu.CopyAToZeroPage(value2 + 3);

			Cpu.OrAWithZeroPage(value2 + 2);
			Cpu.OrAWithZeroPage(value2 + 1);
			Cpu.OrAWithZeroPage(value2 + 0);

			Cpu.IfNotZero(Function.Label("Loop"));

			// Done
			Compiler.Label(Function.Label("Done"));

			Stack.PushZeroPage32(result);

			Cpu.Return();
		}
	}
}