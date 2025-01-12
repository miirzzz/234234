using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Clips;

public class Animation : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public ushort Unknown_10h;

	public ushort Unknown_12h;

	public ushort Unknown_14h;

	public ushort Unknown_16h;

	public float Unknown_18h;

	public uint Unknown_1Ch;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public uint Unknown_30h;

	public uint Unknown_34h;

	public uint Unknown_38h;

	public uint Unknown_3Ch;

	public ResourcePointerList64<Sequence> Sequences;

	public ResourceSimpleList64<uint_r> Unknown_50h;

	public override long Length => 96L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt16();
		Unknown_12h = reader.ReadUInt16();
		Unknown_14h = reader.ReadUInt16();
		Unknown_16h = reader.ReadUInt16();
		Unknown_18h = reader.ReadSingle();
		Unknown_1Ch = reader.ReadUInt32();
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		Unknown_30h = reader.ReadUInt32();
		Unknown_34h = reader.ReadUInt32();
		Unknown_38h = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
		Sequences = reader.ReadBlock<ResourcePointerList64<Sequence>>(Array.Empty<object>());
		Unknown_50h = reader.ReadBlock<ResourceSimpleList64<uint_r>>(Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_12h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_16h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
		writer.Write(Unknown_30h);
		writer.Write(Unknown_34h);
		writer.Write(Unknown_38h);
		writer.Write(Unknown_3Ch);
		writer.WriteBlock(Sequences);
		writer.WriteBlock(Unknown_50h);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[2]
		{
			new Tuple<long, IResourceBlock>(64L, Sequences),
			new Tuple<long, IResourceBlock>(80L, Unknown_50h)
		};
	}
}
