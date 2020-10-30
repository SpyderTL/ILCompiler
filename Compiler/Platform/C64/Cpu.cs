using System;
using ILCompiler.Platform.Mos6502;

namespace ILCompiler.Platform.C64
{
	internal static class Cpu
	{
		public static byte A
		{
			set
			{
				Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToA);
				Compiler.Writer.Write(value);
			}
		}

		internal static void ClearCarryFlag()
		{
			Compiler.Writer.Write((byte)OpCodes.ClearCarryFlag);
		}

		internal static void SetCarryFlag()
		{
			Compiler.Writer.Write((byte)OpCodes.SetCarryFlag);
		}

		public static byte X
		{
			set
			{
				Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToX);
				Compiler.Writer.Write(value);
			}
		}

		public static byte Y
		{
			set
			{
				Compiler.Writer.Write((byte)OpCodes.CopyImmediate8ToY);
				Compiler.Writer.Write(value);
			}
		}

		internal static void CopyZeroPagePointerPlusYToA(byte zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8PointerAddressPlusYToA);
			Compiler.Writer.Write(zeroPage);
		}

		internal static void IfNotZero(string label)
		{
			Compiler.Writer.Write((byte)OpCodes.BranchToRelative8IfNotZero);
			Compiler.RelativeReference(label);
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

		internal static void CopyXToAbsolute(ushort absolute)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyXToImmediate16Address);
			Compiler.Writer.Write(absolute);
		}

		internal static void OrAWithZeroPage(byte zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.OrAWithImmediate8Address);
			Compiler.Writer.Write(zeroPage);
		}

		internal static void CopyXToStackPointer()
		{
			Compiler.Writer.Write((byte)OpCodes.CopyXToStackPointer);
		}

		internal static void SubtractValuePlusCarryFromA(byte value)
		{
			Compiler.Writer.Write((byte)OpCodes.SubtractImmediate8PlusCarryFromA);
			Compiler.Writer.Write(value);
		}

		internal static void Call(string label)
		{
			Compiler.Imports.Add(label);

			Compiler.Writer.Write((byte)OpCodes.CallImmediate16);
			Compiler.AbsoluteReference(label);
		}

		internal static void CopyAToZeroPagePointerPlusY(byte zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyAToImmediate8PointerAddressPlusY);
			Compiler.Writer.Write(zeroPage);
		}

		internal static void CopyAToAbsolutePlusY(ushort absolute)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyAToImmediate16PlusYAddress);
			Compiler.Writer.Write(absolute);
		}

		internal static void CopyZeroPageToA(byte zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyImmediate8AddressToA);
			Compiler.Writer.Write(zeroPage);
		}

		internal static void CopyAToY()
		{
			Compiler.Writer.Write((byte)OpCodes.CopyAToY);
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

		internal static void IncrementY()
		{
			Compiler.Writer.Write((byte)OpCodes.IncrementY);
		}

		internal static void IncrementZeroPage(byte zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.IncrementImmediate8Address);
			Compiler.Writer.Write(zeroPage);
		}

		internal static void Call(ushort absolute)
		{
			Compiler.Writer.Write((byte)OpCodes.CallImmediate16);
			Compiler.Writer.Write(absolute);
		}

		internal static void IfZero(string label)
		{
			Compiler.Writer.Write((byte)OpCodes.BranchToRelative8IfZero);
			Compiler.RelativeReference(label);
		}

		internal static void CopyAToAbsolutePlusX(ushort absolute)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyAToImmediate16PlusXAddress);
			Compiler.Writer.Write(absolute);
		}

		internal static void DecrementX()
		{
			Compiler.Writer.Write((byte)OpCodes.DecrementX);
		}

		internal static void AddValuePlusCarryToA(byte value)
		{
			Compiler.Writer.Write((byte)OpCodes.AddImmediate8PlusCarryToA);
			Compiler.Writer.Write(value);
		}

		internal static void CopyAbsoluteToX(ushort absolute)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyImmediate16AddressToX);
			Compiler.Writer.Write(absolute);
		}

		internal static void CopyAbsolutePlusXToA(ushort absolute)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyImmediate16PlusXAddressToA);
			Compiler.Writer.Write(absolute);
		}

		internal static void CopyAToZeroPage(byte zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyAToImmediate8Address);
			Compiler.Writer.Write(zeroPage);
		}

		internal static void AddZeroPagePlusCarryToA(byte zeroPage)
		{
			Compiler.Writer.Write((byte)OpCodes.AddImmediate8AddressPlusCarryToA);
			Compiler.Writer.Write(zeroPage);
		}
	}
}