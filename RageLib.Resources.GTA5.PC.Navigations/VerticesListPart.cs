using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Navigations;

public class VerticesListPart : ResourceSystemBlock
{
	public ulong VerticesPointer;

	public uint VerticesCount;

	public uint Unknown_Ch;

	public ResourceSimpleArray<Vertex> Vertices;

	public override long Length => 16L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VerticesPointer = reader.ReadUInt64();
		VerticesCount = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Vertices = reader.ReadBlockAt<ResourceSimpleArray<Vertex>>(VerticesPointer, new object[1] { VerticesCount });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		VerticesPointer = (ulong)((Vertices != null) ? Vertices.Position : 0);
		VerticesCount = ((Vertices != null) ? ((uint)Vertices.Count) : 0u);
		writer.Write(VerticesPointer);
		writer.Write(VerticesCount);
		writer.Write(Unknown_Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Vertices != null)
		{
			list.Add(Vertices);
		}
		return list.ToArray();
	}
}
