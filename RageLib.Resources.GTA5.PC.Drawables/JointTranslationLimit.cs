using System;

namespace RageLib.Resources.GTA5.PC.Drawables;

public class JointTranslationLimit : ResourceSystemBlock
{
	public uint Unknown_0h;

	public uint Unknown_4h;

	public uint BoneId;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public RAGE_Vector3 Min;

	public uint Unknown_2Ch;

	public RAGE_Vector3 Max;

	public uint Unknown_3Ch;

	public override long Length => 64L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		BoneId = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		Min = reader.ReadBlock<RAGE_Vector3>(Array.Empty<object>());
		Unknown_2Ch = reader.ReadUInt32();
		Max = reader.ReadBlock<RAGE_Vector3>(Array.Empty<object>());
		Unknown_3Ch = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Unknown_0h);
		writer.Write(Unknown_4h);
		writer.Write(BoneId);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.WriteBlock(Min);
		writer.Write(Unknown_2Ch);
		writer.WriteBlock(Max);
		writer.Write(Unknown_3Ch);
	}
}
