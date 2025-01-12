using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Fragments;

public class Unknown_F_002 : ResourceSystemBlock
{
	public uint Unknown_0h;

	public uint Unknown_4h;

	public uint cnt1;

	public uint Unknown_Ch;

	public ResourceSimpleArray<byte_r> Data;

	public override long Length => 16 + Data.Length;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		cnt1 = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Data = reader.ReadBlock<ResourceSimpleArray<byte_r>>(new object[1] { cnt1 - 16 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Unknown_0h);
		writer.Write(Unknown_4h);
		writer.Write(cnt1);
		writer.Write(Unknown_Ch);
		writer.WriteBlock(Data);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[1]
		{
			new Tuple<long, IResourceBlock>(16L, Data)
		};
	}
}
