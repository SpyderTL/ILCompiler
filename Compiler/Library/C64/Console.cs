using System;
using System.Collections.Generic;
using System.Text;
using ILCompiler.Platform.C64;
using ILCompiler.Platform.Mos6502;

namespace ILCompiler.Library.C64
{
	public static class Console
	{
		public static void WriteString()
		{
			Stack.PullZeroPage32(0x02);

			Compiler.Label(Function.Label("ForEachCharacter"));

			Cpu.Y = 0;

			Cpu.CopyZeroPagePointerPlusYToA(0x02);

			Cpu.IfZero(Function.Label("Done"));

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.IncrementZeroPage(0x02);

			Cpu.IfNotZero(Function.Label("Skip"));

			Cpu.IncrementZeroPage(0x03);

			Compiler.Label(Function.Label("Skip"));

			Cpu.Jump(Function.Label("ForEachCharacter"));

			Compiler.Label(Function.Label("Done"));

			Cpu.Return();
		}

		public static void WriteLineString()
		{
			Stack.PullZeroPage32(0x02);

			Compiler.Label(Function.Label("ForEachCharacter"));

			Cpu.Y = 0;

			Cpu.CopyZeroPagePointerPlusYToA(0x02);

			Cpu.IfZero(Function.Label("Done"));

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.IncrementZeroPage(0x02);

			Cpu.IfNotZero(Function.Label("Skip"));

			Cpu.IncrementZeroPage(0x03);

			Compiler.Label(Function.Label("Skip"));

			Cpu.Jump(Function.Label("ForEachCharacter"));

			Compiler.Label(Function.Label("Done"));

			Cpu.A = Petscii.NewLine;

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.Return();
		}

