using System;
using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Particles;

public class Unknown_P_008 : ResourceSystemBlock
{
	public ulong p1;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public string_r p1data;

	public override long Length => 24L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		p1 = reader.ReadUInt64();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		p1data = reader.ReadBlockAt<string_r>(p1, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		p1 = (ulong)((p1data != null) ? p1data.Position : 0);
		writer.Write(p1);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (p1data != null)
		{
			list.Add(p1data);
		}
		return list.ToArray();
	}
}
