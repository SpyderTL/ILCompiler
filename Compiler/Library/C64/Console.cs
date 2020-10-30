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

			Cpu.IfNotZero(name + "CheckForNegative");

			Cpu.A = Petscii.GetBytes("0")[0];

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.Jump(name + "Done");

			// Check For Negative
			Compiler.Label(name + "CheckForNegative");

			Cpu.CopyZeroPageToA(value + 3);

			Cpu.IfNotNegative(name + "FindFirstDigit");

			Cpu.A = Petscii.GetBytes("-")[0];

			Cpu.Call(Kernal.WriteCharacter);

			// Skip Zero Digits
			Compiler.Label(name + "FindFirstDigit");

			Cpu.A = 10;
			Cpu.CopyAToZeroPage(count);

			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			Compiler.LowReference(name + "DigitValues");

			Cpu.CopyAToZeroPage(digitValuePointer);

			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			Compiler.HighReference(name + "DigitValues");

			Cpu.CopyAToZeroPage(digitValuePointer + 1);

			Compiler.Label(name + "ForEachDigit");

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
			Cpu.IfLess(name + "NextDigit");
			Cpu.IfNotEqual(name + "DrawDigits");

			Cpu.CopyZeroPageToA(value + 2);
			Cpu.CompareAToZeroPage(digitValue + 2);
			Cpu.IfLess(name + "NextDigit");
			Cpu.IfNotEqual(name + "DrawDigits");

			Cpu.CopyZeroPageToA(value + 1);
			Cpu.CompareAToZeroPage(digitValue + 1);
			Cpu.IfLess(name + "NextDigit");
			Cpu.IfNotEqual(name + "DrawDigits");

			Cpu.CopyZeroPageToA(value + 0);
			Cpu.CompareAToZeroPage(digitValue + 0);
			Cpu.IfLess(name + "NextDigit");
			Cpu.Jump(name + "DrawDigits");

			Compiler.Label(name + "NextDigit");

			Cpu.DecrementZeroPage(count);

			Cpu.ClearCarryFlag();
			Cpu.CopyZeroPageToA(digitValuePointer + 0);
			Cpu.AddValuePlusCarryToA(4);
			Cpu.CopyAToZeroPage(digitValuePointer + 0);
			Cpu.CopyZeroPageToA(digitValuePointer + 1);
			Cpu.AddValuePlusCarryToA(0);
			Cpu.CopyAToZeroPage(digitValuePointer + 1);

			Cpu.Jump(name + "ForEachDigit");

			// Draw Remaining Digits
			Compiler.Label(name + "DrawDigits");

			Compiler.Label(name + "ForEachCharacter");

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
			Compiler.Label(name + "Loop");

			Cpu.CopyZeroPageToA(value + 3);
			Cpu.CompareAToZeroPage(digitValue + 3);
			Cpu.IfLess(name + "DrawDigit");
			Cpu.IfNotEqual(name + "IncrementCharacter");

			Cpu.CopyZeroPageToA(value + 2);
			Cpu.CompareAToZeroPage(digitValue + 2);
			Cpu.IfLess(name + "DrawDigit");
			Cpu.IfNotEqual(name + "IncrementCharacter");

			Cpu.CopyZeroPageToA(value + 1);
			Cpu.CompareAToZeroPage(digitValue + 1);
			Cpu.IfLess(name + "DrawDigit");
			Cpu.IfNotEqual(name + "IncrementCharacter");

			Cpu.CopyZeroPageToA(value + 0);
			Cpu.CompareAToZeroPage(digitValue + 0);
			Cpu.IfLess(name + "DrawDigit");

			Compiler.Label(name + "IncrementCharacter");

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

			Cpu.Jump(name + "Loop");

			// Draw Digit
			Compiler.Label(name + "DrawDigit");

			Cpu.CopyZeroPageToA(character);

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.DecrementZeroPage(count);

			Cpu.IfZero(name + "Done");

			Cpu.ClearCarryFlag();
			Cpu.CopyZeroPageToA(digitValuePointer + 0);
			Cpu.AddValuePlusCarryToA(4);
			Cpu.CopyAToZeroPage(digitValuePointer + 0);
			Cpu.CopyZeroPageToA(digitValuePointer + 1);
			Cpu.AddValuePlusCarryToA(0);
			Cpu.CopyAToZeroPage(digitValuePointer + 1);

			Cpu.Jump(name + "ForEachCharacter");

			// Done
			Compiler.Label(name + "Done");

			Cpu.A = Petscii.NewLine;

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.Return();

			// Digit Values
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

		public static void WriteInt(string name)
		{
			Compiler.Label(name);

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

			Cpu.IfNotZero(name + "CheckForNegative");

			Cpu.A = Petscii.GetBytes("0")[0];

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.Jump(name + "Done");

			// Check For Negative
			Compiler.Label(name + "CheckForNegative");

			Cpu.CopyZeroPageToA(value + 3);

			Cpu.IfNotNegative(name + "FindFirstDigit");

			Cpu.A = Petscii.GetBytes("-")[0];

			Cpu.Call(Kernal.WriteCharacter);

			// Skip Zero Digits
			Compiler.Label(name + "FindFirstDigit");

			Cpu.A = 10;
			Cpu.CopyAToZeroPage(count);

			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			Compiler.LowReference(name + "DigitValues");

			Cpu.CopyAToZeroPage(digitValuePointer);

			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
			Compiler.HighReference(name + "DigitValues");

			Cpu.CopyAToZeroPage(digitValuePointer + 1);

			Compiler.Label(name + "ForEachDigit");

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
			Cpu.IfLess(name + "NextDigit");
			Cpu.IfNotEqual(name + "DrawDigits");

			Cpu.CopyZeroPageToA(value + 2);
			Cpu.CompareAToZeroPage(digitValue + 2);
			Cpu.IfLess(name + "NextDigit");
			Cpu.IfNotEqual(name + "DrawDigits");

			Cpu.CopyZeroPageToA(value + 1);
			Cpu.CompareAToZeroPage(digitValue + 1);
			Cpu.IfLess(name + "NextDigit");
			Cpu.IfNotEqual(name + "DrawDigits");

			Cpu.CopyZeroPageToA(value + 0);
			Cpu.CompareAToZeroPage(digitValue + 0);
			Cpu.IfLess(name + "NextDigit");
			Cpu.Jump(name + "DrawDigits");

			Compiler.Label(name + "NextDigit");

			Cpu.DecrementZeroPage(count);

			Cpu.ClearCarryFlag();
			Cpu.CopyZeroPageToA(digitValuePointer + 0);
			Cpu.AddValuePlusCarryToA(4);
			Cpu.CopyAToZeroPage(digitValuePointer + 0);
			Cpu.CopyZeroPageToA(digitValuePointer + 1);
			Cpu.AddValuePlusCarryToA(0);
			Cpu.CopyAToZeroPage(digitValuePointer + 1);

			Cpu.Jump(name + "ForEachDigit");

			// Draw Remaining Digits
			Compiler.Label(name + "DrawDigits");

			Compiler.Label(name + "ForEachCharacter");

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
			Compiler.Label(name + "Loop");

			Cpu.CopyZeroPageToA(value + 3);
			Cpu.CompareAToZeroPage(digitValue + 3);
			Cpu.IfLess(name + "DrawDigit");
			Cpu.IfNotEqual(name + "IncrementCharacter");

			Cpu.CopyZeroPageToA(value + 2);
			Cpu.CompareAToZeroPage(digitValue + 2);
			Cpu.IfLess(name + "DrawDigit");
			Cpu.IfNotEqual(name + "IncrementCharacter");

			Cpu.CopyZeroPageToA(value + 1);
			Cpu.CompareAToZeroPage(digitValue + 1);
			Cpu.IfLess(name + "DrawDigit");
			Cpu.IfNotEqual(name + "IncrementCharacter");

			Cpu.CopyZeroPageToA(value + 0);
			Cpu.CompareAToZeroPage(digitValue + 0);
			Cpu.IfLess(name + "DrawDigit");

			Compiler.Label(name + "IncrementCharacter");

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

			Cpu.Jump(name + "Loop");

			// Draw Digit
			Compiler.Label(name + "DrawDigit");

			Cpu.CopyZeroPageToA(character);

			Cpu.Call(Kernal.WriteCharacter);

			Cpu.DecrementZeroPage(count);

			Cpu.IfZero(name + "Done");

			Cpu.ClearCarryFlag();
			Cpu.CopyZeroPageToA(digitValuePointer + 0);
			Cpu.AddValuePlusCarryToA(4);
			Cpu.CopyAToZeroPage(digitValuePointer + 0);
			Cpu.CopyZeroPageToA(digitValuePointer + 1);
			Cpu.AddValuePlusCarryToA(0);
			Cpu.CopyAToZeroPage(digitValuePointer + 1);

			Cpu.Jump(name + "ForEachCharacter");

			// Done
			Compiler.Label(name + "Done");

			Cpu.Return();

			// Digit Values
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
