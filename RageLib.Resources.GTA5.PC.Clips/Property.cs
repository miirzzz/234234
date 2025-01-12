using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Clips;

public class Property : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint NameHash;

	public uint Unknown_1Ch;

	public ulong AttributesPointer;

	public ushort AttributesCount1;

	public ushort AttributesCount2;

	public uint Unknown_2Ch;

	public uint Unknown_30h;

	public uint Unknown_34h;

	public uint Unknown_38h;

	public uint Unknown_3Ch;

	public ResourcePointerArray64<PropertyAttribute> Attributes;

	public override long Length => 64L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		NameHash = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		AttributesPointer = reader.ReadUInt64();
		AttributesCount1 = reader.ReadUInt16();
		AttributesCount2 = reader.ReadUInt16();
		Unknown_2Ch = reader.ReadUInt32();
		Unknown_30h = reader.ReadUInt32();
		Unknown_34h = reader.ReadUInt32();
		Unknown_38h = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
		Attributes = reader.ReadBlockAt<ResourcePointerArray64<PropertyAttribute>>(AttributesPointer, new object[1] { AttributesCount1 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		AttributesPointer = (ulong)((Attributes != null) ? Attributes.Position : 0);
		AttributesCount1 = (ushort)((Attributes != null) ? ((uint)Attributes.Count) : 0u);
		AttributesCount2 = (ushort)((Attributes != null) ? ((uint)Attributes.Count) : 0u);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(NameHash);
		writer.Write(Unknown_1Ch);
		writer.Write(AttributesPointer);
		writer.Write(AttributesCount1);
		writer.Write(AttributesCount2);
		writer.Write(Unknown_2Ch);
		writer.Write(Unknown_30h);
		writer.Write(Unknown_34h);
		writer.Write(Unknown_38h);
		writer.Write(Unknown_3Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Attributes != null)
		{
			list.Add(Attributes);
		}
		return list.ToArray();
	}
}
