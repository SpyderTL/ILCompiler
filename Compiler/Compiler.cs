using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ILCompiler
{
	internal static class Compiler
	{
		internal static MemoryStream Stream = new MemoryStream();
		internal static BinaryWriter Writer = new BinaryWriter(Stream);

		internal static Dictionary<string, long> Labels = new Dictionary<string, long>();
		internal static Dictionary<long, string> AbsoluteReferences = new Dictionary<long, string>();
		internal static Dictionary<long, string> LowReferences = new Dictionary<long, string>();
		internal static Dictionary<long, string> HighReferences = new Dictionary<long, string>();
		internal static Dictionary<long, string> RelativeReferences = new Dictionary<long, string>();

		internal static List<string> Strings = new List<string>();
		internal static int BaseAddress;

		internal static void Reset()
		{
			Stream.Position = 0;
			Stream.SetLength(0);

			Labels.Clear();
			AbsoluteReferences.Clear();
			LowReferences.Clear();
			HighReferences.Clear();
			RelativeReferences.Clear();
			Strings.Clear();
		}

		internal static void Label(string name)
		{
			Labels[name] = Stream.Position;
		}

		internal static void AbsoluteReference(string name)
		{
			AbsoluteReferences[Stream.Position] = name;

			Writer.Write((ushort)0x0000);
		}

		internal static void LowReference(string name)
		{
			LowReferences[Stream.Position] = name;

			Writer.Write((byte)0x00);
		}

		internal static void HighReference(string name)
		{
			HighReferences[Stream.Position] = name;

			Writer.Write((byte)0x00);
		}

		internal static void RelativeReference(string name)
		{
			RelativeReferences[Stream.Position] = name;

			Writer.Write((sbyte)0x00);
		}

		internal static void StringAbsoluteReference(string value)
		{
			if (!Strings.Contains(value))
				Strings.Add(value);

			AbsoluteReferences[Stream.Position] = "String(" + value + ")";

			Writer.Write((ushort)0x0000);
		}

		internal static void StringLowReference(string value)
		{
			if (!Strings.Contains(value))
				Strings.Add(value);

			LowReferences[Stream.Position] = "String(" + value + ")";

			Writer.Write((byte)0x00);
		}

		internal static void StringHighReference(string value)
		{
			if (!Strings.Contains(value))
				Strings.Add(value);

			HighReferences[Stream.Position] = "String(" + value + ")";

			Writer.Write((byte)0x00);
		}

		internal static void UpdateReferences()
		{
			foreach (var reference in AbsoluteReferences)
			{
				Stream.Position = reference.Key;

				Writer.Write((ushort)(BaseAddress + Labels[reference.Value]));
			}

			foreach (var reference in LowReferences)
			{
				Stream.Position = reference.Key;

				Writer.Write((byte)((BaseAddress + Labels[reference.Value]) & 0xff));
			}

			foreach (var reference in HighReferences)
			{
				Stream.Position = reference.Key;

				Writer.Write((byte)((BaseAddress + Labels[reference.Value]) >> 8));
			}

			foreach (var reference in RelativeReferences)
			{
				Stream.Position = reference.Key;

				Writer.Write((sbyte)(Labels[reference.Value] - (reference.Key + 1)));
			}
		}
	}
}
