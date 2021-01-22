using System;
using ILCompiler.Platform.C64;
using ILCompiler.Platform.Mos6502;

namespace ILCompiler.Library.C64
{
	internal static class String
	{
		internal static void Concat()
		{
			var stringPointer = 0x02;
			var stringPointer2 = 0x06;
			var newString = 0x0a;
			var length = 0x0e;
			var buffer = 0x9b00;

			Cpu.A = 0;

			Cpu.CopyAToZeroPage(length + 0);

			Stack.PullZeroPage32(stringPointer2);
			Stack.PullZeroPage32(stringPointer);

			// Copy String 1 To Buffer
			Cpu.Y = 0;
			Cpu.X = 0;

			Compiler.Label(Function.Label("ForEachCharacter"));

			Cpu.CopyZeroPagePointerPlusYToA(stringPointer);

			Cpu.IfZero(Function.Label("CopyString2"));

			Cpu.CopyAToAbsolutePlusX(buffer);
			
			Cpu.IncrementX();
			Cpu.IncrementY();
			Cpu.IncrementZeroPage(length);

			Cpu.Jump(Function.Label("ForEachCharacter"));

			// Copy String 2 To Buffer
			Compiler.Label(Function.Label("CopyString2"));

			Cpu.Y = 0;

			Compiler.Label(Function.Label("ForEachCharacter2"));

			Cpu.CopyZeroPagePointerPlusYToA(stringPointer2);

			Cpu.IfZero(Function.Label("WriteTerminator"));

			Cpu.CopyAToAbsolutePlusX(buffer);

			Cpu.IncrementX();
			Cpu.IncrementY();
			Cpu.IncrementZeroPage(length);

			Cpu.Jump(Function.Label("ForEachCharacter2"));

			// Write Terminator
			Compiler.Label(Function.Label("WriteTerminator"));

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

		internal static void get_Length()
		{
			var stringPointer = 0x02;
			var length = 0x06;

			Cpu.A = 0;

			Cpu.CopyAToZeroPage(length);

			Stack.PullZeroPage32(stringPointer);

			Cpu.Y = 0;

			Compiler.Label(Function.Label("ForEachCharacter"));

			Cpu.CopyZeroPagePointerPlusYToA(stringPointer);

			Cpu.IfZero(Function.Label("Done"));

			Cpu.IncrementZeroPage(length);

			Cpu.IncrementZeroPage(stringPointer);

			Cpu.IfNotZero(Function.Label("Skip"));

			Cpu.IncrementZeroPage(stringPointer + 1);

			Compiler.Label(Function.Label("Skip"));

			Cpu.Jump(Function.Label("ForEachCharacter"));

			Compiler.Label(Function.Label("Done"));

			Cpu.A = 0;

			Stack.PushA();
			Stack.PushA();
			Stack.PushA();

			Cpu.CopyZeroPageToA(length);

			Stack.PushA();

			Cpu.Return();
		}
	}
}