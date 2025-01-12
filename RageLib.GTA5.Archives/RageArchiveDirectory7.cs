using System;
using System.Collections.Generic;
using RageLib.Data;

namespace RageLib.GTA5.Archives;

public class RageArchiveDirectory7 : IRageArchiveEntry7
{
	public List<RageArchiveDirectory7> Directories = new List<RageArchiveDirectory7>();

	public List<IRageArchiveEntry7> Files = new List<IRageArchiveEntry7>();

	public uint NameOffset { get; set; }

	public uint EntriesIndex { get; set; }

	public uint EntriesCount { get; set; }

	public string Name { get; set; }

	public void Read(DataReader reader)
	{
		NameOffset = reader.ReadUInt32();
		if (reader.ReadUInt32() != 2147483392)
		{
			throw new Exception("Error in RPF7 directory entry.");
		}
		EntriesIndex = reader.ReadUInt32();
		EntriesCount = reader.ReadUInt32();
	}

	public void Write(DataWriter writer)
	{
		writer.Write(NameOffset);
		writer.Write(2147483392u);
		writer.Write(EntriesIndex);
		writer.Write(EntriesCount);
	}
}
