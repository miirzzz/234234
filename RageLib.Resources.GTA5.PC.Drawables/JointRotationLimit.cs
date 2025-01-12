namespace RageLib.Resources.GTA5.PC.Drawables;

public class JointRotationLimit : ResourceSystemBlock
{
	public uint Unknown_0h;

	public uint Unknown_4h;

	public ushort BoneId;

	public ushort Unknown_Ah;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public float Unknown_2Ch;

	public uint Unknown_30h;

	public uint Unknown_34h;

	public uint Unknown_38h;

	public uint Unknown_3Ch;

	public float Unknown_40h;

	public uint Unknown_44h;

	public uint Unknown_48h;

	public uint Unknown_4Ch;

	public float Unknown_50h;

	public float Unknown_54h;

	public float Unknown_58h;

	public float Unknown_5Ch;

	public float Unknown_60h;

	public float Unknown_64h;

	public float Unknown_68h;

	public float Unknown_6Ch;

	public float Unknown_70h;

	public float Unknown_74h;

	public float Unknown_78h;

	public float Unknown_7Ch;

	public float Unknown_80h;

	public float Unknown_84h;

	public float Unknown_88h;

	public float Unknown_8Ch;

	public float Unknown_90h;

	public float Unknown_94h;

	public float Unknown_98h;

	public float Unknown_9Ch;

	public float Unknown_A0h;

	public float Unknown_A4h;

	public float Unknown_A8h;

	public float Unknown_ACh;

	public float Unknown_B0h;

	public float Unknown_B4h;

	public float Unknown_B8h;

	public uint Unknown_BCh;

	public override long Length => 192L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		BoneId = reader.ReadUInt16();
		Unknown_Ah = reader.ReadUInt16();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadSingle();
		Unknown_30h = reader.ReadUInt32();
		Unknown_34h = reader.ReadUInt32();
		Unknown_38h = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
		Unknown_40h = reader.ReadSingle();
		Unknown_44h = reader.ReadUInt32();
		Unknown_48h = reader.ReadUInt32();
		Unknown_4Ch = reader.ReadUInt32();
		Unknown_50h = reader.ReadSingle();
		Unknown_54h = reader.ReadSingle();
		Unknown_58h = reader.ReadSingle();
		Unknown_5Ch = reader.ReadSingle();
		Unknown_60h = reader.ReadSingle();
		Unknown_64h = reader.ReadSingle();
		Unknown_68h = reader.ReadSingle();
		Unknown_6Ch = reader.ReadSingle();
		Unknown_70h = reader.ReadSingle();
		Unknown_74h = reader.ReadSingle();
		Unknown_78h = reader.ReadSingle();
		Unknown_7Ch = reader.ReadSingle();
		Unknown_80h = reader.ReadSingle();
		Unknown_84h = reader.ReadSingle();
		Unknown_88h = reader.ReadSingle();
		Unknown_8Ch = reader.ReadSingle();
		Unknown_90h = reader.ReadSingle();
		Unknown_94h = reader.ReadSingle();
		Unknown_98h = reader.ReadSingle();
		Unknown_9Ch = reader.ReadSingle();
		Unknown_A0h = reader.ReadSingle();
		Unknown_A4h = reader.ReadSingle();
		Unknown_A8h = reader.ReadSingle();
		Unknown_ACh = reader.ReadSingle();
		Unknown_B0h = reader.ReadSingle();
		Unknown_B4h = reader.ReadSingle();
		Unknown_B8h = reader.ReadSingle();
		Unknown_BCh = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Unknown_0h);
		writer.Write(Unknown_4h);
		writer.Write(BoneId);
		writer.Write(Unknown_Ah);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
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
		writer.Write(Unknown_B0h);
		writer.Write(Unknown_B4h);
		writer.Write(Unknown_B8h);
		writer.Write(Unknown_BCh);
	}
}
