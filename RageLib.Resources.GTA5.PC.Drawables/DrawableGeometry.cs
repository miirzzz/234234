using System;
using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Drawables;

public class DrawableGeometry : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public ulong VertexBufferPointer;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public uint Unknown_30h;

	public uint Unknown_34h;

	public ulong IndexBufferPointer;

	public uint Unknown_40h;

	public uint Unknown_44h;

	public uint Unknown_48h;

	public uint Unknown_4Ch;

	public uint Unknown_50h;

	public uint Unknown_54h;

	public uint IndicesCount;

	public uint Unknown_5Ch;

	public ushort VerticesCount;

	public ushort Unknown_62h;

	public uint Unknown_64h;

	public ulong Unknown_68h_Pointer;

	public ushort VertexStride;

	public ushort Count1;

	public uint Unknown_74h;

	public ulong VertexDataPointer;

	public uint Unknown_80h;

	public uint Unknown_84h;

	public uint Unknown_88h;

	public uint Unknown_8Ch;

	public uint Unknown_90h;

	public uint Unknown_94h;

	public VertexBuffer VertexBuffer;

	public IndexBuffer IndexBuffer;

	public ResourceSimpleArray<ushort_r> Unknown_68h_Data;

	public VertexData_GTA5_pc VertexData;

	public override long Length => 152L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		VertexBufferPointer = reader.ReadUInt64();
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		Unknown_30h = reader.ReadUInt32();
		Unknown_34h = reader.ReadUInt32();
		IndexBufferPointer = reader.ReadUInt64();
		Unknown_40h = reader.ReadUInt32();
		Unknown_44h = reader.ReadUInt32();
		Unknown_48h = reader.ReadUInt32();
		Unknown_4Ch = reader.ReadUInt32();
		Unknown_50h = reader.ReadUInt32();
		Unknown_54h = reader.ReadUInt32();
		IndicesCount = reader.ReadUInt32();
		Unknown_5Ch = reader.ReadUInt32();
		VerticesCount = reader.ReadUInt16();
		Unknown_62h = reader.ReadUInt16();
		Unknown_64h = reader.ReadUInt32();
		Unknown_68h_Pointer = reader.ReadUInt64();
		VertexStride = reader.ReadUInt16();
		Count1 = reader.ReadUInt16();
		Unknown_74h = reader.ReadUInt32();
		VertexDataPointer = reader.ReadUInt64();
		Unknown_80h = reader.ReadUInt32();
		Unknown_84h = reader.ReadUInt32();
		Unknown_88h = reader.ReadUInt32();
		Unknown_8Ch = reader.ReadUInt32();
		Unknown_90h = reader.ReadUInt32();
		Unknown_94h = reader.ReadUInt32();
		VertexBuffer = reader.ReadBlockAt<VertexBuffer>(VertexBufferPointer, Array.Empty<object>());
		IndexBuffer = reader.ReadBlockAt<IndexBuffer>(IndexBufferPointer, Array.Empty<object>());
		Unknown_68h_Data = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(Unknown_68h_Pointer, new object[1] { Count1 });
		VertexData = reader.ReadBlockAt<VertexData_GTA5_pc>(VertexDataPointer, new object[3] { VertexStride, VerticesCount, VertexBuffer.Info });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		VertexBufferPointer = (ulong)((VertexBuffer != null) ? VertexBuffer.Position : 0);
		IndexBufferPointer = (ulong)((IndexBuffer != null) ? IndexBuffer.Position : 0);
		Unknown_68h_Pointer = (ulong)((Unknown_68h_Data != null) ? Unknown_68h_Data.Position : 0);
		VertexDataPointer = (ulong)((VertexData != null) ? VertexData.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(VertexBufferPointer);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
		writer.Write(Unknown_30h);
		writer.Write(Unknown_34h);
		writer.Write(IndexBufferPointer);
		writer.Write(Unknown_40h);
		writer.Write(Unknown_44h);
		writer.Write(Unknown_48h);
		writer.Write(Unknown_4Ch);
		writer.Write(Unknown_50h);
		writer.Write(Unknown_54h);
		writer.Write(IndicesCount);
		writer.Write(Unknown_5Ch);
		writer.Write(VerticesCount);
		writer.Write(Unknown_62h);
		writer.Write(Unknown_64h);
		writer.Write(Unknown_68h_Pointer);
		writer.Write(VertexStride);
		writer.Write(Count1);
		writer.Write(Unknown_74h);
		writer.Write(VertexDataPointer);
		writer.Write(Unknown_80h);
		writer.Write(Unknown_84h);
		writer.Write(Unknown_88h);
		writer.Write(Unknown_8Ch);
		writer.Write(Unknown_90h);
		writer.Write(Unknown_94h);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (VertexBuffer != null)
		{
			list.Add(VertexBuffer);
		}
		if (IndexBuffer != null)
		{
			list.Add(IndexBuffer);
		}
		if (Unknown_68h_Data != null)
		{
			list.Add(Unknown_68h_Data);
		}
		if (VertexData != null)
		{
			list.Add(VertexData);
		}
		return list.ToArray();
	}
}