		public static void WriteLineInt()
		{
			var value = 0x02;
			var digitValue = 0x06;
			var digitValuePointer = 0x0a;
			var character = 0x0c;
			var count = 0x0d;

			// Get Value
			Stack.PullZeroPage32(value);

			// Check For Zero
			Cpu.CopyZeroPageToA(value + 0);
			Cpu.OrAWithZeroPage(value + 1);
			Cpu.OrAWithZeroPage(value + 2);
			Cpu.OrAWithZeroPage(value + 3);

			Cpu.IfNotZero(Function.Label("CheckForNegative"));

			Cpu.A = Petscii.GetBytes("0")[0];

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.Jump(Function.Label("Done"));

			// Check For Negative
			Compiler.Label(Function.Label("CheckForNegative"));

			Cpu.CopyZeroPageToA(value + 3);

			Cpu.IfNotNegative(Function.Label("FindFirstDigit"));

			Cpu.A = Petscii.GetBytes("-")[0];

			Cpu.Call(Kernal.WriteCharacter);

			// Skip Zero Digits
			Compiler.Label(Function.Label("FindFirstDigit"));

			Cpu.A = 10;
			Cpu.CopyAToZeroPage(count);

			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			Compiler.LowReference(Function.Label("DigitValues"));

			Cpu.CopyAToZeroPage(digitValuePointer);

			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			Compiler.HighReference(Function.Label("DigitValues"));

			Cpu.CopyAToZeroPage(digitValuePointer + 1);

			Compiler.Label(Function.Label("ForEachDigit"));

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

			Cpu.CopyZeroPageToA(value + 3);
			Cpu.CompareAToZeroPage(digitValue + 3);
			Cpu.IfLess(Function.Label("NextDigit"));
			Cpu.IfNotEqual(Function.Label("DrawDigits"));

			Cpu.CopyZeroPageToA(value + 2);
			Cpu.CompareAToZeroPage(digitValue + 2);
			Cpu.IfLess(Function.Label("NextDigit"));
			Cpu.IfNotEqual(Function.Label("DrawDigits"));

			Cpu.CopyZeroPageToA(value + 1);
			Cpu.CompareAToZeroPage(digitValue + 1);
			Cpu.IfLess(Function.Label("NextDigit"));
			Cpu.IfNotEqual(Function.Label("DrawDigits"));

			Cpu.CopyZeroPageToA(value + 0);
			Cpu.CompareAToZeroPage(digitValue + 0);
			Cpu.IfLess(Function.Label("NextDigit"));
			Cpu.Jump(Function.Label("DrawDigits"));

			Compiler.Label(Function.Label("NextDigit"));

			Cpu.DecrementZeroPage(count);

			Cpu.ClearCarryFlag();
			Cpu.CopyZeroPageToA(digitValuePointer + 0);
			Cpu.AddValuePlusCarryToA(4);
			Cpu.CopyAToZeroPage(digitValuePointer + 0);
			Cpu.CopyZeroPageToA(digitValuePointer + 1);
			Cpu.AddValuePlusCarryToA(0);
			Cpu.CopyAToZeroPage(digitValuePointer + 1);

			Cpu.Jump(Function.Label("ForEachDigit"));

			// Draw Remaining Digits
			Compiler.Label(Function.Label("DrawDigits"));

			Compiler.Label(Function.Label("ForEachCharacter"));

			Cpu.A = Petscii.GetBytes("0")[0];

			Cpu.CopyAToZeroPage(character);

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

			// While Value > DigitValue
			Compiler.Label(Function.Label("Loop"));

			Cpu.CopyZeroPageToA(value + 3);
			Cpu.CompareAToZeroPage(digitValue + 3);
			Cpu.IfLess(Function.Label("DrawDigit"));
			Cpu.IfNotEqual(Function.Label("IncrementCharacter"));

			Cpu.CopyZeroPageToA(value + 2);
			Cpu.CompareAToZeroPage(digitValue + 2);
			Cpu.IfLess(Function.Label("DrawDigit"));
			Cpu.IfNotEqual(Function.Label("IncrementCharacter"));

			Cpu.CopyZeroPageToA(value + 1);
			Cpu.CompareAToZeroPage(digitValue + 1);
			Cpu.IfLess(Function.Label("DrawDigit"));
			Cpu.IfNotEqual(Function.Label("IncrementCharacter"));

			Cpu.CopyZeroPageToA(value + 0);
			Cpu.CompareAToZeroPage(digitValue + 0);
			Cpu.IfLess(Function.Label("DrawDigit"));

			Compiler.Label(Function.Label("IncrementCharacter"));

			Cpu.IncrementZeroPage(character);

			Cpu.SetCarryFlag();
			Cpu.CopyZeroPageToA(value + 0);
			Cpu.SubtractZeroPagePlusCarryFromA(digitValue + 0);
			Cpu.CopyAToZeroPage(value + 0);
			Cpu.CopyZeroPageToA(value + 1);
			Cpu.SubtractZeroPagePlusCarryFromA(digitValue + 1);
			Cpu.CopyAToZeroPage(value + 1);
			Cpu.CopyZeroPageToA(value + 2);
			Cpu.SubtractZeroPagePlusCarryFromA(digitValue + 2);
			Cpu.CopyAToZeroPage(value + 2);
			Cpu.CopyZeroPageToA(value + 3);
			Cpu.SubtractZeroPagePlusCarryFromA(digitValue + 3);
			Cpu.CopyAToZeroPage(value + 3);

			Cpu.Jump(Function.Label("Loop"));

			// Draw Digit
			Compiler.Label(Function.Label("DrawDigit"));

			Cpu.CopyZeroPageToA(character);

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.DecrementZeroPage(count);

			Cpu.IfZero(Function.Label("Done"));

			Cpu.ClearCarryFlag();
			Cpu.CopyZeroPageToA(digitValuePointer + 0);
			Cpu.AddValuePlusCarryToA(4);
			Cpu.CopyAToZeroPage(digitValuePointer + 0);
			Cpu.CopyZeroPageToA(digitValuePointer + 1);
			Cpu.AddValuePlusCarryToA(0);
			Cpu.CopyAToZeroPage(digitValuePointer + 1);

			Cpu.Jump(Function.Label("ForEachCharacter"));

			// Done
			Compiler.Label(Function.Label("Done"));

			Cpu.A = Petscii.NewLine;

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.Return();

			// Digit Values
			Compiler.Label(Function.Label("DigitValues"));

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

		public static void WriteInt()
		{
			var value = 0x02;
			var digitValue = 0x06;
			var digitValuePointer = 0x0a;
			var character = 0x0c;
			var count = 0x0d;

			// Get Value
			Stack.PullZeroPage32(value);

			// Check For Zero
			Cpu.CopyZeroPageToA(value + 0);
			Cpu.OrAWithZeroPage(value + 1);
			Cpu.OrAWithZeroPage(value + 2);
			Cpu.OrAWithZeroPage(value + 3);

			Cpu.IfNotZero(Function.Label("CheckForNegative"));

			Cpu.A = Petscii.GetBytes("0")[0];

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.Jump(Function.Label("Done"));

			// Check For Negative
			Compiler.Label(Function.Label("CheckForNegative"));

			Cpu.CopyZeroPageToA(value + 3);

			Cpu.IfNotNegative(Function.Label("FindFirstDigit"));

			Cpu.A = Petscii.GetBytes("-")[0];

			Cpu.Call(Kernal.WriteCharacter);

			// Skip Zero Digits
			Compiler.Label(Function.Label("FindFirstDigit"));

			Cpu.A = 10;
			Cpu.CopyAToZeroPage(count);

			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			Compiler.LowReference(Function.Label("DigitValues"));

			Cpu.CopyAToZeroPage(digitValuePointer);

			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			Compiler.HighReference(Function.Label("DigitValues"));

			Cpu.CopyAToZeroPage(digitValuePointer + 1);

			Compiler.Label(Function.Label("ForEachDigit"));

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

			Cpu.CopyZeroPageToA(value + 3);
			Cpu.CompareAToZeroPage(digitValue + 3);
			Cpu.IfLess(Function.Label("NextDigit"));
			Cpu.IfNotEqual(Function.Label("DrawDigits"));

			Cpu.CopyZeroPageToA(value + 2);
			Cpu.CompareAToZeroPage(digitValue + 2);
			Cpu.IfLess(Function.Label("NextDigit"));
			Cpu.IfNotEqual(Function.Label("DrawDigits"));

			Cpu.CopyZeroPageToA(value + 1);
			Cpu.CompareAToZeroPage(digitValue + 1);
			Cpu.IfLess(Function.Label("NextDigit"));
			Cpu.IfNotEqual(Function.Label("DrawDigits"));

			Cpu.CopyZeroPageToA(value + 0);
			Cpu.CompareAToZeroPage(digitValue + 0);
			Cpu.IfLess(Function.Label("NextDigit"));
			Cpu.Jump(Function.Label("DrawDigits"));

			Compiler.Label(Function.Label("NextDigit"));

			Cpu.DecrementZeroPage(count);

			Cpu.ClearCarryFlag();
			Cpu.CopyZeroPageToA(digitValuePointer + 0);
			Cpu.AddValuePlusCarryToA(4);
			Cpu.CopyAToZeroPage(digitValuePointer + 0);
			Cpu.CopyZeroPageToA(digitValuePointer + 1);
			Cpu.AddValuePlusCarryToA(0);
			Cpu.CopyAToZeroPage(digitValuePointer + 1);

			Cpu.Jump(Function.Label("ForEachDigit"));

			// Draw Remaining Digits
			Compiler.Label(Function.Label("DrawDigits"));

			Compiler.Label(Function.Label("ForEachCharacter"));

			Cpu.A = Petscii.GetBytes("0")[0];

			Cpu.CopyAToZeroPage(character);

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

			// While Value > DigitValue
			Compiler.Label(Function.Label("Loop"));

			Cpu.CopyZeroPageToA(value + 3);
			Cpu.CompareAToZeroPage(digitValue + 3);
			Cpu.IfLess(Function.Label("DrawDigit"));
			Cpu.IfNotEqual(Function.Label("IncrementCharacter"));

			Cpu.CopyZeroPageToA(value + 2);
			Cpu.CompareAToZeroPage(digitValue + 2);
			Cpu.IfLess(Function.Label("DrawDigit"));
			Cpu.IfNotEqual(Function.Label("IncrementCharacter"));

			Cpu.CopyZeroPageToA(value + 1);
			Cpu.CompareAToZeroPage(digitValue + 1);
			Cpu.IfLess(Function.Label("DrawDigit"));
			Cpu.IfNotEqual(Function.Label("IncrementCharacter"));

			Cpu.CopyZeroPageToA(value + 0);
			Cpu.CompareAToZeroPage(digitValue + 0);
			Cpu.IfLess(Function.Label("DrawDigit"));

			Compiler.Label(Function.Label("IncrementCharacter"));

			Cpu.IncrementZeroPage(character);

			Cpu.SetCarryFlag();
			Cpu.CopyZeroPageToA(value + 0);
			Cpu.SubtractZeroPagePlusCarryFromA(digitValue + 0);
			Cpu.CopyAToZeroPage(value + 0);
			Cpu.CopyZeroPageToA(value + 1);
			Cpu.SubtractZeroPagePlusCarryFromA(digitValue + 1);
			Cpu.CopyAToZeroPage(value + 1);
			Cpu.CopyZeroPageToA(value + 2);
			Cpu.SubtractZeroPagePlusCarryFromA(digitValue + 2);
			Cpu.CopyAToZeroPage(value + 2);
			Cpu.CopyZeroPageToA(value + 3);
			Cpu.SubtractZeroPagePlusCarryFromA(digitValue + 3);
			Cpu.CopyAToZeroPage(value + 3);

			Cpu.Jump(Function.Label("Loop"));

			// Draw Digit
			Compiler.Label(Function.Label("DrawDigit"));

			Cpu.CopyZeroPageToA(character);

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.DecrementZeroPage(count);

			Cpu.IfZero(Function.Label("Done"));

			Cpu.ClearCarryFlag();
			Cpu.CopyZeroPageToA(digitValuePointer + 0);
			Cpu.AddValuePlusCarryToA(4);
			Cpu.CopyAToZeroPage(digitValuePointer + 0);
			Cpu.CopyZeroPageToA(digitValuePointer + 1);
			Cpu.AddValuePlusCarryToA(0);
			Cpu.CopyAToZeroPage(digitValuePointer + 1);

			Cpu.Jump(Function.Label("ForEachCharacter"));

			// Done
			Compiler.Label(Function.Label("Done"));

			Cpu.Return();

			// Digit Values
			Compiler.Label(Function.Label("DigitValues"));

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

		internal static void ReadLine()
		{
			var length = 0x02;
			var newString = 0x04;
			var buffer = 0x9b00;

			Cpu.A = 0;

			Cpu.CopyAToZeroPage(length + 0);

			Compiler.Label(Function.Label("Loop"));

			Cpu.Call(Kernal.ReadCharacter);

			Cpu.CompareAToValue(0x00);

			Cpu.IfEqual(Function.Label("Loop"));

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.CompareAToValue(Petscii.NewLine);

			Cpu.IfEqual(Function.Label("Done"));

			Cpu.CopyZeroPageToX(length);

			Cpu.CopyAToAbsolutePlusX(buffer);

			Cpu.IncrementZeroPage(length);

			Cpu.Jump(Function.Label("Loop"));

			Compiler.Label(Function.Label("Done"));

			// Write Terminator
			Cpu.A = 0;

			Cpu.CopyZeroPageToX(length);

			Cpu.CopyAToAbsolutePlusX(buffer);

			Cpu.IncrementZeroPage(length);

			// Create String
			Cpu.CopyAbsoluteToA(Heap.Address + 0);
			Cpu.CopyAToZeroPage(newString + 0);

			Cpu.CopyAbsoluteToA(Heap.Address + 1);
			Cpu.CopyAToZeroPage(newString + 1);

			Cpu.ClearCarryFlag();

			Cpu.CopyZeroPageToA(length + 0);
			Cpu.AddAbsolutePlusCarryToA(Heap.Address + 0);
			Cpu.CopyAToAbsolute(Heap.Address + 0);

			Cpu.A = 0;
			Cpu.AddAbsolutePlusCarryToA(Heap.Address + 1);
			Cpu.CopyAToAbsolute(Heap.Address + 1);

			// Copy String
			Cpu.Y = 0;
			Cpu.X = 0;

			Compiler.Label(Function.Label("CopyString"));

			Cpu.CopyAbsolutePlusXToA(buffer);
			Cpu.CopyAToZeroPagePointerPlusY(newString);

			Cpu.IfZero(Function.Label("Return"));

			Cpu.IncrementX();
			Cpu.IncrementY();

			Cpu.Jump(Function.Label("CopyString"));

			Compiler.Label(Function.Label("Return"));

			Cpu.A = 0;
			Stack.PushA();
			Stack.PushA();

			Cpu.CopyZeroPageToA(newString + 1);
			Stack.PushA();

			Cpu.CopyZeroPageToA(newString + 0);
			Stack.PushA();

			Cpu.Return();
		}
	}
}
