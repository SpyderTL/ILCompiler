namespace ILCompiler.Platform.C64
{
	internal static class Petscii
	{
		internal const byte NewLine = 0x0D;

		internal static byte[] GetBytes(string value)
		{
			var characters = new byte[value.Length];

			for (var x = 0; x < characters.Length; x++)
			{
				var c = value[x];

				if (c >= 'a' && c <= 'z')
					characters[x] = (byte)(c - 0x61 + 0x41);
				else
					characters[x] = (byte)c;
			}

			return characters;
		}
	}
}