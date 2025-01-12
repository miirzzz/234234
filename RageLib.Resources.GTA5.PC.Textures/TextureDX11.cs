using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Textures;

public class TextureDX11 : Texture
{
	public uint Unknown_40h;

	public uint Unknown_44h;

	public uint Unknown_48h;

	public uint Unknown_4Ch;

	public ushort Width;

	public ushort Height;

	public ushort Unknown_54h;

	public ushort Stride;

	public uint Format;

	public byte Unknown_5Ch;

	public byte Levels;

	public ushort Unknown_5Eh;

	public uint Unknown_60h;

	public uint Unknown_64h;

	public uint Unknown_68h;

	public uint Unknown_6Ch;

	public ulong DataPointer;

	public uint Unknown_78h;

	public uint Unknown_7Ch;

	public uint Unknown_80h;

	public uint Unknown_84h;

	public uint Unknown_88h;

	public uint Unknown_8Ch;

	public TextureData_GTA5_pc Data;

	public override long Length => 144L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Unknown_40h = reader.ReadUInt32();
		Unknown_44h = reader.ReadUInt32();
		Unknown_48h = reader.ReadUInt32();
		Unknown_4Ch = reader.ReadUInt32();
		Width = reader.ReadUInt16();
		Height = reader.ReadUInt16();
		Unknown_54h = reader.ReadUInt16();
		Stride = reader.ReadUInt16();
		Format = reader.ReadUInt32();
		Unknown_5Ch = reader.ReadByte();
		Levels = reader.ReadByte();
		Unknown_5Eh = reader.ReadUInt16();
		Unknown_60h = reader.ReadUInt32();
		Unknown_64h = reader.ReadUInt32();
		Unknown_68h = reader.ReadUInt32();
		Unknown_6Ch = reader.ReadUInt32();
		DataPointer = reader.ReadUInt64();
		Unknown_78h = reader.ReadUInt32();
		Unknown_7Ch = reader.ReadUInt32();
		Unknown_80h = reader.ReadUInt32();
		Unknown_84h = reader.ReadUInt32();
		Unknown_88h = reader.ReadUInt32();
		Unknown_8Ch = reader.ReadUInt32();
		Data = reader.ReadBlockAt<TextureData_GTA5_pc>(DataPointer, new object[5] { Format, Width, Height, Levels, Stride });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		DataPointer = (ulong)Data.Position;
		writer.Write(Unknown_40h);
		writer.Write(Unknown_44h);
		writer.Write(Unknown_48h);
		writer.Write(Unknown_4Ch);
		writer.Write(Width);
		writer.Write(Height);
		writer.Write(Unknown_54h);
		writer.Write(Stride);
		writer.Write(Format);
		writer.Write(Unknown_5Ch);
		writer.Write(Levels);
		writer.Write(Unknown_5Eh);
		writer.Write(Unknown_60h);
		writer.Write(Unknown_64h);
		writer.Write(Unknown_68h);
		writer.Write(Unknown_6Ch);
		writer.Write(DataPointer);
		writer.Write(Unknown_78h);
		writer.Write(Unknown_7Ch);
		writer.Write(Unknown_80h);
		writer.Write(Unknown_84h);
		writer.Write(Unknown_88h);
		writer.Write(Unknown_8Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		return new List<IResourceBlock>(base.GetReferences()) { Data }.ToArray();
	}
}
