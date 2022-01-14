using System;

namespace HelloWorld
{
	class Program
	{
		unsafe static void Main()
		{
			while (true)
			{
				var borderColor = *(byte*)(0xd020);
				borderColor++;
				*(byte*)(0xd020) = borderColor;
			}
		}

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
		//		Console.WriteLine("Hello, World!");

		//		var x = int.Parse(Console.ReadLine());
		//		var y = int.Parse(Console.ReadLine());

		//		Console.WriteLine(x + y);
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
