namespace RageLib.Resources.GTA5.PC.Expressions;

public class Unknown_E_002 : ResourceSystemBlock
{
	public float Unknown_0h;

	public float Unknown_4h;

	public float Unknown_8h;

	public uint Unknown_Ch;

	public float Unknown_10h;

	public float Unknown_14h;

	public float Unknown_18h;

	public uint Unknown_1Ch;

	public float Unknown_20h;

	public float Unknown_24h;

	public float Unknown_28h;

	public uint Unknown_2Ch;

	public float Unknown_30h;

	public float Unknown_34h;

	public float Unknown_38h;

	public uint Unknown_3Ch;

	public float Unknown_40h;

	public float Unknown_44h;

	public float Unknown_48h;

	public uint Unknown_4Ch;

	public float Unknown_50h;

	public float Unknown_54h;

	public float Unknown_58h;

	public uint Unknown_5Ch;

	public float Unknown_60h;

	public float Unknown_64h;

	public float Unknown_68h;

	public uint Unknown_6Ch;

	public float Unknown_70h;

	public float Unknown_74h;

	public float Unknown_78h;

	public uint Unknown_7Ch;

	public float Unknown_80h;

	public float Unknown_84h;

	public float Unknown_88h;

	public uint Unknown_8Ch;

	public float Unknown_90h;

	public float Unknown_94h;

	public float Unknown_98h;

	public uint Unknown_9Ch;

	public override long Length => 160L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadSingle();
		Unknown_4h = reader.ReadSingle();
		Unknown_8h = reader.ReadSingle();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadSingle();
		Unknown_14h = reader.ReadSingle();
		Unknown_18h = reader.ReadSingle();
		Unknown_1Ch = reader.ReadUInt32();
		Unknown_20h = reader.ReadSingle();
		Unknown_24h = reader.ReadSingle();
		Unknown_28h = reader.ReadSingle();
		Unknown_2Ch = reader.ReadUInt32();
		Unknown_30h = reader.ReadSingle();
		Unknown_34h = reader.ReadSingle();
		Unknown_38h = reader.ReadSingle();
		Unknown_3Ch = reader.ReadUInt32();
		Unknown_40h = reader.ReadSingle();
		Unknown_44h = reader.ReadSingle();
		Unknown_48h = reader.ReadSingle();
		Unknown_4Ch = reader.ReadUInt32();
		Unknown_50h = reader.ReadSingle();
		Unknown_54h = reader.ReadSingle();
		Unknown_58h = reader.ReadSingle();
		Unknown_5Ch = reader.ReadUInt32();
		Unknown_60h = reader.ReadSingle();
		Unknown_64h = reader.ReadSingle();
		Unknown_68h = reader.ReadSingle();
		Unknown_6Ch = reader.ReadUInt32();
		Unknown_70h = reader.ReadSingle();
		Unknown_74h = reader.ReadSingle();
		Unknown_78h = reader.ReadSingle();
		Unknown_7Ch = reader.ReadUInt32();
		Unknown_80h = reader.ReadSingle();
		Unknown_84h = reader.ReadSingle();
		Unknown_88h = reader.ReadSingle();
		Unknown_8Ch = reader.ReadUInt32();
		Unknown_90h = reader.ReadSingle();
		Unknown_94h = reader.ReadSingle();
		Unknown_98h = reader.ReadSingle();
		Unknown_9Ch = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Unknown_0h);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
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
	}
}
