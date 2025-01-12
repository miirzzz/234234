using System;
using RageLib.Data;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoString0 : IPsoValue
{
	private readonly int length;

	public string Value { get; set; }

	public PsoString0(int length)
	{
		this.length = length;
	}

	public void Read(PsoDataReader reader)
	{
		Value = "";
		bool flag = true;
		for (int i = 0; i < length; i++)
		{
			char c = (char)reader.ReadByte();
			if (c == '\0')
			{
				flag = false;
				continue;
			}
			if (!flag)
			{
				throw new Exception("Unexpected char.");
			}
			Value += c;
		}
	}

	public void Write(DataWriter writer)
	{
	}
}
