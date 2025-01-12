using System;
using RageLib.Resources.Common;

namespace RageLib.Resources;

public class Filter : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public ResourceSimpleList64<ulong_r> Unknown_18h;

	public ResourceSimpleList64<uint_r> Unknown_28h;

	public uint Unknown_38h;

	public uint Unknown_3Ch;

	public override long Length => 64L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h = reader.ReadBlock<ResourceSimpleList64<ulong_r>>(Array.Empty<object>());
		Unknown_28h = reader.ReadBlock<ResourceSimpleList64<uint_r>>(Array.Empty<object>());
		Unknown_38h = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.WriteBlock(Unknown_18h);
		writer.WriteBlock(Unknown_28h);
		writer.Write(Unknown_38h);
		writer.Write(Unknown_3Ch);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[2]
		{
			new Tuple<long, IResourceBlock>(24L, Unknown_18h),
			new Tuple<long, IResourceBlock>(40L, Unknown_28h)
		};
	}
}
