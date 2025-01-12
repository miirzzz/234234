using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Clips;

public class Tag : Property
{
	public uint Unknown_40h;

	public uint Unknown_44h;

	public ulong TagsPointer;

	public Tags Tags;

	public override long Length => 80L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Unknown_40h = reader.ReadUInt32();
		Unknown_44h = reader.ReadUInt32();
		TagsPointer = reader.ReadUInt64();
		Tags = reader.ReadBlockAt<Tags>(TagsPointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		TagsPointer = (ulong)((Tags != null) ? Tags.Position : 0);
		writer.Write(Unknown_40h);
		writer.Write(Unknown_44h);
		writer.Write(TagsPointer);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (Tags != null)
		{
			list.Add(Tags);
		}
		return list.ToArray();
	}
}
