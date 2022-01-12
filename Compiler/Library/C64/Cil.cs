using System;
using ILCompiler.Platform.C64;
using ILCompiler.Platform.Mos6502;

namespace ILCompiler.Library.C64
{
	internal static class Cil
	{
		internal static void Ldloc_0()
		{
			Cpu.CopyStackPointerToX();

			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
			Cpu.CopyAToZeroPage(0x02);

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
			Cpu.CopyAToZeroPage(0x03);

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
			Cpu.CopyAToZeroPage(0x04);

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
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

		internal static void Ldloc_1()
		{
			Cpu.CopyStackPointerToX();

			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
			Cpu.CopyAToZeroPage(0x02);

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
			Cpu.CopyAToZeroPage(0x03);

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
			Cpu.CopyAToZeroPage(0x04);

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
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

		internal static void Ldloc_2()
		{
			Cpu.CopyStackPointerToX();

			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
			Cpu.CopyAToZeroPage(0x02);

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
			Cpu.CopyAToZeroPage(0x03);

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
			Cpu.CopyAToZeroPage(0x04);

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
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

		internal static void Ldloc_3()
		{
			Cpu.CopyStackPointerToX();

			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
			Cpu.CopyAToZeroPage(0x02);

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
			Cpu.CopyAToZeroPage(0x03);

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
			Cpu.CopyAToZeroPage(0x04);

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
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

		internal static void Ldloc_S()
		{
			Cpu.ShiftALeft();
			Cpu.ShiftALeft();

			Cpu.CopyStackPointerToX();

			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.CopyXToZeroPage(0x06);

			Cpu.ClearCarryFlag();

			Cpu.AddZeroPagePlusCarryToA(0x06);

			Cpu.CopyAToX();

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
			Cpu.CopyAToZeroPage(0x02);

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
			Cpu.CopyAToZeroPage(0x03);

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
			Cpu.CopyAToZeroPage(0x04);

			Cpu.IncrementX();
			Cpu.CopyAbsolutePlusXToA(0x100);
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

		internal static void Stloc_0()
		{
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x02);
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x03);
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x04);
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x05);

			Cpu.CopyStackPointerToX();

			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.CopyZeroPageToA(0x02);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.CopyZeroPageToA(0x03);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.CopyZeroPageToA(0x04);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.CopyZeroPageToA(0x05);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.Return();
		}

		internal static void Stloc_1()
		{
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x02);
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x03);
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x04);
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x05);

			Cpu.CopyStackPointerToX();

			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.CopyZeroPageToA(0x02);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.CopyZeroPageToA(0x03);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.CopyZeroPageToA(0x04);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.CopyZeroPageToA(0x05);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.Return();
		}

		internal static void Stloc_2()
		{
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x02);
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x03);
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x04);
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x05);

			Cpu.CopyStackPointerToX();

			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.CopyZeroPageToA(0x02);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.CopyZeroPageToA(0x03);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.CopyZeroPageToA(0x04);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.CopyZeroPageToA(0x05);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.Return();
		}

		internal static void Stloc_3()
		{
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x02);
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x03);
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x04);
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x05);

			Cpu.CopyStackPointerToX();

			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.CopyZeroPageToA(0x02);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.CopyZeroPageToA(0x03);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.CopyZeroPageToA(0x04);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.CopyZeroPageToA(0x05);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.Return();
		}

		internal static void Stloc_S()
		{
			Cpu.ShiftALeft();
			Cpu.ShiftALeft();

			Cpu.PushA();

			Stack.PullA();
			Cpu.CopyAToZeroPage(0x02);
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x03);
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x04);
			Stack.PullA();
			Cpu.CopyAToZeroPage(0x05);

			Cpu.PullA();

			Cpu.CopyStackPointerToX();

			Cpu.IncrementX();
			Cpu.IncrementX();

			Cpu.CopyXToZeroPage(0x06);

			Cpu.ClearCarryFlag();

			Cpu.AddZeroPagePlusCarryToA(0x06);

			Cpu.CopyAToX();

			Cpu.CopyZeroPageToA(0x02);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.CopyZeroPageToA(0x03);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.CopyZeroPageToA(0x04);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.CopyZeroPageToA(0x05);
			Cpu.IncrementX();
			Cpu.CopyAToAbsolutePlusX(0x100);

			Cpu.Return();
		}
	}
}