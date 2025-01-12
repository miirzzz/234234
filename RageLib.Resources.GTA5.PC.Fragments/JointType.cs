using System;

namespace RageLib.Resources.GTA5.PC.Fragments;

public class JointType : ResourceSystemBlock, IResourceXXSystemBlock, IResourceSystemBlock, IResourceBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public byte Unknown_14h;

	public byte Type;

	public ushort Unknown_16h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public override long Length => 32L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadByte();
		Type = reader.ReadByte();
		Unknown_16h = reader.ReadUInt16();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Type);
		writer.Write(Unknown_16h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
	}

	public IResourceSystemBlock GetType(ResourceDataReader reader, params object[] parameters)
	{
		reader.Position += 21L;
		byte b = reader.ReadByte();
		reader.Position -= 22L;
		return b switch
		{
			0 => new Joint1DofType(), 
			1 => new Joint3DofType(), 
			_ => throw new Exception("Unknown type"), 
		};
	}
}
