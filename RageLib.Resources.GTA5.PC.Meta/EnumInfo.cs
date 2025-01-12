using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Meta;

public class EnumInfo : ResourceSystemBlock
{
	public ResourceSimpleArray<EnumEntryInfo> Entries;

	public override long Length => 24L;

	public int EnumNameHash { get; set; }

	public int EnumKey { get; set; }

	public long EntriesPointer { get; private set; }

	public int EntriesCount { get; private set; }

	public int Unknown_14h { get; set; }

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		EnumNameHash = reader.ReadInt32();
		EnumKey = reader.ReadInt32();
		EntriesPointer = reader.ReadInt64();
		EntriesCount = reader.ReadInt32();
		Unknown_14h = reader.ReadInt32();
		Entries = reader.ReadBlockAt<ResourceSimpleArray<EnumEntryInfo>>((ulong)EntriesPointer, new object[1] { EntriesCount });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		EntriesPointer = Entries?.Position ?? 0;
		EntriesCount = Entries?.Count ?? 0;
		writer.Write(EnumNameHash);
		writer.Write(EnumKey);
		writer.Write(EntriesPointer);
		writer.Write(EntriesCount);
		writer.Write(Unknown_14h);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Entries != null)
		{
			list.Add(Entries);
		}
		return list.ToArray();
	}
}
