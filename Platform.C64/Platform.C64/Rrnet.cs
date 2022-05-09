namespace Platform.C64
{
	public static class RRNet
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
