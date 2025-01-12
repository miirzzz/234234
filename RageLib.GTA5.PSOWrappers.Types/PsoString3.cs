using System;
using RageLib.Data;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoString3 : IPsoValue
{
	public string Value { get; set; }

	public void Read(PsoDataReader reader)
	{
		uint num = reader.ReadUInt32();
		int num2 = (int)(num & 0xFFF);
		int num3 = (int)((num & 0xFFFFF000u) >> 12);
		if (reader.ReadUInt32() != 0)
		{
			throw new Exception("zero_4h should be 0");
		}
		reader.ReadUInt16();
		int num4 = reader.ReadUInt16() & 0xFFF;
		if (reader.ReadUInt32() != 0)
		{
			throw new Exception("zero_Ch should be 0");
		}
		if (num2 > 0)
		{
			int currentSectionIndex = reader.CurrentSectionIndex;
			long position = reader.Position;
			reader.SetSectionIndex(num2 - 1);
			reader.Position = num3;
			string text = "";
			for (int i = 0; i < num4; i++)
			{
				text += (char)reader.ReadByte();
			}
			Value = text;
			reader.SetSectionIndex(currentSectionIndex);
			reader.Position = position;
		}
		else
		{
			Value = null;
		}
	}

	public void Write(DataWriter writer)
	{
	}
}
