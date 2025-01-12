using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Particles;

public class Unknown_P_007 : ResourceSystemBlock
{
	public uint Unknown_0h;

	public uint Unknown_4h;

	public ulong p1;

	public Unknown_P_003 p1data;

	public override long Length => 16L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		p1 = reader.ReadUInt64();
		p1data = reader.ReadBlockAt<Unknown_P_003>(p1, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		p1 = (ulong)((p1data != null) ? p1data.Position : 0);
		writer.Write(Unknown_0h);
		writer.Write(Unknown_4h);
		writer.Write(p1);
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
