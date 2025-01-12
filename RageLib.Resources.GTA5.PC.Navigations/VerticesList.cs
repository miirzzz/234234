using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Navigations;

public class VerticesList : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public ulong ListPartsPointer;

	public ulong ListOffsetsPointer;

	public uint ListPartsCount;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public ResourceSimpleArray<VerticesListPart> ListParts;

	public ResourceSimpleArray<uint_r> ListOffsets;

	public override long Length => 48L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		ListPartsPointer = reader.ReadUInt64();
		ListOffsetsPointer = reader.ReadUInt64();
		ListPartsCount = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		ListParts = reader.ReadBlockAt<ResourceSimpleArray<VerticesListPart>>(ListPartsPointer, new object[1] { ListPartsCount });
		ListOffsets = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(ListOffsetsPointer, new object[1] { ListPartsCount });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		ListPartsPointer = (ulong)((ListParts != null) ? ListParts.Position : 0);
		ListOffsetsPointer = (ulong)((ListOffsets != null) ? ListOffsets.Position : 0);
		ListPartsCount = ((ListParts != null) ? ((uint)ListParts.Count) : 0u);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(ListPartsPointer);
		writer.Write(ListOffsetsPointer);
		writer.Write(ListPartsCount);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (ListParts != null)
		{
			list.Add(ListParts);
		}
		if (ListOffsets != null)
		{
			list.Add(ListOffsets);
		}
		return list.ToArray();
	}
}
