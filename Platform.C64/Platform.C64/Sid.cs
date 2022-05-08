namespace Platform.C64
{
	public static class Sid
	{
		public const byte MaxVolume = 0x0f;

		public static class Waveform
		{
			public const byte Triangle = 0x10;
			public const byte Sawtooth = 0x20;
			public const byte Pulse = 0x40;
			public const byte Noise = 0x80;
		}

		public static class Control
		{
			public const byte Enable = 0x01;
			public const byte Disable = 0x00;
		}

		public static unsafe byte Control0
		{
			get
			{
				return *(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelControl);
			}
			set
			{
				*(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelControl) = value;
			}
		}

		public static unsafe byte FrequencyLow0
		{
			get
			{
				return *(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelFrequencyLow);
			}
			set
			{
				*(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelFrequencyLow) = value;
			}
		}

		public static unsafe byte FrequencyHigh0
		{
			get
			{
				return *(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelFrequencyHigh);
			}
			set
			{
				*(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelFrequencyHigh) = value;
			}
		}

		public static unsafe byte AttackDecay0
		{
			get
			{
				return *(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelAttackDecay);
			}
			set
			{
				*(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelAttackDecay) = value;
			}
		}

		public static unsafe byte SustainRelease0
		{
			get
			{
				return *(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelSustainRelease);
			}
			set
			{
				*(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelSustainRelease) = value;
			}
		}

		public static unsafe byte Waveform0
		{
			get
			{
				return (byte)((*(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelControl)) & 0xf0);
			}
			set
			{
				var waveform = *(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelControl);

				waveform &= 0x0f;
				waveform |= value;

				*(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelControl) = waveform;
			}
		}

		public static unsafe byte Volume
		{
			get
			{
				return (byte)((*(byte*)(Io.SidBaseAddress + Io.SidVolume)) & 0x0f);
			}
			set
			{
				var volume = *(byte*)(Io.SidBaseAddress + Io.SidVolume);

				volume &= 0xf0;
				volume |= value;

				*(byte*)(Io.SidBaseAddress + Io.SidVolume) = volume;
			}
		}
	}
}
