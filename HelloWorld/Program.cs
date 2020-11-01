using System;

namespace HelloWorld
{
	class Program
	{
		static void Main()
		{
			while (true)
			{
				//Console.WriteLine("Hello, World!");

				//var x = int.Parse(Console.ReadLine());
				//var y = int.Parse(Console.ReadLine());

				//Console.WriteLine(x + y);


				var x = Console.ReadLine();
				var y = Console.ReadLine();
				var a = int.Parse(x);
				var b = int.Parse(y);
				var c = a + b;

				Console.WriteLine(c);
			}
		}
	}
}
