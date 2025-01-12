using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Fragments;

public class Unknown_F_003 : ResourceSystemBlock
{
	public uint Unknown_0h;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public byte cnt1;

	public byte cnt2;

	public ushort Unknown_12h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public ResourceSimpleArray<RAGE_Matrix3> Data;

	public override long Length => 32 + Data.Length;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		cnt1 = reader.ReadByte();
		cnt2 = reader.ReadByte();
		Unknown_12h = reader.ReadUInt16();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		Data = reader.ReadBlock<ResourceSimpleArray<RAGE_Matrix3>>(new object[1] { cnt1 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Unknown_0h);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(cnt1);
		writer.Write(cnt2);
		writer.Write(Unknown_12h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.WriteBlock(Data);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[1]
		{
			new Tuple<long, IResourceBlock>(32L, Data)
		};
	}
}
