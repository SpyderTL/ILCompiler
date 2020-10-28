using ILCompiler.Platform.Mos6502;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILCompiler.Library.C64
{
	public static class Console
	{
		public static void WriteLine(string name)
		{
			Compiler.Label(name);

			Cpu.CopyAbsoluteToX(0x9C00);

			Compiler.Writer.Write((byte)0xBD);       // LDA $9C01, X
			Compiler.Writer.Write((ushort)0x9C01);

			Compiler.Writer.Write((byte)0x85);       // STA $03
			Compiler.Writer.Write((byte)0x03);

			Compiler.Writer.Write((byte)0xBD);       // LDA $9C02, X
			Compiler.Writer.Write((ushort)0x9C02);

			Compiler.Writer.Write((byte)0x85);       // STA $02
			Compiler.Writer.Write((byte)0x02);

			Compiler.Label(name + "ForEachCharacter");

			Compiler.Writer.Write((byte)0xA0);       // LDY $00
			Compiler.Writer.Write((byte)0x00);

			Compiler.Writer.Write((byte)0xB1);       // LDA ($02), Y
			Compiler.Writer.Write((byte)0x02);

			Compiler.Writer.Write((byte)0xF0);       // BEQ Done
			Compiler.RelativeReference(name + "Done");

			Compiler.Writer.Write((byte)0x20);       // JSR $FFD2
			Compiler.Writer.Write((ushort)0xFFD2);

			Compiler.Writer.Write((byte)0xE6);       // INC $02
			Compiler.Writer.Write((byte)0x02);

			Compiler.Writer.Write((byte)0x4C);       // JMP ForEachCharacter
			Compiler.AbsoluteReference(name + "ForEachCharacter");

			Compiler.Label(name + "Done");

			Compiler.Writer.Write((byte)0xE8);       // INX
			Compiler.Writer.Write((byte)0xE8);       // INX

			Compiler.Writer.Write((byte)0x8E);       // STX $9C00
			Compiler.Writer.Write((ushort)0x9C00);

			Compiler.Writer.Write((byte)0x60);       // RET
		}
	}
}
