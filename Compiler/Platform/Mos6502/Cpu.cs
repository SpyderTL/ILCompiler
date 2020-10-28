using System;
using System.Collections.Generic;
using System.Text;

namespace ILCompiler.Platform.Mos6502
{
	public static class Cpu
	{
		public static void NoOperation()
		{
			Compiler.Writer.Write((byte)0);
		}

		internal static void CopyAbsoluteToX(ushort address)
		{
			Compiler.Writer.Write((byte)OpCodes.CopyImmediate16AddressToX);
			Compiler.Writer.Write(address);
		}
	}
}
