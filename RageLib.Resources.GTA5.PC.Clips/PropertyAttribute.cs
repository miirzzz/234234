using System;

namespace RageLib.Resources.GTA5.PC.Clips;

public class PropertyAttribute : ResourceSystemBlock, IResourceXXSystemBlock, IResourceSystemBlock, IResourceBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public byte Type;

	public byte Unknown_9h;

	public ushort Unknown_Ah;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint NameHash;

	public uint Unknown_1Ch;

	public override long Length => 32L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Type = reader.ReadByte();
		Unknown_9h = reader.ReadByte();
		Unknown_Ah = reader.ReadUInt16();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		NameHash = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Type);
		writer.Write(Unknown_9h);
		writer.Write(Unknown_Ah);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(NameHash);
		writer.Write(Unknown_1Ch);
	}

	public IResourceSystemBlock GetType(ResourceDataReader reader, params object[] parameters)
	{
		reader.Position += 8L;
		byte b = reader.ReadByte();
		reader.Position -= 9L;
		return b switch
		{
			1 => new PropertyAttributeFloat(), 
			2 => new PropertyAttributeInt(), 
			3 => new PropertyAttributeBool(), 
			4 => new PropertyAttributeString(), 
			6 => new PropertyAttributeVector3(), 
			8 => new PropertyAttributeQuaternion(), 
			12 => new PropertyAttributeHashString(), 
			_ => throw new Exception("Unknown attribute type"), 
		};
	}
}
