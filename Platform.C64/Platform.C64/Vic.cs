namespace Platform.C64
{
	public static class Vic
	{
		unsafe public static byte BorderColor
		{
			set
			{
				*(byte*)Io.VicBorderColor = value;
			}
			get
			{
				return *(byte*)Io.VicBorderColor;
			}
		}

		public static class Color
		{
			public const byte Black = 0;
			public const byte White = 1;
			public const byte Red = 2;
			public const byte Cyan = 3;
			public const byte Purple = 4;
			public const byte Green = 5;
			public const byte Blue = 6;
			public const byte Yellow = 7;
			public const byte Orange = 8;
			public const byte Brown = 9;
			public const byte LightRed = 10;
			public const byte DarkGray = 11;
			public const byte Gray = 12;
			public const byte LightGreen = 13;
			public const byte LightBlue = 14;
			public const byte LightGray = 15;
		}
	}
}
