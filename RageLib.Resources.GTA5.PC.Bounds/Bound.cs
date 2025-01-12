using System;

namespace RageLib.Resources.GTA5.PC.Bounds;

public class Bound : FileBase64_GTA5_pc, IResourceXXSystemBlock, IResourceSystemBlock, IResourceBlock
{
	public byte Type;

	public byte Unknown_11h;

	public ushort Unknown_12h;

	public float BoundingSphereRadius;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public RAGE_Vector3 BoundingBoxMax;

	public float Unknown_2Ch;

	public RAGE_Vector3 BoundingBoxMin;

	public uint Unknown_3Ch;

	public RAGE_Vector3 BoundingBoxCenter;

	public uint Unknown_4Ch;

	public RAGE_Vector3 Center;

	public uint Unknown_5Ch;

	public float Unknown_60h;

	public float Unknown_64h;

	public float Unknown_68h;

	public uint Unknown_6Ch;

	public override long Length => 112L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Type = reader.ReadByte();
		Unknown_11h = reader.ReadByte();
		Unknown_12h = reader.ReadUInt16();
		BoundingSphereRadius = reader.ReadSingle();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		BoundingBoxMax = reader.ReadBlock<RAGE_Vector3>(Array.Empty<object>());
		Unknown_2Ch = reader.ReadSingle();
		BoundingBoxMin = reader.ReadBlock<RAGE_Vector3>(Array.Empty<object>());
		Unknown_3Ch = reader.ReadUInt32();
		BoundingBoxCenter = reader.ReadBlock<RAGE_Vector3>(Array.Empty<object>());
		Unknown_4Ch = reader.ReadUInt32();
		Center = reader.ReadBlock<RAGE_Vector3>(Array.Empty<object>());
		Unknown_5Ch = reader.ReadUInt32();
		Unknown_60h = reader.ReadSingle();
		Unknown_64h = reader.ReadSingle();
		Unknown_68h = reader.ReadSingle();
		Unknown_6Ch = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		writer.Write(Type);
		writer.Write(Unknown_11h);
		writer.Write(Unknown_12h);
		writer.Write(BoundingSphereRadius);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.WriteBlock(BoundingBoxMax);
		writer.Write(Unknown_2Ch);
		writer.WriteBlock(BoundingBoxMin);
		writer.Write(Unknown_3Ch);
		writer.WriteBlock(BoundingBoxCenter);
		writer.Write(Unknown_4Ch);
		writer.WriteBlock(Center);
		writer.Write(Unknown_5Ch);
		writer.Write(Unknown_60h);
		writer.Write(Unknown_64h);
		writer.Write(Unknown_68h);
		writer.Write(Unknown_6Ch);
	}

	public IResourceSystemBlock GetType(ResourceDataReader reader, params object[] parameters)
	{
		reader.Position += 16L;
		byte b = reader.ReadByte();
		reader.Position -= 17L;
		return b switch
		{
			0 => new BoundSphere(), 
			1 => new BoundCapsule(), 
			3 => new BoundBox(), 
			4 => new BoundGeometry(), 
			8 => new BoundBVH(), 
			10 => new BoundComposite(), 
			12 => new BoundDisc(), 
			13 => new BoundCylinder(), 
			15 => new BoundPlane(), 
			_ => throw new Exception("Unknown bound type"), 
		};
	}
}
