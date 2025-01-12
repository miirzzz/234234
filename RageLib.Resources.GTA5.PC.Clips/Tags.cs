using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Clips;

public class Tags : ResourceSystemBlock
{
	public ulong TagListPointer;

	public ushort TagsCount1;

	public ushort TagsCount2;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public ResourcePointerArray64<Tag> TagList;

	public override long Length => 32L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		TagListPointer = reader.ReadUInt64();
		TagsCount1 = reader.ReadUInt16();
		TagsCount2 = reader.ReadUInt16();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		TagList = reader.ReadBlockAt<ResourcePointerArray64<Tag>>(TagListPointer, new object[1] { TagsCount1 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		TagListPointer = (ulong)((TagList != null) ? TagList.Position : 0);
		TagsCount1 = (ushort)((TagList != null) ? ((uint)TagList.Count) : 0u);
		TagsCount2 = (ushort)((TagList != null) ? ((uint)TagList.Count) : 0u);
		writer.Write(TagListPointer);
		writer.Write(TagsCount1);
		writer.Write(TagsCount2);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (TagList != null)
		{
			list.Add(TagList);
		}
		return list.ToArray();
	}
}
