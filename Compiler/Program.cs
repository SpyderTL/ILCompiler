using Mono.Cecil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ILCompiler
{
	class Program
	{
		static void Main(string[] args)
		{
			Arguments.Parse(args);

			ConsoleProgram.Start();
		}
	}
}
