using System;

namespace ILCompiler.Platform.C64
{
	internal static class Kernal
	{
		internal const ushort WriteCharacter = 0xFFD2;
		internal const ushort ScanKeyboard = 0xFF9F;
		internal const ushort ReadCharacter = 0xFFE4;
	}
}