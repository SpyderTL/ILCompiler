﻿using System;
using ILCompiler.Platform.C64;

namespace ILCompiler.Library.C64
{
	// Software Stack Implementation
	internal static class Stack
	{
		internal static int Address;
		internal static int Pointer;

		/// <summary>
		/// Modifies: A X
		/// </summary>
		/// <param name="zeroPage"></param>
		internal static void PushZeroPage16(int zeroPage)
		{
			Cpu.CopyAbsoluteToX(Pointer);

			Cpu.CopyZeroPageToA(zeroPage + 1);
			Cpu.DecrementX();
			Cpu.CopyAToAbsolutePlusX(Address);

			Cpu.CopyZeroPageToA(zeroPage);
			Cpu.DecrementX();
			Cpu.CopyAToAbsolutePlusX(Address);

			Cpu.CopyXToAbsolute(Pointer);
		}

		/// <summary>
		/// Modifies: A X
		/// </summary>
		/// <param name="zeroPage"></param>
		internal static void PullZeroPage16(int zeroPage)
		{
			Cpu.CopyAbsoluteToX(Pointer);

			Cpu.CopyAbsolutePlusXToA(Address);
			Cpu.IncrementX();
			Cpu.CopyAToZeroPage(zeroPage);

			Cpu.CopyAbsolutePlusXToA(Address);
			Cpu.IncrementX();
			Cpu.CopyAToZeroPage(zeroPage + 1);

			Cpu.CopyXToAbsolute(Pointer);
		}

		/// <summary>
		/// Modifies: A X
		/// </summary>
		/// <param name="zeroPage"></param>
		internal static void PushZeroPage32(int zeroPage)
		{
			Cpu.CopyAbsoluteToX(Pointer);

			Cpu.CopyZeroPageToA(zeroPage + 3);
			Cpu.DecrementX();
			Cpu.CopyAToAbsolutePlusX(Address);

			Cpu.CopyZeroPageToA(zeroPage + 2);
			Cpu.DecrementX();
			Cpu.CopyAToAbsolutePlusX(Address);

			Cpu.CopyZeroPageToA(zeroPage + 1);
			Cpu.DecrementX();
			Cpu.CopyAToAbsolutePlusX(Address);

			Cpu.CopyZeroPageToA(zeroPage);
			Cpu.DecrementX();
			Cpu.CopyAToAbsolutePlusX(Address);

			Cpu.CopyXToAbsolute(Pointer);
		}

		/// <summary>
		/// Modifies: A X
		/// </summary>
		/// <param name="zeroPage"></param>
		internal static void PullZeroPage32(int zeroPage)
		{
			Cpu.CopyAbsoluteToX(Pointer);

			Cpu.CopyAbsolutePlusXToA(Address);
			Cpu.IncrementX();
			Cpu.CopyAToZeroPage(zeroPage);

			Cpu.CopyAbsolutePlusXToA(Address);
			Cpu.IncrementX();
			Cpu.CopyAToZeroPage(zeroPage + 1);

			Cpu.CopyAbsolutePlusXToA(Address);
			Cpu.IncrementX();
			Cpu.CopyAToZeroPage(zeroPage + 2);

			Cpu.CopyAbsolutePlusXToA(Address);
			Cpu.IncrementX();
			Cpu.CopyAToZeroPage(zeroPage + 3);

			Cpu.CopyXToAbsolute(Pointer);
		}

		/// <summary>
		/// Modifies: X
		/// </summary>
		/// <param name="zeroPage"></param>
		internal static void PushA()
		{
			Cpu.CopyAbsoluteToX(Pointer);

			Cpu.DecrementX();

			Cpu.CopyAToAbsolutePlusX(Address);

			Cpu.CopyXToAbsolute(Pointer);
		}

		/// <summary>
		/// Modifies: X
		/// </summary>
		/// <param name="zeroPage"></param>
		internal static void PullA()
		{
			Cpu.CopyAbsoluteToX(Pointer);

			Cpu.CopyAbsolutePlusXToA(Address);

			Cpu.IncrementX();

			Cpu.CopyXToAbsolute(Pointer);
		}
	}
}