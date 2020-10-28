using System;
using System.IO;

namespace ILCompiler
{
	internal class Arguments
	{
		internal static string Source;
		internal static string Destination;

		internal static void Parse(string[] args)
		{
			if (args.Length > 0)
				Source = args[0];

			if (args.Length > 1)
				Destination = args[1];
			else
				Destination = Path.ChangeExtension(args[0], ".prg");
		}
	}
}