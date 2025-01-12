using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Navigations;

public class Sector : ResourceSystemBlock
{
	public float Unknown_0h;

	public float Unknown_4h;

	public float Unknown_8h;

	public float Unknown_Ch;

	public float Unknown_10h;

	public float Unknown_14h;

	public float Unknown_18h;

	public float Unknown_1Ch;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public ulong DataPointer;

	public ulong SubTree1Pointer;

	public ulong SubTree2Pointer;

	public ulong SubTree3Pointer;

	public ulong SubTree4Pointer;

	public uint Unknown_54h;

	public uint Unknown_58h;

	public uint Unknown_5Ch;

	public SectorData Data;

	public Sector SubTree1;

	public Sector SubTree2;

	public Sector SubTree3;

	public Sector SubTree4;

	public override long Length => 96L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadSingle();
		Unknown_4h = reader.ReadSingle();
		Unknown_8h = reader.ReadSingle();
		Unknown_Ch = reader.ReadSingle();
		Unknown_10h = reader.ReadSingle();
		Unknown_14h = reader.ReadSingle();
		Unknown_18h = reader.ReadSingle();
		Unknown_1Ch = reader.ReadSingle();
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		DataPointer = reader.ReadUInt64();
		SubTree1Pointer = reader.ReadUInt64();
		SubTree2Pointer = reader.ReadUInt64();
		SubTree3Pointer = reader.ReadUInt64();
		SubTree4Pointer = reader.ReadUInt64();
		Unknown_54h = reader.ReadUInt32();
		Unknown_58h = reader.ReadUInt32();
		Unknown_5Ch = reader.ReadUInt32();
		Data = reader.ReadBlockAt<SectorData>(DataPointer, Array.Empty<object>());
		SubTree1 = reader.ReadBlockAt<Sector>(SubTree1Pointer, Array.Empty<object>());
		SubTree2 = reader.ReadBlockAt<Sector>(SubTree2Pointer, Array.Empty<object>());
		SubTree3 = reader.ReadBlockAt<Sector>(SubTree3Pointer, Array.Empty<object>());
		SubTree4 = reader.ReadBlockAt<Sector>(SubTree4Pointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		DataPointer = (ulong)((Data != null) ? Data.Position : 0);
		SubTree1Pointer = (ulong)((SubTree1 != null) ? SubTree1.Position : 0);
		SubTree2Pointer = (ulong)((SubTree2 != null) ? SubTree2.Position : 0);
		SubTree3Pointer = (ulong)((SubTree3 != null) ? SubTree3.Position : 0);
		SubTree4Pointer = (ulong)((SubTree4 != null) ? SubTree4.Position : 0);
		writer.Write(Unknown_0h);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(DataPointer);
		writer.Write(SubTree1Pointer);
		writer.Write(SubTree2Pointer);
		writer.Write(SubTree3Pointer);
		writer.Write(SubTree4Pointer);
		writer.Write(Unknown_54h);
		writer.Write(Unknown_58h);
		writer.Write(Unknown_5Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Data != null)
		{
			list.Add(Data);
		}
		if (SubTree1 != null)
		{
			list.Add(SubTree1);
		}
		if (SubTree2 != null)
		{
			list.Add(SubTree2);
		}
		if (SubTree3 != null)
		{
			list.Add(SubTree3);
		}
		if (SubTree4 != null)
		{
			list.Add(SubTree4);
		}
		return list.ToArray();
	}
}
