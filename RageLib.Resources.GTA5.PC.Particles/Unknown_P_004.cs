using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Particles;

public class Unknown_P_004 : ResourceSystemBlock
{
	public ResourceSimpleList64<Unknown_P_002> Unknown_0h;

	public ResourceSimpleList64<Unknown_P_003> Unknown_10h;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public ResourceSimpleList64<Unknown_P_007> Unknown_28h;

	public uint Unknown_38h;

	public uint Unknown_3Ch;

	public override long Length => 64L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadBlock<ResourceSimpleList64<Unknown_P_002>>(Array.Empty<object>());
		Unknown_10h = reader.ReadBlock<ResourceSimpleList64<Unknown_P_003>>(Array.Empty<object>());
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadBlock<ResourceSimpleList64<Unknown_P_007>>(Array.Empty<object>());
		Unknown_38h = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.WriteBlock(Unknown_0h);
		writer.WriteBlock(Unknown_10h);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.WriteBlock(Unknown_28h);
		writer.Write(Unknown_38h);
		writer.Write(Unknown_3Ch);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[3]
		{
			new Tuple<long, IResourceBlock>(0L, Unknown_0h),
			new Tuple<long, IResourceBlock>(16L, Unknown_10h),
			new Tuple<long, IResourceBlock>(40L, Unknown_28h)
		};
	}
}
