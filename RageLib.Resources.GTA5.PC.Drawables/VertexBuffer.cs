using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Drawables;

public class VertexBuffer : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public ushort VertexStride;

	public ushort Unknown_Ah;

	public uint Unknown_Ch;

	public ulong DataPointer1;

	public uint VertexCount;

	public uint Unknown_1Ch;

	public ulong DataPointer2;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public ulong InfoPointer;

	public uint Unknown_38h;

	public uint Unknown_3Ch;

	public uint Unknown_40h;

	public uint Unknown_44h;

	public uint Unknown_48h;

	public uint Unknown_4Ch;

	public uint Unknown_50h;

	public uint Unknown_54h;

	public uint Unknown_58h;

	public uint Unknown_5Ch;

	public uint Unknown_60h;

	public uint Unknown_64h;

	public uint Unknown_68h;

	public uint Unknown_6Ch;

	public uint Unknown_70h;

	public uint Unknown_74h;

	public uint Unknown_78h;

	public uint Unknown_7Ch;

	public VertexData_GTA5_pc Data1;

	public VertexData_GTA5_pc Data2;

	public VertexDeclaration Info;

	public override long Length => 128L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		VertexStride = reader.ReadUInt16();
		Unknown_Ah = reader.ReadUInt16();
		Unknown_Ch = reader.ReadUInt32();
		DataPointer1 = reader.ReadUInt64();
		VertexCount = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		DataPointer2 = reader.ReadUInt64();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		InfoPointer = reader.ReadUInt64();
		Unknown_38h = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
		Unknown_40h = reader.ReadUInt32();
		Unknown_44h = reader.ReadUInt32();
		Unknown_48h = reader.ReadUInt32();
		Unknown_4Ch = reader.ReadUInt32();
		Unknown_50h = reader.ReadUInt32();
		Unknown_54h = reader.ReadUInt32();
		Unknown_58h = reader.ReadUInt32();
		Unknown_5Ch = reader.ReadUInt32();
		Unknown_60h = reader.ReadUInt32();
		Unknown_64h = reader.ReadUInt32();
		Unknown_68h = reader.ReadUInt32();
		Unknown_6Ch = reader.ReadUInt32();
		Unknown_70h = reader.ReadUInt32();
		Unknown_74h = reader.ReadUInt32();
		Unknown_78h = reader.ReadUInt32();
		Unknown_7Ch = reader.ReadUInt32();
		Info = reader.ReadBlockAt<VertexDeclaration>(InfoPointer, Array.Empty<object>());
		Data1 = reader.ReadBlockAt<VertexData_GTA5_pc>(DataPointer1, new object[3] { VertexStride, VertexCount, Info });
		Data2 = reader.ReadBlockAt<VertexData_GTA5_pc>(DataPointer2, new object[3] { VertexStride, VertexCount, Info });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		DataPointer1 = (ulong)((Data1 != null) ? Data1.Position : 0);
		DataPointer2 = (ulong)((Data2 != null) ? Data2.Position : 0);
		InfoPointer = (ulong)((Info != null) ? Info.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(VertexStride);
		writer.Write(Unknown_Ah);
		writer.Write(Unknown_Ch);
		writer.Write(DataPointer1);
		writer.Write(VertexCount);
		writer.Write(Unknown_1Ch);
		writer.Write(DataPointer2);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
		writer.Write(InfoPointer);
		writer.Write(Unknown_38h);
		writer.Write(Unknown_3Ch);
		writer.Write(Unknown_40h);
		writer.Write(Unknown_44h);
		writer.Write(Unknown_48h);
		writer.Write(Unknown_4Ch);
		writer.Write(Unknown_50h);
		writer.Write(Unknown_54h);
		writer.Write(Unknown_58h);
		writer.Write(Unknown_5Ch);
		writer.Write(Unknown_60h);
		writer.Write(Unknown_64h);
		writer.Write(Unknown_68h);
		writer.Write(Unknown_6Ch);
		writer.Write(Unknown_70h);
		writer.Write(Unknown_74h);
		writer.Write(Unknown_78h);
		writer.Write(Unknown_7Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Data1 != null)
		{
			list.Add(Data1);
		}
		if (Data2 != null)
		{
			list.Add(Data2);
		}
		if (Info != null)
		{
			list.Add(Info);
		}
		return list.ToArray();
	}
}
