using System;
using System.Collections.Generic;
using RageLib.Data;
using RageLib.GTA5.PSO;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoArray0 : IPsoValue
{
	public readonly PsoFile pso;

	public readonly PsoStructureInfo structureInfo;

	public readonly PsoStructureEntryInfo entryInfo;

	public List<IPsoValue> Entries { get; set; }

	public PsoArray0(PsoFile pso, PsoStructureInfo structureInfo, PsoStructureEntryInfo entryInfo)
	{
		this.pso = pso;
		this.structureInfo = structureInfo;
		this.entryInfo = entryInfo;
	}

	public void Read(PsoDataReader reader)
	{
		uint num = reader.ReadUInt32();
		int num2 = (int)(num & 0xFFF);
		int num3 = (int)((num & 0xFFFFF000u) >> 12);
		if (reader.ReadUInt32() != 0)
		{
			throw new Exception("zero_4h should be 0");
		}
		ushort num4 = reader.ReadUInt16();
		ushort num5 = reader.ReadUInt16();
		if (num4 != num5)
		{
			throw new Exception("size1 should be size2");
		}
		ushort num6 = num4;
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
			Entries = new List<IPsoValue>();
			for (int i = 0; i < num6; i++)
			{
				IPsoValue psoValue = PsoTypeBuilder.Make(pso, structureInfo, entryInfo);
				psoValue.Read(reader);
				Entries.Add(psoValue);
			}
			reader.SetSectionIndex(currentSectionIndex);
			reader.Position = position;
		}
		else
		{
			Entries = null;
		}
	}

	public void Write(DataWriter writer)
	{
	}
}
