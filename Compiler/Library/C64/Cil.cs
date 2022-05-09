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

		internal static void Clt()
		{
			Stack.PullZeroPage32(0x06);
			Stack.PullZeroPage32(0x02);

			Cpu.CopyZeroPageToA(0x05);
			Cpu.CompareAToZeroPage(0x09);
			Cpu.IfLess("Clt_True");
			Cpu.IfNotEqual("Clt_False");

			Cpu.CopyZeroPageToA(0x04);
			Cpu.CompareAToZeroPage(0x08);
			Cpu.IfLess("Clt_True");
			Cpu.IfNotEqual("Clt_False");

			Cpu.CopyZeroPageToA(0x03);
			Cpu.CompareAToZeroPage(0x07);
			Cpu.IfLess("Clt_True");
			Cpu.IfNotEqual("Clt_False");

			Cpu.CopyZeroPageToA(0x02);
			Cpu.CompareAToZeroPage(0x06);
			Cpu.IfGreaterOrEqual("Clt_False");

			Compiler.Label("Clt_True");

			Cpu.A = 0;
			Stack.PushA();
			Stack.PushA();
			Stack.PushA();
			Cpu.A = 1;
			Stack.PushA();

			Cpu.Return();

			Compiler.Label("Clt_False");

			Cpu.A = 0;
			Stack.PushA();
			Stack.PushA();
			Stack.PushA();
			Stack.PushA();

			Cpu.Return();
		}

		internal static void Cgt()
		{
			Stack.PullZeroPage32(0x06);
			Stack.PullZeroPage32(0x02);

			Cpu.CopyZeroPageToA(0x05);
			Cpu.CompareAToZeroPage(0x09);
			Cpu.IfLess("Cgt_False");
			Cpu.IfNotEqual("Cgt_True");

			Cpu.CopyZeroPageToA(0x04);
			Cpu.CompareAToZeroPage(0x08);
			Cpu.IfLess("Cgt_False");
			Cpu.IfNotEqual("Cgt_True");

			Cpu.CopyZeroPageToA(0x03);
			Cpu.CompareAToZeroPage(0x07);
			Cpu.IfLess("Cgt_False");
			Cpu.IfNotEqual("Cgt_True");

			Cpu.CopyZeroPageToA(0x02);
			Cpu.CompareAToZeroPage(0x06);
			Cpu.IfLess("Cgt_False");
			Cpu.IfEqual("Cgt_False");

			Compiler.Label("Cgt_True");

			Cpu.A = 0;
			Stack.PushA();
			Stack.PushA();
			Stack.PushA();
			Cpu.A = 1;
			Stack.PushA();

			Cpu.Return();

			Compiler.Label("Cgt_False");

			Cpu.A = 0;
			Stack.PushA();
			Stack.PushA();
			Stack.PushA();
			Stack.PushA();

			Cpu.Return();
		}

		internal static void Ceq()
		{
			Stack.PullZeroPage32(0x06);
			Stack.PullZeroPage32(0x02);

			Cpu.CopyZeroPageToA(0x05);
			Cpu.CompareAToZeroPage(0x09);
			Cpu.IfNotEqual("Ceq_False");

			Cpu.CopyZeroPageToA(0x04);
			Cpu.CompareAToZeroPage(0x08);
			Cpu.IfNotEqual("Ceq_False");

			Cpu.CopyZeroPageToA(0x03);
			Cpu.CompareAToZeroPage(0x07);
			Cpu.IfNotEqual("Ceq_False");

			Cpu.CopyZeroPageToA(0x02);
			Cpu.CompareAToZeroPage(0x06);
			Cpu.IfNotEqual("Ceq_False");

			Compiler.Label("Ceq_True");

			Cpu.A = 0;
			Stack.PushA();
			Stack.PushA();
			Stack.PushA();
			Cpu.A = 1;
			Stack.PushA();

			Cpu.Return();

			Compiler.Label("Ceq_False");

			Cpu.A = 0;
			Stack.PushA();
			Stack.PushA();
			Stack.PushA();
			Stack.PushA();

			Cpu.Return();
		}

		internal static void Shr()
		{
			Stack.PullZeroPage32(0x06);
			Stack.PullZeroPage32(0x02);

			Compiler.Label("Shr_Loop");

			Cpu.CopyZeroPageToA(0x05);
			Cpu.ShiftARight();
			Cpu.CopyAToZeroPage(0x05);

			Cpu.CopyZeroPageToA(0x04);
			Cpu.RollARight();
			Cpu.CopyAToZeroPage(0x04);

			Cpu.CopyZeroPageToA(0x03);
			Cpu.RollARight();
			Cpu.CopyAToZeroPage(0x03);

			Cpu.CopyZeroPageToA(0x02);
			Cpu.RollARight();
			Cpu.CopyAToZeroPage(0x02);

			Cpu.DecrementZeroPage(0x06);

			Cpu.IfNotZero("Shr_Loop");

			Stack.PushZeroPage32(0x02);

			Cpu.Return();
		}

		internal static void Shl()
		{
			Stack.PullZeroPage32(0x06);
			Stack.PullZeroPage32(0x02);

			Compiler.Label("Shl_Loop");

			Cpu.CopyZeroPageToA(0x02);
			Cpu.ShiftALeft();
			Cpu.CopyAToZeroPage(0x02);

			Cpu.CopyZeroPageToA(0x03);
			Cpu.RollALeft();
			Cpu.CopyAToZeroPage(0x03);

			Cpu.CopyZeroPageToA(0x04);
			Cpu.RollALeft();
			Cpu.CopyAToZeroPage(0x04);

			Cpu.CopyZeroPageToA(0x05);
			Cpu.RollALeft();
			Cpu.CopyAToZeroPage(0x05);

			Cpu.DecrementZeroPage(0x06);

			Cpu.IfNotZero("Shl_Loop");

			Stack.PushZeroPage32(0x02);

			Cpu.Return();
		}
	}
}