using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Particles;

public class Unknown_P_003 : ResourceSystemBlock
{
	public ResourceSimpleList64<Unknown_P_006> Unknown_0h;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public override long Length => 24L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadBlock<ResourceSimpleList64<Unknown_P_006>>(Array.Empty<object>());
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.WriteBlock(Unknown_0h);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[1]
		{
			new Tuple<long, IResourceBlock>(0L, Unknown_0h)
		};
	}
}
