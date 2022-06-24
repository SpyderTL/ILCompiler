using System;
using Platform.C64;

namespace HelloWorld
{
	static class Program
	{
		static int Test = int.MaxValue;

		static void Main()
		{
			while (true)
			{
				Console.WriteLine(Test--);
			}
		}

		//static void Main()
		//{
		//	Console.WriteLine("Waiting For Buffer");

		//	while (true)
		//	{
		//		RRNet.TransmitCommandLow = 0xC0;
		//		RRNet.TransmitCommandHigh = 0x00;

		//		RRNet.TransmitLengthLow = 0x1A;
		//		RRNet.TransmitLengthHigh = 0x01;

		//		RRNet.PacketPagePointerLow = 0x38;
		//		RRNet.PacketPagePointerHigh = 0x01;

		//		var statusLow = RRNet.PacketPageData0Low;
		//		var statusHigh = RRNet.PacketPageData0High;

		//		if ((statusHigh & 0x01) != 0)
		//			break;
		//	}

		//	Console.WriteLine("Sending Packet");

		//	// Ethernet Header

		//	// Destination Physical Address (FF:FF:FF:FF:FF:FF, Broadcast)
		//	RRNet.DataPort0Low = 0xFF;
		//	RRNet.DataPort0High = 0xFF;

		//	RRNet.DataPort0Low = 0xFF;
		//	RRNet.DataPort0High = 0xFF;

		//	RRNet.DataPort0Low = 0xFF;
		//	RRNet.DataPort0High = 0xFF;

		//	// Source Physical Address (28:CD:4C:FF:[high]:[low])
		//	var physicalAddressHigh = RRNet.PhysicalAddressHigh;
		//	var physicalAddressLow = RRNet.PhysicalAddressLow;

		//	RRNet.DataPort0Low = 0x28;
		//	RRNet.DataPort0High = 0xCD;

		//	RRNet.DataPort0Low = 0x4C;
		//	RRNet.DataPort0High = 0xFF;

		//	RRNet.DataPort0Low = physicalAddressHigh;
		//	RRNet.DataPort0High = physicalAddressLow;

		//	// Ethernet Packet Type (0x0800, IPv4)
		//	RRNet.DataPort0Low = 0x08;
		//	RRNet.DataPort0High = 0x00;


		//	// IPv4 Packet Header

		//	// Version/Header Length (0x45)
		//	RRNet.DataPort0Low = 0x45;

		//	// Code Point/Congestion (0x00)
		//	RRNet.DataPort0High = 0x00;

		//	// Total Length (0x010C)
		//	RRNet.DataPort0Low = 0x01;
		//	RRNet.DataPort0High = 0x0C;

		//	// Unique ID
		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	// Flags
		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	// Time To Live (8)
		//	RRNet.DataPort0Low = 0x08;

		//	// Protocol (17, UDP)
		//	RRNet.DataPort0High = 0x11;

		//	// Header Checksum (0x????)
		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	// Source Internet Address (0.0.0.0)
		//	RRNet.DataPort0Low = 0;
		//	RRNet.DataPort0High = 0;
		//	RRNet.DataPort0Low = 0;
		//	RRNet.DataPort0High = 0;

		//	// Destination Internet Address (255.255.255.255, Broadcast)
		//	RRNet.DataPort0Low = 255;
		//	RRNet.DataPort0High = 255;
		//	RRNet.DataPort0Low = 255;
		//	RRNet.DataPort0High = 255;


		//	// UDP Header

		//	// Source Port (68)
		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x44;

		//	// Destination Port (67)
		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x43;

		//	// Length (0x00F8)
		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0xF8;

		//	// Checksum (0x????)
		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;


		//	// DHCP Packet
		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	RRNet.DataPort0Low = 0x00;
		//	RRNet.DataPort0High = 0x00;

		//	Console.WriteLine("Waiting For Packet");

