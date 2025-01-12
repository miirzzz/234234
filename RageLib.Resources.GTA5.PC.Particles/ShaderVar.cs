using System;

namespace RageLib.Resources.GTA5.PC.Particles;

public class ShaderVar : ResourceSystemBlock, IResourceXXSystemBlock, IResourceSystemBlock, IResourceBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public byte Type;

	public byte Unknown_15h;

	public ushort Unknown_16h;

	public override long Length => 24L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Type = reader.ReadByte();
		Unknown_15h = reader.ReadByte();
		Unknown_16h = reader.ReadUInt16();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Type);
		writer.Write(Unknown_15h);
		writer.Write(Unknown_16h);
	}

	public IResourceSystemBlock GetType(ResourceDataReader reader, params object[] parameters)
	{
		reader.Position += 20L;
		byte b = reader.ReadByte();
		reader.Position -= 21L;
		switch (b)
		{
		case 2:
		case 4:
			return new ShaderVarVector();
		case 6:
			return new ShaderVarTexture();
		case 7:
			return new ShaderVarKeyframe();
		default:
			throw new Exception("Unknown shader var type");
		}
	}
}
