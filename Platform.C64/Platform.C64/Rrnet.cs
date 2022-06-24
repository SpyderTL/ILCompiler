namespace Platform.C64
{
	public static class RRNet
	{
		public static unsafe byte TransmitCommandLow
		{
			set
			{
				*(byte*)(Io.BaseAddress + Io.TransmitCommandLow) = value;
			}
		}

		public static unsafe byte TransmitCommandHigh
		{
			set
			{
				*(byte*)(Io.BaseAddress + Io.TransmitCommandHigh) = value;
			}
		}

		public static unsafe byte TransmitLengthLow
		{
			set
			{
				*(byte*)(Io.BaseAddress + Io.TransmitLengthLow) = value;
			}
		}

		public static unsafe byte TransmitLengthHigh
		{
			set
			{
				*(byte*)(Io.BaseAddress + Io.TransmitLengthHigh) = value;
			}
		}

		public static unsafe byte DataPort0Low
		{
			set
			{
				*(byte*)(Io.BaseAddress + Io.DataPort0Low) = value;
			}
			get
			{
				return *(byte*)(Io.BaseAddress + Io.DataPort0Low);
			}
		}

		public static unsafe byte DataPort0High
		{
			set
			{
				*(byte*)(Io.BaseAddress + Io.DataPort0High) = value;
			}
			get
			{
				return *(byte*)(Io.BaseAddress + Io.DataPort0High);
			}
		}

		public static unsafe byte DataPort1Low
		{
			set
			{
				*(byte*)(Io.BaseAddress + Io.DataPort1Low) = value;
			}
			get
			{
				return *(byte*)(Io.BaseAddress + Io.DataPort1Low);
			}
		}

		public static unsafe byte DataPort1High
		{
			set
			{
				*(byte*)(Io.BaseAddress + Io.DataPort1High) = value;
			}
			get
			{
				return *(byte*)(Io.BaseAddress + Io.DataPort1High);
			}
		}

		public static unsafe byte PacketPagePointerLow
		{
			set
			{
				*(byte*)(Io.BaseAddress + Io.PacketPagePointerLow) = value;
			}
			get
			{
				return *(byte*)(Io.BaseAddress + Io.PacketPagePointerLow);
			}
		}

		public static unsafe byte PacketPagePointerHigh
		{
			set
			{
				*(byte*)(Io.BaseAddress + Io.PacketPagePointerHigh) = value;
			}
			get
			{
				return *(byte*)(Io.BaseAddress + Io.PacketPagePointerHigh);
			}
		}

		public static unsafe byte PacketPageData0Low
		{
			set
			{
				*(byte*)(Io.BaseAddress + Io.PacketPageData0Low) = value;
			}
			get
			{
				return *(byte*)(Io.BaseAddress + Io.PacketPageData0Low);
			}
		}

		public static unsafe byte PacketPageData0High
		{
			set
			{
				*(byte*)(Io.BaseAddress + Io.PacketPageData0High) = value;
			}
			get
			{
				return *(byte*)(Io.BaseAddress + Io.PacketPageData0High);
			}
		}

		public static unsafe byte PacketPageData1Low
		{
			set
			{
				*(byte*)(Io.BaseAddress + Io.PacketPageData1Low) = value;
			}
			get
			{
				return *(byte*)(Io.BaseAddress + Io.PacketPageData1Low);
			}
		}

		public static unsafe byte PacketPageData1High
		{
			set
			{
				*(byte*)(Io.BaseAddress + Io.PacketPageData1High) = value;
			}
			get
			{
				return *(byte*)(Io.BaseAddress + Io.PacketPageData1High);
			}
		}

		public static unsafe byte PhysicalAddressHigh
		{
			get
			{
				return *(byte*)(Io.BaseAddress + Io.TransmitCommandLow);
			}
		}

		public static unsafe byte PhysicalAddressLow
		{
			get
			{
				return *(byte*)(Io.BaseAddress + Io.TransmitCommandHigh);
			}
		}

		public static unsafe byte Checksum0
		{
			get
			{
				return *(byte*)(Io.BaseAddress + Io.TransmitLengthLow);
			}
		}

		public static unsafe byte Checksum1
		{
			get
			{
				return *(byte*)(Io.BaseAddress + Io.TransmitLengthHigh);
			}
		}

		public static class Io
		{
			public const ushort BaseAddress = 0xde00;
			public const ushort PacketPagePointerLow = 0x02;
			public const ushort PacketPagePointerHigh = 0x03;
			public const ushort PacketPageData0Low = 0x04;
			public const ushort PacketPageData0High = 0x05;
			public const ushort PacketPageData1Low = 0x06;
			public const ushort PacketPageData1High = 0x07;
			public const ushort DataPort0Low = 0x08;
			public const ushort DataPort0High = 0x09;
			public const ushort DataPort1Low = 0x0a;
			public const ushort DataPort1High = 0x0b;
			public const ushort TransmitCommandLow = 0x0c;
			public const ushort TransmitCommandHigh = 0x0d;
			public const ushort TransmitLengthLow = 0x0e;
			public const ushort TransmitLengthHigh = 0x0f;

			public static class PacketPage
			{
				public const ushort ManufacturerId = 0x0000;
				public const ushort ProductId = 0x0002;
				public const ushort BusStatus = 0x0138;
			}
		}
	}
}