		//	while (true)
		//	{
		//		RRNet.PacketPagePointerLow = 0x24;
		//		RRNet.PacketPagePointerHigh = 0x01;

		//		var statusLow = RRNet.PacketPageData0Low;
		//		var statusHigh = RRNet.PacketPageData0High;

		//		if ((statusHigh & 0x01) != 0)
		//			break;
		//	}

		//	Console.WriteLine("Packet Recieved");
		//}

		//static unsafe void Main()
		//{
		//	var high = RRNet.PhysicalAddressHigh;
		//	var low = RRNet.PhysicalAddressLow;

		//	Console.WriteLine(high);
		//	Console.WriteLine(low);
		//}

		//static unsafe void Main()
		//{
		//	*(byte*)(RRNet.Io.BaseAddress + RRNet.Io.TransmitCommandLow) = 0xC0;
		//	*(byte*)(RRNet.Io.BaseAddress + RRNet.Io.TransmitCommandHigh) = 0x00;
		//	*(byte*)(RRNet.Io.BaseAddress + RRNet.Io.TransmitLengthLow) = 0x51;
		//	*(byte*)(RRNet.Io.BaseAddress + RRNet.Io.TransmitLengthHigh) = 0x00;

		//	*(byte*)(RRNet.Io.BaseAddress + RRNet.Io.PacketPagePointerLow) = 0x38;
		//	*(byte*)(RRNet.Io.BaseAddress + RRNet.Io.PacketPagePointerHigh) = 0x01;

		//	var ready = *(byte*)(RRNet.Io.BaseAddress + RRNet.Io.PacketPageData0Low);
		//	var ready2 = *(byte*)(RRNet.Io.BaseAddress + RRNet.Io.PacketPageData0High);

		//	Console.WriteLine(ready);
		//	Console.WriteLine(ready2);
		//}

		//static void Main()
		//{
		//	var value = 1;

		//	while (true)
		//	{
		//		Console.WriteLine(value);

		//		value <<= 1;
		//	}
		//}

		//static unsafe void Main()
		//{
		//	Cia.ClockHours = 0;
		//	Cia.ClockMinutes = 0;
		//	Cia.ClockSeconds = 0;
		//	Cia.ClockTenths = 0;

		//	while (true)
		//	{
		//		var hours = Cia.ClockHours;
		//		var minutes = Cia.ClockMinutes;
		//		var seconds = Cia.ClockSeconds;
		//		var tenths = Cia.ClockTenths;

		//		var secondsLow = seconds & 0x0f;
		//		var secondsHigh = seconds >> 4;

		//		var minutesLow = minutes & 0x0f;
		//		var minutesHigh = minutes >> 4;

		//		var hoursLow = hours & 0x0f;
		//		var hoursHigh = hours >> 4;

		//		Console.Write(hoursHigh);
		//		Console.Write(hoursLow);
		//		Console.Write(":");
		//		Console.Write(minutesHigh);
		//		Console.Write(minutesLow);
		//		Console.Write(":");
		//		Console.Write(secondsHigh);
		//		Console.Write(secondsLow);
		//		Console.Write(".");
		//		Console.WriteLine(tenths);
		//	}
		//}

		//static void Main()
		//{
		//	Sid.FrequencyHigh0 = 0x10;
		//	Sid.FrequencyLow0 = 0x00;
		//	Sid.AttackDecay0 = 0x00;
		//	Sid.SustainRelease0 = 0x0a;

		//	Sid.Volume = Sid.MaxVolume;

		//	Sid.Control0 = Sid.Waveform.Noise | Sid.Control.Enable;
		//	Sid.Control0 = Sid.Waveform.Noise | Sid.Control.Disable;
		//}

		//static unsafe void Main()
		//{
		//	*(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelFrequencyLow) = 0x00;
		//	*(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelFrequencyHigh) = 0x10;
		//	*(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelAttackDecay) = 0x00;
		//	*(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelSustainRelease) = 0x0a;

