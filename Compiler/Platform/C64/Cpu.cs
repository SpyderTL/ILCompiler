using System;
using ILCompiler.Platform.Mos6502;

namespace ILCompiler.Platform.C64
{
	internal static class Cpu
	{
		public static int A
		{
			set
			{
				Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
				Compiler.Writer.Write((byte)value);
			}
		}

		internal static void CopyAToAbsolute(int absolute)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyAToImmediate16Address);
			Compiler.Writer.Write((ushort)absolute);
		}

		internal static void CopyAbsoluteToA(int absolute)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyImmediate16AddressToA);
			Compiler.Writer.Write((ushort)absolute);
		}

		internal static void AddAbsolutePlusCarryToA(int absolute)
		{
			Compiler.Writer.Write((byte)OpCodes.AddImmediate16AddressPlusCarryToA);
			Compiler.Writer.Write((ushort)absolute);
		}

		internal static void ClearCarryFlag()
		{
			Compiler.Writer.Write((byte)OpCodes.ClearCarryFlag);
		}

		internal static void SetCarryFlag()
		{
			Compiler.Writer.Write((byte)OpCodes.SetCarryFlag);
		}

		public static int X
		{
			set
			{
				Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToX);
				Compiler.Writer.Write((byte)value);
			}
		}

		public static int Y
		{
			set
			{
				Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToY);
				Compiler.Writer.Write((byte)value);
			}
		}

		internal static void CopyZeroPagePointerPlusYToA(int zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8PointerAddressPlusYToA);
			Compiler.Writer.Write((byte)zeroPage);
		}

		internal static void IfNotZero(string label)
		{
			Compiler.Writer.Write((byte)OpCodes.BranchToRelative8IfNotZero);
			Compiler.RelativeReference(label);
		}

		internal static void IfNotEqual(string label)
		{
			IfNotZero(label);
		}

		internal static void Jump(string label)
		{
			Compiler.Writer.Write((byte)OpCodes.JumpToImmediate16);
			Compiler.AbsoluteReference(label);
		}

		internal static void Return()
		{
			Compiler.Writer.Write((byte)OpCodes.ReturnFromSubroutine);
		}

		internal static void CopyXToA()
		{
			Compiler.Writer.Write((byte)OpCodes.CopyXToA);
		}

		internal static void CopyAToX()
		{
			Compiler.Writer.Write((byte)OpCodes.CopyAToX);
		}

		internal static void CopyXToAbsolute(int absolute)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyXToImmediate16Address);
			Compiler.Writer.Write((ushort)absolute);
		}

		internal static void OrAWithZeroPage(int zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.OrAWithImmediate8Address);
			Compiler.Writer.Write((byte)zeroPage);
		}

		internal static void IfNotNegative(string label)
		{
			Compiler.Writer.Write((byte)OpCodes.BranchToRelative8IfNotNegative);
			Compiler.RelativeReference(label);
		}

		internal static void CopyXToStackPointer()
		{
			Compiler.Writer.Write((byte)OpCodes.CopyXToStackPointer);
		}

		internal static void DecrementZeroPage(int zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.DecrementImmediate8Address);
			Compiler.Writer.Write((byte)zeroPage);
		}

		internal static void SubtractValuePlusCarryFromA(byte value)
		{
			Compiler.Writer.Write((byte)OpCodes.SubtractImmediate8PlusCarryFromA);
			Compiler.Writer.Write(value);
		}

		internal static void CopyYToA()
		{
			Compiler.Writer.Write((byte)OpCodes.CopyYToA);
		}

		internal static void Call(string label)
		{
			if(!Compiler.Imports.Contains(label))
				Compiler.Imports.Add(label);

			Compiler.Writer.Write((byte)OpCodes.CallImmediate16);
			Compiler.AbsoluteReference(label);
		}

		internal static void CopyAToZeroPagePointerPlusY(int zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyAToImmediate8PointerAddressPlusY);
			Compiler.Writer.Write((byte)zeroPage);
		}

		internal static void CopyAToAbsolutePlusY(int absolute)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyAToImmediate16PlusYAddress);
			Compiler.Writer.Write((ushort)absolute);
		}

		internal static void CopyZeroPageToA(int zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8AddressToA);
			Compiler.Writer.Write((byte)zeroPage);
		}

		internal static void CopyZeroPageToX(int zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8AddressToX);
			Compiler.Writer.Write((byte)zeroPage);
		}

		internal static void CopyZeroPageToY(int zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8AddressToY);
			Compiler.Writer.Write((byte)zeroPage);
		}

		internal static void CopyAToY()
		{
			Compiler.Writer.Write((byte)OpCodes.CopyAToY);
		}

		internal static void IfNotCarry(string label)
		{
			Compiler.Writer.Write((byte)OpCodes.BranchToRelative8IfNotCarry);
			Compiler.RelativeReference(label);
		}

		internal static void IfLess(string label)
		{
			IfNotCarry(label);
		}

		internal static void CompareAToZeroPage(int zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.CompareAToImmediate8Address);
			Compiler.Writer.Write((byte)zeroPage);
		}

		internal static void IncrementX()
		{
			Compiler.Writer.Write((byte)OpCodes.IncrementX);
		}

		internal static void CopyStackPointerToX()
		{
			Compiler.Writer.Write((byte)OpCodes.CopyStackPointerToX);
		}

		internal static void PushA()
		{
			Compiler.Writer.Write((byte)OpCodes.PushAToStack);
		}

		internal static void PullA()
		{
			Compiler.Writer.Write((byte)OpCodes.PullAFromStack);
		}

		internal static void IncrementY()
		{
			Compiler.Writer.Write((byte)OpCodes.IncrementY);
		}

		internal static void IncrementZeroPage(int zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.IncrementImmediate8Address);
			Compiler.Writer.Write((byte)zeroPage);
		}

		internal static void Call(int absolute)
		{
			Compiler.Writer.Write((byte)OpCodes.CallImmediate16);
			Compiler.Writer.Write((ushort)absolute);
		}

		internal static void IfZero(string label)
		{
			Compiler.Writer.Write((byte)OpCodes.BranchToRelative8IfZero);
			Compiler.RelativeReference(label);
		}

		internal static void IfEqual(string label)
		{
			IfZero(label);
		}

		internal static void CopyAToAbsolutePlusX(int absolute)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyAToImmediate16PlusXAddress);
			Compiler.Writer.Write((ushort)absolute);
		}

		internal static void DecrementX()
		{
			Compiler.Writer.Write((byte)OpCodes.DecrementX);
		}

		internal static void DecrementY()
		{
			Compiler.Writer.Write((byte)OpCodes.DecrementY);
		}

		internal static void AddValuePlusCarryToA(byte value)
		{
			Compiler.Writer.Write((byte)OpCodes.AddImmediate8PlusCarryToA);
			Compiler.Writer.Write(value);
		}

		internal static void CopyAbsoluteToX(int absolute)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyImmediate16AddressToX);
			Compiler.Writer.Write((ushort)absolute);
		}

		internal static void CopyAbsolutePlusXToA(int absolute)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyImmediate16PlusXAddressToA);
			Compiler.Writer.Write((ushort)absolute);
		}

		internal static void SubtractZeroPagePlusCarryFromA(int zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.SubtractImmediate8AddressPlusCarryFromA);
			Compiler.Writer.Write((byte)zeroPage);
		}

		internal static void CopyAToZeroPage(int zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyAToImmediate8Address);
			Compiler.Writer.Write((byte)zeroPage);
		}

		internal static void CopyXToZeroPage(int zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyXToImmediate8Address);
			Compiler.Writer.Write((byte)zeroPage);
		}

		internal static void ShiftALeft()
		{
			Compiler.Writer.Write((byte)OpCodes.ShiftALeft);
		}

		internal static void AddZeroPagePlusCarryToA(int zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.AddImmediate8AddressPlusCarryToA);
			Compiler.Writer.Write((byte)zeroPage);
		}

		internal static void CompareAToValue(int value)
		{
			Compiler.Writer.Write((byte)OpCodes.CompareAToImmediate8);
			Compiler.Writer.Write((byte)value);
		}

		internal static void CompareXToValue(int value)
		{
			Compiler.Writer.Write((byte)OpCodes.CompareXToImmediate8);
			Compiler.Writer.Write((byte)value);
		}

		internal static void CompareYToValue(int value)
		{
			Compiler.Writer.Write((byte)OpCodes.CompareYToImmediate8);
			Compiler.Writer.Write((byte)value);
		}
	}
}