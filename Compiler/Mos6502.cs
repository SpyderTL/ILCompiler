using System;
using System.Collections.Generic;
using System.Text;

namespace ILCompiler
{
	public static class Mos6502
	{
		public static OpCode[] OpCodes = new OpCode[]
		{
			new OpCode { Name = "BRK 7        ", Length = 1 },	// 00 
			new OpCode { Name = "ORA izx 6    ", Length = 2 },	// 01 
			new OpCode { Name = "*KIL         ", Length = 1	},	// 02 
			new OpCode { Name = "*SLO izx 8   ", Length = 2 },	// 03 
			new OpCode { Name = "*NOP zp 3    ", Length = 2 },	// 04 
			new OpCode { Name = "ORA zp 3     ", Length = 2 },	// 05 
			new OpCode { Name = "ASL zp 5     ", Length = 2 },	// 06 
			new OpCode { Name = "*SLO zp 5    ", Length = 2 },	// 07 
			new OpCode { Name = "PHP 3        ", Length = 1 },	// 08 
			new OpCode { Name = "ORA imm 2    ", Length = 2 },	// 09 
			new OpCode { Name = "ASL 2        ", Length = 1 },	// 0A 
			new OpCode { Name = "*ANC imm 2   ", Length = 2 },	// 0B 
			new OpCode { Name = "*NOP abs 4   ", Length = 3 },	// 0C 
			new OpCode { Name = "ORA abs 4    ", Length = 3 },	// 0D 
			new OpCode { Name = "ASL abs 6    ", Length = 3 },	// 0E 
			new OpCode { Name = "*SLO abs 6   ", Length = 3 },	// 0F 
			new OpCode { Name = "BPL rel 2*   ", Length = 2 },	// 10 
			new OpCode { Name = "ORA izy 5*   ", Length = 2 },	// 11 
			new OpCode { Name = "*KIL         ", Length = 1	},	// 12 
			new OpCode { Name = "*SLO izy 8   ", Length = 2 },	// 13 
			new OpCode { Name = "*NOP zpx 4   ", Length = 2 },	// 14 
			new OpCode { Name = "ORA zpx 4    ", Length = 2 },	// 15 
			new OpCode { Name = "ASL zpx 6    ", Length = 2 },	// 16 
			new OpCode { Name = "*SLO zpx 6   ", Length = 2 },	// 17 
			new OpCode { Name = "CLC 2        ", Length = 1 },	// 18 
			new OpCode { Name = "ORA aby 4*   ", Length = 3 },	// 19 
			new OpCode { Name = "*NOP 2       ", Length = 1 },	// 1A 
			new OpCode { Name = "*SLO aby 7   ", Length = 3 },	// 1B 
			new OpCode { Name = "*NOP abx 4*  ", Length = 3 },	// 1C 
			new OpCode { Name = "ORA abx 4*   ", Length = 3 },	// 1D 
			new OpCode { Name = "ASL abx 7    ", Length = 3 },	// 1E 
			new OpCode { Name = "*SLO abx 7   ", Length = 3 },	// 1F 
			new OpCode { Name = "JSR abs 6    ", Length = 1 },	// 20 
			new OpCode { Name = "AND izx 6    ", Length = 2 },	// 21 
			new OpCode { Name = "*KIL         ", Length = 1	},	// 22 
			new OpCode { Name = "*RLA izx 8   ", Length = 2 },	// 23 
			new OpCode { Name = "BIT zp 3     ", Length = 2 },	// 24 
			new OpCode { Name = "AND zp 3     ", Length = 2 },	// 25 
			new OpCode { Name = "ROL zp 5     ", Length = 2 },	// 26 
			new OpCode { Name = "*RLA zp 5    ", Length = 2 },	// 27 
			new OpCode { Name = "PLP 4        ", Length = 1 },	// 28 
			new OpCode { Name = "AND imm 2    ", Length = 2 },	// 29 
			new OpCode { Name = "ROL 2        ", Length = 1 },	// 2A 
			new OpCode { Name = "*ANC imm 2   ", Length = 2 },	// 2B 
			new OpCode { Name = "BIT abs 4    ", Length = 3 },	// 2C 
			new OpCode { Name = "AND abs 4    ", Length = 3 },	// 2D 
			new OpCode { Name = "ROL abs 6    ", Length = 3 },	// 2E 
			new OpCode { Name = "*RLA abs 6   ", Length = 3 },	// 2F 
			new OpCode { Name = "BMI rel 2*   ", Length = 2 },	// 30 
			new OpCode { Name = "AND izy 5*   ", Length = 2 },	// 31 
			new OpCode { Name = "*KIL         ", Length = 1	},	// 32 
			new OpCode { Name = "*RLA izy 8   ", Length = 2 },	// 33 
			new OpCode { Name = "*NOP zpx 4   ", Length = 2 },	// 34 
			new OpCode { Name = "AND zpx 4    ", Length = 2 },	// 35 
			new OpCode { Name = "ROL zpx 6    ", Length = 2 },	// 36 
			new OpCode { Name = "*RLA zpx 6   ", Length = 2 },	// 37 
			new OpCode { Name = "SEC 2        ", Length = 1 },	// 38 
			new OpCode { Name = "AND aby 4*   ", Length = 3 },	// 39 
			new OpCode { Name = "*NOP 2       ", Length = 1 },	// 3A 
			new OpCode { Name = "*RLA aby 7   ", Length = 3 },	// 3B 
			new OpCode { Name = "*NOP abx 4*  ", Length = 3 },	// 3C 
			new OpCode { Name = "AND abx 4*   ", Length = 3 },	// 3D 
			new OpCode { Name = "ROL abx 7    ", Length = 3 },	// 3E 
			new OpCode { Name = "*RLA abx 7   ", Length = 3 },	// 3F 
			new OpCode { Name = "RTI 6        ", Length = 1 },	// 40 
			new OpCode { Name = "EOR izx 6    ", Length = 2 },	// 41 
			new OpCode { Name = "*KIL         ", Length = 1	},	// 42 
			new OpCode { Name = "*SRE izx 8   ", Length = 2 },	// 43 
			new OpCode { Name = "*NOP zp 3    ", Length = 2 },	// 44 
			new OpCode { Name = "EOR zp 3     ", Length = 2 },	// 45 
			new OpCode { Name = "LSR zp 5     ", Length = 2 },	// 46 
			new OpCode { Name = "*SRE zp 5    ", Length = 2 },	// 47 
			new OpCode { Name = "PHA 3        ", Length = 1 },	// 48 
			new OpCode { Name = "EOR imm 2    ", Length = 2 },	// 49 
			new OpCode { Name = "LSR 2        ", Length = 1 },	// 4A 
			new OpCode { Name = "*ALR imm 2   ", Length = 2 },	// 4B 
			new OpCode { Name = "JMP abs 3    ", Length = 1 },	// 4C 
			new OpCode { Name = "EOR abs 4    ", Length = 3 },	// 4D 
			new OpCode { Name = "LSR abs 6    ", Length = 3 },	// 4E 
			new OpCode { Name = "*SRE abs 6   ", Length = 3 },	// 4F 
			new OpCode { Name = "BVC rel 2*   ", Length = 2 },	// 50 
			new OpCode { Name = "EOR izy 5*   ", Length = 2 },	// 51 
			new OpCode { Name = "*KIL         ", Length = 1	},	// 52 
			new OpCode { Name = "*SRE izy 8   ", Length = 2 },	// 53 
			new OpCode { Name = "*NOP zpx 4   ", Length = 2 },	// 54 
			new OpCode { Name = "EOR zpx 4    ", Length = 2 },	// 55 
			new OpCode { Name = "LSR zpx 6    ", Length = 2 },	// 56 
			new OpCode { Name = "*SRE zpx 6   ", Length = 2 },	// 57 
			new OpCode { Name = "CLI 2        ", Length = 1 },	// 58 
			new OpCode { Name = "EOR aby 4*   ", Length = 3 },	// 59 
			new OpCode { Name = "*NOP 2       ", Length = 1 },	// 5A 
			new OpCode { Name = "*SRE aby 7   ", Length = 3 },	// 5B 
			new OpCode { Name = "*NOP abx 4*  ", Length = 3 },	// 5C 
			new OpCode { Name = "EOR abx 4*   ", Length = 3 },	// 5D 
			new OpCode { Name = "LSR abx 7    ", Length = 3 },	// 5E 
			new OpCode { Name = "*SRE abx 7   ", Length = 3 },	// 5F 
			new OpCode { Name = "RTS 6        ", Length = 1 },	// 60 
			new OpCode { Name = "ADC izx 6    ", Length = 2 },	// 61 
			new OpCode { Name = "*KIL         ", Length = 1	},	// 62 
			new OpCode { Name = "*RRA izx 8   ", Length = 2 },	// 63 
			new OpCode { Name = "*NOP zp 3    ", Length = 2 },	// 64 
			new OpCode { Name = "ADC zp 3     ", Length = 2 },	// 65 
			new OpCode { Name = "ROR zp 5     ", Length = 2 },	// 66 
			new OpCode { Name = "*RRA zp 5    ", Length = 2 },	// 67 
			new OpCode { Name = "PLA 4        ", Length = 1 },	// 68 
			new OpCode { Name = "ADC imm 2    ", Length = 2 },	// 69 
			new OpCode { Name = "ROR 2        ", Length = 1 },	// 6A 
			new OpCode { Name = "*ARR imm 2   ", Length = 2 },	// 6B 
			new OpCode { Name = "JMP ind 5    ", Length = 1 },	// 6C 
			new OpCode { Name = "ADC abs 4    ", Length = 3 },	// 6D 
			new OpCode { Name = "ROR abs 6    ", Length = 3 },	// 6E 
			new OpCode { Name = "*RRA abs 6   ", Length = 3 },	// 6F 
			new OpCode { Name = "BVS rel 2*   ", Length = 2 },	// 70 
			new OpCode { Name = "ADC izy 5*   ", Length = 2 },	// 71 
			new OpCode { Name = "*KIL         ", Length = 1	},	// 72 
			new OpCode { Name = "*RRA izy 8   ", Length = 2 },	// 73 
			new OpCode { Name = "*NOP zpx 4   ", Length = 2 },	// 74 
			new OpCode { Name = "ADC zpx 4    ", Length = 2 },	// 75 
			new OpCode { Name = "ROR zpx 6    ", Length = 2 },	// 76 
			new OpCode { Name = "*RRA zpx 6   ", Length = 2 },	// 77 
			new OpCode { Name = "SEI 2        ", Length = 1 },	// 78 
			new OpCode { Name = "ADC aby 4*   ", Length = 3 },	// 79 
			new OpCode { Name = "*NOP 2       ", Length = 1 },	// 7A 
			new OpCode { Name = "*RRA aby 7   ", Length = 3 },	// 7B 
			new OpCode { Name = "*NOP abx 4*  ", Length = 3 },	// 7C 
			new OpCode { Name = "ADC abx 4*   ", Length = 3 },	// 7D 
			new OpCode { Name = "ROR abx 7    ", Length = 3 },	// 7E 
			new OpCode { Name = "*RRA abx 7   ", Length = 3 },	// 7F 
			new OpCode { Name = "*NOP imm 2   ", Length = 2 },	// 80 
			new OpCode { Name = "STA izx 6    ", Length = 2 },	// 81 
			new OpCode { Name = "*NOP imm 2   ", Length = 2 },	// 82 
			new OpCode { Name = "*SAX izx 6   ", Length = 2 },	// 83 
			new OpCode { Name = "STY zp 3     ", Length = 2 },	// 84 
			new OpCode { Name = "STA zp 3     ", Length = 2 },	// 85 
			new OpCode { Name = "STX zp 3     ", Length = 2 },	// 86 
			new OpCode { Name = "*SAX zp 3    ", Length = 2 },	// 87 
			new OpCode { Name = "DEY 2        ", Length = 1 },	// 88 
			new OpCode { Name = "*NOP imm 2   ", Length = 2 },	// 89 
			new OpCode { Name = "TXA 2        ", Length = 1 },	// 8A 
			new OpCode { Name = "*XAA imm 2   ", Length = 2 },	// 8B 
			new OpCode { Name = "STY abs 4    ", Length = 3 },	// 8C 
			new OpCode { Name = "STA abs 4    ", Length = 3 },	// 8D 
			new OpCode { Name = "STX abs 4    ", Length = 3 },	// 8E 
			new OpCode { Name = "*SAX abs 4   ", Length = 3 },	// 8F 
			new OpCode { Name = "BCC rel 2*   ", Length = 2 },	// 90 
			new OpCode { Name = "STA izy 6    ", Length = 2 },	// 91 
			new OpCode { Name = "*KIL         ", Length = 1	},	// 92 
			new OpCode { Name = "*AHX izy 6   ", Length = 2 },	// 93 
			new OpCode { Name = "STY zpx 4    ", Length = 2 },	// 94 
			new OpCode { Name = "STA zpx 4    ", Length = 2 },	// 95 
			new OpCode { Name = "STX zpy 4    ", Length = 2 },	// 96 
			new OpCode { Name = "*SAX zpy 4   ", Length = 2 },	// 97 
			new OpCode { Name = "TYA 2        ", Length = 1 },	// 98 
			new OpCode { Name = "STA aby 5    ", Length = 3 },	// 99 
			new OpCode { Name = "TXS 2        ", Length = 1 },	// 9A 
			new OpCode { Name = "*TAS aby 5   ", Length = 1 },	// 9B 
			new OpCode { Name = "*SHY abx 5   ", Length = 3 },	// 9C 
			new OpCode { Name = "STA abx 5    ", Length = 3 },	// 9D 
			new OpCode { Name = "*SHX aby 5   ", Length = 3 },	// 9E 
			new OpCode { Name = "*AHX aby 5   ", Length = 3 },	// 9F 
			new OpCode { Name = "LDY imm 2    ", Length = 2 },	// A0 
			new OpCode { Name = "LDA izx 6    ", Length = 2 },	// A1 
			new OpCode { Name = "LDX imm 2    ", Length = 2 },	// A2 
			new OpCode { Name = "*LAX izx 6   ", Length = 2 },	// A3 
			new OpCode { Name = "LDY zp 3     ", Length = 2 },	// A4 
			new OpCode { Name = "LDA zp 3     ", Length = 2 },	// A5 
			new OpCode { Name = "LDX zp 3     ", Length = 2 },	// A6 
			new OpCode { Name = "*LAX zp 3    ", Length = 2 },	// A7 
			new OpCode { Name = "TAY 2        ", Length = 1 },	// A8 
			new OpCode { Name = "LDA imm 2    ", Length = 2 },	// A9 
			new OpCode { Name = "TAX 2        ", Length = 1 },	// AA 
			new OpCode { Name = "*LAX imm 2   ", Length = 2 },	// AB 
			new OpCode { Name = "LDY abs 4    ", Length = 3 },	// AC 
			new OpCode { Name = "LDA abs 4    ", Length = 3 },	// AD 
			new OpCode { Name = "LDX abs 4    ", Length = 3 },	// AE 
			new OpCode { Name = "*LAX abs 4   ", Length = 3 },	// AF 
			new OpCode { Name = "BCS rel 2*   ", Length = 2 },	// B0 
			new OpCode { Name = "LDA izy 5*   ", Length = 2 },	// B1 
			new OpCode { Name = "*KIL         ", Length = 1	},	// B2 
			new OpCode { Name = "*LAX izy 5*  ", Length = 2 },	// B3 
			new OpCode { Name = "LDY zpx 4    ", Length = 2 },	// B4 
			new OpCode { Name = "LDA zpx 4    ", Length = 2 },	// B5 
			new OpCode { Name = "LDX zpy 4    ", Length = 2 },	// B6 
			new OpCode { Name = "*LAX zpy 4   ", Length = 2 },	// B7 
			new OpCode { Name = "CLV 2        ", Length = 1 },	// B8 
			new OpCode { Name = "LDA aby 4*   ", Length = 3 },	// B9 
			new OpCode { Name = "TSX 2        ", Length = 1 },	// BA 
			new OpCode { Name = "*LAS aby 4*  ", Length = 3 },	// BB 
			new OpCode { Name = "LDY abx 4*   ", Length = 3 },	// BC 
			new OpCode { Name = "LDA abx 4*   ", Length = 3 },	// BD 
			new OpCode { Name = "LDX aby 4*   ", Length = 3 },	// BE 
			new OpCode { Name = "*LAX aby 4*  ", Length = 3 },	// BF 
			new OpCode { Name = "CPY imm 2    ", Length = 2 },	// C0 
			new OpCode { Name = "CMP izx 6    ", Length = 2 },	// C1 
			new OpCode { Name = "*NOP imm 2   ", Length = 2 },	// C2 
			new OpCode { Name = "*DCP izx 8   ", Length = 2 },	// C3 
			new OpCode { Name = "CPY zp 3     ", Length = 2 },	// C4 
			new OpCode { Name = "CMP zp 3     ", Length = 2 },	// C5 
			new OpCode { Name = "DEC zp 5     ", Length = 2 },	// C6 
			new OpCode { Name = "*DCP zp 5    ", Length = 2 },	// C7 
			new OpCode { Name = "INY 2        ", Length = 1 },	// C8 
			new OpCode { Name = "CMP imm 2    ", Length = 2 },	// C9 
			new OpCode { Name = "DEX 2        ", Length = 1 },	// CA 
			new OpCode { Name = "*AXS imm 2   ", Length = 2 },	// CB 
			new OpCode { Name = "CPY abs 4    ", Length = 3 },	// CC 
			new OpCode { Name = "CMP abs 4    ", Length = 3 },	// CD 
			new OpCode { Name = "DEC abs 6    ", Length = 3 },	// CE 
			new OpCode { Name = "*DCP abs 6   ", Length = 3 },	// CF 
			new OpCode { Name = "BNE rel 2*   ", Length = 2 },	// D0 
			new OpCode { Name = "CMP izy 5*   ", Length = 2 },	// D1 
			new OpCode { Name = "*KIL         ", Length = 1	},	// D2 
			new OpCode { Name = "*DCP izy 8   ", Length = 2 },	// D3 
			new OpCode { Name = "*NOP zpx 4   ", Length = 2 },	// D4 
			new OpCode { Name = "CMP zpx 4    ", Length = 2 },	// D5 
			new OpCode { Name = "DEC zpx 6    ", Length = 2 },	// D6 
			new OpCode { Name = "*DCP zpx 6   ", Length = 2 },	// D7 
			new OpCode { Name = "CLD 2        ", Length = 1 },	// D8 
			new OpCode { Name = "CMP aby 4*   ", Length = 3 },	// D9 
			new OpCode { Name = "*NOP 2       ", Length = 1 },	// DA 
			new OpCode { Name = "*DCP aby 7   ", Length = 3 },	// DB 
			new OpCode { Name = "*NOP abx 4*  ", Length = 3 },	// DC 
			new OpCode { Name = "CMP abx 4*   ", Length = 3 },	// DD 
			new OpCode { Name = "DEC abx 7    ", Length = 3 },	// DE 
			new OpCode { Name = "*DCP abx 7   ", Length = 3 },	// DF 
			new OpCode { Name = "CPX imm 2    ", Length = 2 },	// E0 
			new OpCode { Name = "SBC izx 6    ", Length = 2 },	// E1 
			new OpCode { Name = "*NOP imm 2   ", Length = 2 },	// E2 
			new OpCode { Name = "*ISC izx 8   ", Length = 2 },	// E3 
			new OpCode { Name = "CPX zp 3     ", Length = 2 },	// E4 
			new OpCode { Name = "SBC zp 3     ", Length = 2 },	// E5 
			new OpCode { Name = "INC zp 5     ", Length = 2 },	// E6 
			new OpCode { Name = "*ISC zp 5    ", Length = 2 },	// E7 
			new OpCode { Name = "INX 2        ", Length = 1 },	// E8 
			new OpCode { Name = "SBC imm 2    ", Length = 2 },	// E9 
			new OpCode { Name = "NOP 2        ", Length = 1 },	// EA 
			new OpCode { Name = "*SBC imm 2   ", Length = 2 },	// EB 
			new OpCode { Name = "CPX abs 4    ", Length = 3 },	// EC 
			new OpCode { Name = "SBC abs 4    ", Length = 3 },	// ED 
			new OpCode { Name = "INC abs 6    ", Length = 3 },	// EE 
			new OpCode { Name = "*ISC abs 6   ", Length = 3 },	// EF 
			new OpCode { Name = "BEQ rel 2*   ", Length = 2 },	// F0 
			new OpCode { Name = "SBC izy 5*   ", Length = 2 },	// F1 
			new OpCode { Name = "*KIL         ", Length = 1	},	// F2 
			new OpCode { Name = "*ISC izy 8   ", Length = 2 },	// F3 
			new OpCode { Name = "*NOP zpx 4   ", Length = 2 },	// F4 
			new OpCode { Name = "SBC zpx 4    ", Length = 2 },	// F5 
			new OpCode { Name = "INC zpx 6    ", Length = 2 },	// F6 
			new OpCode { Name = "*ISC zpx 6   ", Length = 2 },	// F7 
			new OpCode { Name = "SED 2        ", Length = 1 },	// F8 
			new OpCode { Name = "SBC aby 4*   ", Length = 3 },	// F9 
			new OpCode { Name = "*NOP 2       ", Length = 1 },	// FA 
			new OpCode { Name = "*ISC aby 7   ", Length = 3 },	// FB 
			new OpCode { Name = "*NOP abx 4*  ", Length = 3 },	// FC 
			new OpCode { Name = "SBC abx 4*   ", Length = 3 },	// FD 
			new OpCode { Name = "INC abx 7    ", Length = 3 },	// FE 
			new OpCode { Name = "*ISC abx     ", Length = 3 },	// FF 
		};

		public struct OpCode
		{
			public string Name;
			public int Length;
		}

		public enum Codes
		{

		}
	}
}
