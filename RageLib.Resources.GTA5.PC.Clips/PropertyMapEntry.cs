using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Clips;

public class PropertyMapEntry : ResourceSystemBlock
{
	public uint DataNameHash;

	public uint Unknown_4h;

	public ulong DataPointer;

	public ulong NextPointer;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public Property Data;

	public PropertyMapEntry Next;

	public override long Length => 32L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		DataNameHash = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		DataPointer = reader.ReadUInt64();
		NextPointer = reader.ReadUInt64();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		Data = reader.ReadBlockAt<Property>(DataPointer, Array.Empty<object>());
		Next = reader.ReadBlockAt<PropertyMapEntry>(NextPointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		DataPointer = (ulong)((Data != null) ? Data.Position : 0);
		NextPointer = (ulong)((Next != null) ? Next.Position : 0);
		writer.Write(DataNameHash);
		writer.Write(Unknown_4h);
		writer.Write(DataPointer);
		writer.Write(NextPointer);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Data != null)
		{
			list.Add(Data);
		}
		if (Next != null)
		{
			list.Add(Next);
		}
		return list.ToArray();
	}
}
