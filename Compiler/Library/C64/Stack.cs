using System;
using ILCompiler.Platform.C64;

namespace ILCompiler.Library.C64
{
	internal static class Stack
	{
		internal static ushort Address;
		internal static ushort Pointer;

		internal static void PushZeroPage16(byte zeroPage)
		{
			Cpu.CopyAbsoluteToX(Pointer);

			Cpu.CopyZeroPageToA((byte)(zeroPage + 1));
			Cpu.DecrementX();
			Cpu.CopyAToAbsolutePlusX(Address);

			Cpu.CopyZeroPageToA(zeroPage);
			Cpu.DecrementX();
			Cpu.CopyAToAbsolutePlusX(Address);

			Cpu.CopyXToAbsolute(Pointer);
		}

		internal static void PullZeroPage16(byte zeroPage)
		{
			Cpu.CopyAbsoluteToX(Pointer);

			Cpu.CopyAbsolutePlusXToA(Address);
			Cpu.IncrementX();
			Cpu.CopyAToZeroPage(zeroPage);

			Cpu.CopyAbsolutePlusXToA(Address);
			Cpu.IncrementX();
			Cpu.CopyAToZeroPage((byte)(zeroPage + 1));

			Cpu.CopyXToAbsolute(Pointer);
		}

		internal static void PushZeroPage32(byte zeroPage)
		{
			Cpu.CopyAbsoluteToX(Pointer);

			Cpu.CopyZeroPageToA((byte)(zeroPage + 3));
			Cpu.DecrementX();
			Cpu.CopyAToAbsolutePlusX(Address);

			Cpu.CopyZeroPageToA((byte)(zeroPage + 2));
			Cpu.DecrementX();
			Cpu.CopyAToAbsolutePlusX(Address);

			Cpu.CopyZeroPageToA((byte)(zeroPage + 1));
			Cpu.DecrementX();
			Cpu.CopyAToAbsolutePlusX(Address);

			Cpu.CopyZeroPageToA(zeroPage);
			Cpu.DecrementX();
			Cpu.CopyAToAbsolutePlusX(Address);

			Cpu.CopyXToAbsolute(Pointer);
		}

		internal static void PullZeroPage32(byte zeroPage)
		{
			Cpu.CopyAbsoluteToX(Pointer);

			Cpu.CopyAbsolutePlusXToA(Address);
			Cpu.IncrementX();
			Cpu.CopyAToZeroPage(zeroPage);

			Cpu.CopyAbsolutePlusXToA(Address);
			Cpu.IncrementX();
			Cpu.CopyAToZeroPage((byte)(zeroPage + 1));

			Cpu.CopyAbsolutePlusXToA(Address);
			Cpu.IncrementX();
			Cpu.CopyAToZeroPage((byte)(zeroPage + 2));

			Cpu.CopyAbsolutePlusXToA(Address);
			Cpu.IncrementX();
			Cpu.CopyAToZeroPage((byte)(zeroPage + 3));

			Cpu.CopyXToAbsolute(Pointer);
		}

		internal static void PushA()
		{
			Cpu.CopyAbsoluteToX(Pointer);

			Cpu.DecrementX();

			Cpu.CopyAToAbsolutePlusX(Address);

			Cpu.CopyXToAbsolute(Pointer);
		}

		internal static void PullA()
		{
			Cpu.CopyAbsoluteToX(Pointer);

			Cpu.CopyAbsolutePlusXToA(Address);

			Cpu.IncrementX();

			Cpu.CopyXToAbsolute(Pointer);
		}
	}
}