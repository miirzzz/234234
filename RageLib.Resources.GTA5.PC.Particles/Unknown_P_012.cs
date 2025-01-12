using System;
using System.Collections.Generic;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Drawables;

namespace RageLib.Resources.GTA5.PC.Particles;

public class Unknown_P_012 : ResourceSystemBlock
{
	public uint Unknown_0h;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public ulong Unknown_10h_Pointer;

	public ulong DrawablePointer;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public string_r Unknown_10h_Data;

	public Drawable Drawable;

	public override long Length => 48L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h_Pointer = reader.ReadUInt64();
		DrawablePointer = reader.ReadUInt64();
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		Unknown_10h_Data = reader.ReadBlockAt<string_r>(Unknown_10h_Pointer, Array.Empty<object>());
		Drawable = reader.ReadBlockAt<Drawable>(DrawablePointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		Unknown_10h_Pointer = (ulong)((Unknown_10h_Data != null) ? Unknown_10h_Data.Position : 0);
		DrawablePointer = (ulong)((Drawable != null) ? Drawable.Position : 0);
		writer.Write(Unknown_0h);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h_Pointer);
		writer.Write(DrawablePointer);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Unknown_10h_Data != null)
		{
			list.Add(Unknown_10h_Data);
		}
		if (Drawable != null)
		{
			list.Add(Drawable);
		}
		return list.ToArray();
	}
}
