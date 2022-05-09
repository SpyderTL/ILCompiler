using System;
using Platform.C64;

namespace HelloWorld
{
	class Program
	{
		static unsafe void Main()
		{
			*(byte*)(RRNet.BaseAddress + RRNet.TransmitCommandLow) = 0xC0;
			*(byte*)(RRNet.BaseAddress + RRNet.TransmitCommandHigh) = 0x00;
			*(byte*)(RRNet.BaseAddress + RRNet.TransmitLengthLow) = 0x51;
			*(byte*)(RRNet.BaseAddress + RRNet.TransmitLengthHigh) = 0x00;

			*(byte*)(RRNet.BaseAddress + RRNet.PacketPagePointerLow) = 0x38;
			*(byte*)(RRNet.BaseAddress + RRNet.PacketPagePointerHigh) = 0x01;

			var ready = *(byte*)(RRNet.BaseAddress + RRNet.PacketPageData0Low);
			var ready2 = *(byte*)(RRNet.BaseAddress + RRNet.PacketPageData0High);

			Console.WriteLine(ready);
			Console.WriteLine(ready2);
		}

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
