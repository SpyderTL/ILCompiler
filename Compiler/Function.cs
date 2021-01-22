using System;
using System.Collections.Generic;
using System.Text;

namespace ILCompiler
{
	public static class Function
	{
		public static string Name;

		public static string Label(string name)
		{
			return Name + ":" + name;
		}
	}
}