		//	*(byte*)(Io.SidBaseAddress + Io.SidVolume) = 0x0f;

		//	*(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelControl) = 0x81;
		//	*(byte*)(Io.SidBaseAddress + Io.SidChannel0 + Io.SidChannelControl) = 0x80;
		//}

		//unsafe static void Main()
		//{
		//	var borderColor = (byte)0;

		//	while (true)
		//	{
		//		*(byte*)(Io.VicBorderColor) = borderColor++;
		//	}
		//}

		//static void Main()
		//{
		//	var value = 0;

		//	while (true)
		//	{
		//		Console.WriteLine(value++);
		//	}
		//}

		//static void Main()
		//{
		//	while (true)
		//	{
		//		Vic.BackgroundColor0++;
		//	}
		//}

		//static void Main()
		//{
		//	while (true)
		//	{
		//		Vic.BorderColor++;
		//	}
		//}

		//unsafe static void Main()
		//{
		//	for (int i = 0; i < 25 * 40; i++)
		//	{
		//		*(char*)(0x400 + i) = (char)24;
		//	}
		//}

		//unsafe static void Main()
		//{
		//	while (true)
		//	{
		//		var x = *(byte*)0x0400;
		//		x++;
		//		(*(byte*)0x0400) = x;
		//	}
		//}

		//static void Main()
		//{
		//	while (true)
		//	{
		//		var x = Console.ReadLine();

		//		Console.WriteLine(x);
		//	}
		//}

		//static void Main()
		//{
		//	while (true)
		//	{
		//		var x = Console.ReadLine();
		//		var y = Console.ReadLine();

		//		var x2 = int.Parse(x);
		//		var y2 = int.Parse(y);

		//		var result = x2 % y2;

		//		Console.WriteLine(result);
		//	}
		//}

		//static void Main()
		//{
		//	while (true)
		//	{
		//		var x = Console.ReadLine();
		//		var y = Console.ReadLine();

		//		var x2 = int.Parse(x);
		//		var y2 = int.Parse(y);

		//		var result = x2 / y2;

		//		Console.WriteLine(result);
		//	}
		//}

		//static void Main()
		//{
		//	while (true)
		//	{
		//		var x = Console.ReadLine();
		//		var y = Console.ReadLine();

		//		var x2 = int.Parse(x);
		//		var y2 = int.Parse(y);

		//		var result = x2 * y2;

		//		Console.WriteLine(result);
		//	}
		//}

		//static void Main()
		//{
		//	while (true)
		//	{
		//		var x = Console.ReadLine();
		//		var y = Console.ReadLine();

		//		var result = x + y;

		//		Console.WriteLine(result.Length);
		//	}
		//}

		//static void Main()
		//{
		//	var x = 0;

		//	while (x <= 1000)
		//	{
		//		Console.WriteLine(x++);
		//	}
		//}

		//static void Main()
		//{
		//	while (true)
		//	{
		//		var x = int.Parse(Console.ReadLine());
		//		var y = int.Parse(Console.ReadLine());

		//		var total = Add(x, y);
		//		Console.WriteLine(total);
		//	}
		//}

		//static int Add(int x, int y)
		//{
		//	return x + y;
		//}

		//static void Main()
		//{
		//	Console.WriteLine("Hello, World!");
		//}

		//static void Main()
		//{
		//	while (true)
		//	{
		//		var x = Console.ReadLine();
		//		var y = Console.ReadLine();
		//		var a = int.Parse(x);
		//		var b = int.Parse(y);
		//		var c = a + b;

		//		Console.WriteLine(c);
		//	}
		//}

		//static void Main()
		//{
		//	while (true)
		//	{
		//		var x = Console.ReadLine();
		//		var y = Console.ReadLine();
		//		var a = int.Parse(x);
		//		var b = int.Parse(y);
		//		var c = a - b;

		//		Console.WriteLine(c);
		//	}
		//}
	}
}
