namespace Platform.C64
{
	public static class Cia
	{
		unsafe public static byte ClockHours
		{
			set
			{
				*(byte*)(Io.Cia0BaseAddress + Io.CiaClockHours) = value;
			}
			get
			{
				return *(byte*)(Io.Cia0BaseAddress + Io.CiaClockHours);
			}
		}

		unsafe public static byte ClockMinutes
		{
			set
			{
				*(byte*)(Io.Cia0BaseAddress + Io.CiaClockMinutes) = value;
			}
			get
			{
				return *(byte*)(Io.Cia0BaseAddress + Io.CiaClockMinutes);
			}
		}

		unsafe public static byte ClockSeconds
		{
			set
			{
				*(byte*)(Io.Cia0BaseAddress + Io.CiaClockSeconds) = value;
			}
			get
			{
				return *(byte*)(Io.Cia0BaseAddress + Io.CiaClockSeconds);
			}
		}

		unsafe public static byte ClockTenths
		{
			set
			{
				*(byte*)(Io.Cia0BaseAddress + Io.CiaClockTenths) = value;
			}
			get
			{
				return *(byte*)(Io.Cia0BaseAddress + Io.CiaClockTenths);
			}
		}
	}
}
