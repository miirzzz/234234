using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Particles;

public class Unknown_P_010 : ResourceSystemBlock
{
	public uint Unknown_0h;

	public uint Unknown_4h;

	public ulong Unknown_8h_Pointer;

	public Unknown_P_003 Unknown_8h_Data;

	public override long Length => 16L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h_Pointer = reader.ReadUInt64();
		Unknown_8h_Data = reader.ReadBlockAt<Unknown_P_003>(Unknown_8h_Pointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		Unknown_8h_Pointer = (ulong)((Unknown_8h_Data != null) ? Unknown_8h_Data.Position : 0);
		writer.Write(Unknown_0h);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h_Pointer);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Unknown_8h_Data != null)
		{
			list.Add(Unknown_8h_Data);
		}
		return list.ToArray();
	}
}
