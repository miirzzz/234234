namespace RageLib.Resources.GTA5.PC.Fragments;

public class Joint1DofType : JointType
{
	public uint Unknown_20h;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public uint Unknown_30h;

	public uint Unknown_34h;

	public uint Unknown_38h;

	public uint Unknown_3Ch;

	public uint Unknown_40h;

	public uint Unknown_44h;

	public uint Unknown_48h;

	public uint Unknown_4Ch;

	public uint Unknown_50h;

	public uint Unknown_54h;

	public uint Unknown_58h;

	public uint Unknown_5Ch;

	public uint Unknown_60h;

	public uint Unknown_64h;

	public uint Unknown_68h;

	public uint Unknown_6Ch;

	public uint Unknown_70h;

	public uint Unknown_74h;

	public uint Unknown_78h;

	public uint Unknown_7Ch;

	public uint Unknown_80h;

	public uint Unknown_84h;

	public uint Unknown_88h;

	public uint Unknown_8Ch;

	public uint Unknown_90h;

	public uint Unknown_94h;

	public uint Unknown_98h;

	public uint Unknown_9Ch;

	public uint Unknown_A0h;

	public uint Unknown_A4h;

	public uint Unknown_A8h;

	public uint Unknown_ACh;

	public override long Length => 176L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		Unknown_30h = reader.ReadUInt32();
		Unknown_34h = reader.ReadUInt32();
		Unknown_38h = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
		Unknown_40h = reader.ReadUInt32();
		Unknown_44h = reader.ReadUInt32();
		Unknown_48h = reader.ReadUInt32();
		Unknown_4Ch = reader.ReadUInt32();
		Unknown_50h = reader.ReadUInt32();
		Unknown_54h = reader.ReadUInt32();
		Unknown_58h = reader.ReadUInt32();
		Unknown_5Ch = reader.ReadUInt32();
		Unknown_60h = reader.ReadUInt32();
		Unknown_64h = reader.ReadUInt32();
		Unknown_68h = reader.ReadUInt32();
		Unknown_6Ch = reader.ReadUInt32();
		Unknown_70h = reader.ReadUInt32();
		Unknown_74h = reader.ReadUInt32();
		Unknown_78h = reader.ReadUInt32();
		Unknown_7Ch = reader.ReadUInt32();
		Unknown_80h = reader.ReadUInt32();
		Unknown_84h = reader.ReadUInt32();
		Unknown_88h = reader.ReadUInt32();
		Unknown_8Ch = reader.ReadUInt32();
		Unknown_90h = reader.ReadUInt32();
		Unknown_94h = reader.ReadUInt32();
		Unknown_98h = reader.ReadUInt32();
		Unknown_9Ch = reader.ReadUInt32();
		Unknown_A0h = reader.ReadUInt32();
		Unknown_A4h = reader.ReadUInt32();
		Unknown_A8h = reader.ReadUInt32();
		Unknown_ACh = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
		writer.Write(Unknown_30h);
		writer.Write(Unknown_34h);
		writer.Write(Unknown_38h);
		writer.Write(Unknown_3Ch);
		writer.Write(Unknown_40h);
		writer.Write(Unknown_44h);
		writer.Write(Unknown_48h);
		writer.Write(Unknown_4Ch);
		writer.Write(Unknown_50h);
		writer.Write(Unknown_54h);
		writer.Write(Unknown_58h);
		writer.Write(Unknown_5Ch);
		writer.Write(Unknown_60h);
		writer.Write(Unknown_64h);
		writer.Write(Unknown_68h);
		writer.Write(Unknown_6Ch);
		writer.Write(Unknown_70h);
		writer.Write(Unknown_74h);
		writer.Write(Unknown_78h);
		writer.Write(Unknown_7Ch);
		writer.Write(Unknown_80h);
		writer.Write(Unknown_84h);
		writer.Write(Unknown_88h);
		writer.Write(Unknown_8Ch);
		writer.Write(Unknown_90h);
		writer.Write(Unknown_94h);
		writer.Write(Unknown_98h);
		writer.Write(Unknown_9Ch);
		writer.Write(Unknown_A0h);
		writer.Write(Unknown_A4h);
		writer.Write(Unknown_A8h);
		writer.Write(Unknown_ACh);
	}
}
