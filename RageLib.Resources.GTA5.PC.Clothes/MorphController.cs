using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Clothes;

public class MorphController : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public ulong Unknown_18h_Pointer;

	public ulong Unknown_20h_Pointer;

	public ulong Unknown_28h_Pointer;

	public uint Unknown_30h;

	public uint Unknown_34h;

	public uint Unknown_38h;

	public uint Unknown_3Ch;

	public Unknown_C_006 Unknown_18h_Data;

	public Unknown_C_006 Unknown_20h_Data;

	public Unknown_C_006 Unknown_28h_Data;

	public override long Length => 64L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h_Pointer = reader.ReadUInt64();
		Unknown_20h_Pointer = reader.ReadUInt64();
		Unknown_28h_Pointer = reader.ReadUInt64();
		Unknown_30h = reader.ReadUInt32();
		Unknown_34h = reader.ReadUInt32();
		Unknown_38h = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
		Unknown_18h_Data = reader.ReadBlockAt<Unknown_C_006>(Unknown_18h_Pointer, Array.Empty<object>());
		Unknown_20h_Data = reader.ReadBlockAt<Unknown_C_006>(Unknown_20h_Pointer, Array.Empty<object>());
		Unknown_28h_Data = reader.ReadBlockAt<Unknown_C_006>(Unknown_28h_Pointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		Unknown_18h_Pointer = (ulong)((Unknown_18h_Data != null) ? Unknown_18h_Data.Position : 0);
		Unknown_20h_Pointer = (ulong)((Unknown_20h_Data != null) ? Unknown_20h_Data.Position : 0);
		Unknown_28h_Pointer = (ulong)((Unknown_28h_Data != null) ? Unknown_28h_Data.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h_Pointer);
		writer.Write(Unknown_20h_Pointer);
		writer.Write(Unknown_28h_Pointer);
		writer.Write(Unknown_30h);
		writer.Write(Unknown_34h);
		writer.Write(Unknown_38h);
		writer.Write(Unknown_3Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Unknown_18h_Data != null)
		{
			list.Add(Unknown_18h_Data);
		}
		if (Unknown_20h_Data != null)
		{
			list.Add(Unknown_20h_Data);
		}
		if (Unknown_28h_Data != null)
		{
			list.Add(Unknown_28h_Data);
		}
		return list.ToArray();
	}
}
