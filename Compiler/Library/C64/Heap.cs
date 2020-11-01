using System;
using ILCompiler.Platform.C64;

namespace ILCompiler.Library.C64
{
	internal static class Heap
	{
		internal static int Address;

		internal static void Reset()
		{
			Cpu.A = (Address + 2) & 0xff;
			Cpu.CopyAToAbsolute(Address);

			Cpu.A = ((Address + 2) >> 8) & 0xff;
			Cpu.CopyAToAbsolute(Address + 1);
		}

		internal static void Allocate(int size, int zeroPage)
		{
			Cpu.CopyAbsoluteToA(Address);
			Cpu.CopyAToZeroPage(zeroPage);

			Cpu.CopyAbsoluteToA(Address + 1);
			Cpu.CopyAToZeroPage(zeroPage + 1);

			Cpu.ClearCarryFlag();

			Cpu.A = (size >> 8) & 0xff;
			Cpu.AddAbsolutePlusCarryToA(Address);
			Cpu.CopyAToAbsolute(Address);

			Cpu.A = (size >> 8) & 0xff;
			Cpu.AddAbsolutePlusCarryToA(Address + 1);
			Cpu.CopyAToAbsolute(Address + 1);
		}
	}
}