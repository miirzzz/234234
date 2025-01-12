using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.WaypointRecords;

public class WaypointRecord : FileBase64_GTA5_pc
{
	public uint Unknown_10h;

	public uint Unknown_14h;

	public ulong EntriesPointer;

	public uint EntriesCount;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public ResourceSimpleArray<WaypointRecordEntry> Entries;

	public override long Length => 48L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		EntriesPointer = reader.ReadUInt64();
		EntriesCount = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		Entries = reader.ReadBlockAt<ResourceSimpleArray<WaypointRecordEntry>>(EntriesPointer, new object[1] { EntriesCount });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		EntriesPointer = (ulong)(Entries?.Position ?? 0);
		EntriesCount = (uint)(Entries?.Count ?? 0);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(EntriesPointer);
		writer.Write(EntriesCount);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (Entries != null)
		{
			list.Add(Entries);
		}
		return list.ToArray();
	}
}
