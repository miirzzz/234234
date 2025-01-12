using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Navigations;

public class SectorData : ResourceSystemBlock
{
	public uint c1;

	public uint Unknown_4h;

	public ulong p1;

	public ulong p2;

	public ushort c2;

	public ushort c3;

	public uint Unknown_1Ch;

	public ResourceSimpleArray<ushort_r> p1data;

	public ResourceSimpleArray<SectorDataUnk> p2data;

	public override long Length => 32L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		c1 = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		p1 = reader.ReadUInt64();
		p2 = reader.ReadUInt64();
		c2 = reader.ReadUInt16();
		c3 = reader.ReadUInt16();
		Unknown_1Ch = reader.ReadUInt32();
		p1data = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(p1, new object[1] { c2 });
		p2data = reader.ReadBlockAt<ResourceSimpleArray<SectorDataUnk>>(p2, new object[1] { c3 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		p1 = (ulong)((p1data != null) ? p1data.Position : 0);
		p2 = (ulong)((p2data != null) ? p2data.Position : 0);
		c2 = (ushort)((p1data != null) ? ((uint)p1data.Count) : 0u);
		c3 = (ushort)((p2data != null) ? ((uint)p2data.Count) : 0u);
		writer.Write(c1);
		writer.Write(Unknown_4h);
		writer.Write(p1);
		writer.Write(p2);
		writer.Write(c2);
		writer.Write(c3);
		writer.Write(Unknown_1Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (p1data != null)
		{
			list.Add(p1data);
		}
		if (p2data != null)
		{
			list.Add(p2data);
		}
		return list.ToArray();
	}
}
