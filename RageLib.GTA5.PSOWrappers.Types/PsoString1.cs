using System;
using RageLib.Data;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoString1 : IPsoValue
{
	public string Value { get; set; }

	public void Read(PsoDataReader reader)
	{
		int num = reader.ReadInt32();
		if (reader.ReadInt32() != 0)
		{
			throw new Exception("zero_Ch should be 0");
		}
		int num2 = num & 0xFFF;
		int num3 = (int)((num & 0xFFFFF000u) >> 12);
		int currentSectionIndex = reader.CurrentSectionIndex;
		long position = reader.Position;
		reader.SetSectionIndex(num2 - 1);
		reader.Position = num3;
		Value = reader.ReadString();
		reader.SetSectionIndex(currentSectionIndex);
		reader.Position = position;
	}

	public void Write(DataWriter writer)
	{
	}
}
