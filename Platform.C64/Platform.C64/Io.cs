using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.C64
{
	public static class Io
	{

		public const ushort CpuPortDirection = 0x0000;
		public const ushort CpuPortData = 0x0001;

		public const ushort VicSpriteCoordinateBase = 0xd000;
		public const ushort VicSpriteXCoordinateHigh = 0xd010;
		public const ushort VicControl0 = 0xd011;
		public const ushort VicRaster = 0xd012;
		public const ushort VicLightPenX = 0xd013;
		public const ushort VicLightPenY = 0xd014;
		public const ushort VicSpriteEnable = 0xd015;
		public const ushort VicControl1 = 0xd016;
		public const ushort VicSpriteHeight = 0xd017;
		public const ushort VicMemory = 0xd018;
		public const ushort VicInterruptStatus = 0xd019;
		public const ushort VicInterruptEnable = 0xd01a;
		public const ushort VicSpritePriority = 0xd01b;
		public const ushort VicSpriteMulticolor = 0xd01c;
		public const ushort VicSpriteWidth = 0xd01d;
		public const ushort VicSpriteCollision = 0xd01e;
		public const ushort VicSpriteDataCollision = 0xd01f;
		public const ushort VicBorderColor = 0xd020;
		public const ushort VicBackgroundColor0 = 0xd021;
		public const ushort VicBackgroundColor1 = 0xd022;
		public const ushort VicBackgroundColor2 = 0xd023;
		public const ushort VicBackgroundColor3 = 0xd024;
		public const ushort VicSpriteMulticolor0 = 0xd025;
		public const ushort VicSpriteMulticolor1 = 0xd026;
		public const ushort VicSpriteColorBase = 0xd027;

		public const ushort SidBaseAddress = 0xd400;

		public const ushort SidChannel0 = 0x0000;
		public const ushort SidChannel1 = 0x0007;
		public const ushort SidChannel2 = 0x000e;

		public const ushort SidChannelFrequencyLow = 0x0000;
		public const ushort SidChannelFrequencyHigh = 0x0001;
		public const ushort SidChannelPulseDutyLow = 0x0002;
		public const ushort SidChannelPulseDutyHigh = 0x0003;
		public const ushort SidChannelControl = 0x0004;
		public const ushort SidChannelAttackDecay = 0x0005;
		public const ushort SidChannelSustainRelease = 0x0006;

		public const ushort SidFilterCutoffLow = 0x0015;
		public const ushort SidFilterCutoffHigh = 0x0016;
		public const ushort SidFilterResonance = 0x0017;
		public const ushort SidVolume = 0x0018;

		public const ushort SidPaddleX = 0x0019;
		public const ushort SidPaddleY = 0x001a;
		public const ushort SidChannel2Oscillator = 0x001b;
		public const ushort SidChannel2Envelope = 0x001c;

		public const ushort Cia0BaseAddress = 0xdc00;
		public const ushort Cia1BaseAddress = 0xdd00;

		public const ushort CiaPort0Data = 0x0000;
		public const ushort CiaPort1Data = 0x0001;
		public const ushort CiaPort0Direction = 0x0002;
		public const ushort CiaPort1Direction = 0x0003;
		public const ushort CiaTimer0Low = 0x0004;
		public const ushort CiaTimer0High = 0x0005;
		public const ushort CiaTimer1Low = 0x0006;
		public const ushort CiaTimer1High = 0x0007;
		public const ushort CiaClockTenths = 0x0008;
		public const ushort CiaClockSeconds = 0x0009;
		public const ushort CiaClockMinutes = 0x000a;
		public const ushort CiaClockHours = 0x000b;
		public const ushort CiaSerialShift = 0x000c;
		public const ushort CiaInterrupt = 0x000d;
		public const ushort CiaTimer0Control = 0x000e;
		public const ushort CiaTimer1Control = 0x000f;
	}
}
