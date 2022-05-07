namespace Platform.C64
{
	public static class Sid
	{
		public static class Waveform
		{
			public const byte Triangle = 0x10;
			public const byte Sawtooth = 0x20;
			public const byte Pulse = 0x40;
			public const byte Noise = 0x80;
		}

		public static unsafe byte Volume
		{
			get
			{
				return (byte)((*(byte*)(Io.SidBaseAddress + Io.SidVolume)) & 0x0f);
			}
			set
			{
				var volume = *(byte*)Io.SidVolume;

				volume &= 0xf0;
				volume |= value;

				*(byte*)(Io.SidBaseAddress + Io.SidVolume) = volume;
			}
		}
	}
}
