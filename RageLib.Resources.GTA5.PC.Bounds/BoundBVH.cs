using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Bounds;

public class BoundBVH : BoundGeometry
{
	public ulong BvhPointer;

	public uint Unknown_138h;

	public uint Unknown_13Ch;

	public ushort Unknown_140h;

	public ushort Unknown_142h;

	public uint Unknown_144h;

	public uint Unknown_148h;

	public uint Unknown_14Ch;

	public BVH BVH;

	public override long Length => 336L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		BvhPointer = reader.ReadUInt64();
		Unknown_138h = reader.ReadUInt32();
		Unknown_13Ch = reader.ReadUInt32();
		Unknown_140h = reader.ReadUInt16();
		Unknown_142h = reader.ReadUInt16();
		Unknown_144h = reader.ReadUInt32();
		Unknown_148h = reader.ReadUInt32();
		Unknown_14Ch = reader.ReadUInt32();
		BVH = reader.ReadBlockAt<BVH>(BvhPointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		BvhPointer = (ulong)((BVH != null) ? BVH.Position : 0);
		writer.Write(BvhPointer);
		writer.Write(Unknown_138h);
		writer.Write(Unknown_13Ch);
		writer.Write(Unknown_140h);
		writer.Write(Unknown_142h);
		writer.Write(Unknown_144h);
		writer.Write(Unknown_148h);
		writer.Write(Unknown_14Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (BVH != null)
		{
			list.Add(BVH);
		}
		return list.ToArray();
	}
}
