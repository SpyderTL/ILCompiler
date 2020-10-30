using System;
using ILCompiler.Platform.C64;

namespace ILCompiler.Library.C64
{
	internal class Math
	{
		internal static void AddToA(byte value)
		{
			Cpu.ClearCarryFlag();

			Cpu.AddValuePlusCarryToA(value);
		}

		internal static void SubtractFromA(byte value)
		{
			Cpu.SetCarryFlag();

			Cpu.SubtractValuePlusCarryFromA(value);
		}
	}
}