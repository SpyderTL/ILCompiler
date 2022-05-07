using System;
using Platform.C64;

namespace HelloWorld
{
	class Program
	{
		unsafe static void Main()
		{
			while (true)
			{
				Vic.BorderColor = Vic.Color.Red;
			}
		}

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

		//	while (true)
		//	{
		//		Console.WriteLine(x);

		//		x++;
		//	}
		//}

		//static void Main()
		//{
		//	while (true)
		//	{
		//		var x = int.Parse(Console.ReadLine());
		//		var y = int.Parse(Console.ReadLine());

		//		var total = x + y;
		//		Console.WriteLine(total);
		//	}
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
