using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Particles;

public class Domain : ResourceSystemBlock, IResourceXXSystemBlock, IResourceSystemBlock, IResourceBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public byte Unknown_Ch;

	public byte Unknown_Dh;

	public ushort Unknown_Eh;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public KeyframeProp KeyframeProp0;

	public KeyframeProp KeyframeProp1;

	public KeyframeProp KeyframeProp2;

	public KeyframeProp KeyframeProp3;

	public uint Unknown_258h;

	public uint Unknown_25Ch;

	public ResourcePointerList64<KeyframeProp> KeyframeProps;

	public uint Unknown_270h;

	public uint Unknown_274h;

	public uint Unknown_278h;

	public uint Unknown_27Ch;

	public override long Length => 640L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadByte();
		Unknown_Dh = reader.ReadByte();
		Unknown_Eh = reader.ReadUInt16();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		KeyframeProp0 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp1 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp2 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp3 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		Unknown_258h = reader.ReadUInt32();
		Unknown_25Ch = reader.ReadUInt32();
		KeyframeProps = reader.ReadBlock<ResourcePointerList64<KeyframeProp>>(Array.Empty<object>());
		Unknown_270h = reader.ReadUInt32();
		Unknown_274h = reader.ReadUInt32();
		Unknown_278h = reader.ReadUInt32();
		Unknown_27Ch = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_Dh);
		writer.Write(Unknown_Eh);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.WriteBlock(KeyframeProp0);
		writer.WriteBlock(KeyframeProp1);
		writer.WriteBlock(KeyframeProp2);
		writer.WriteBlock(KeyframeProp3);
		writer.Write(Unknown_258h);
		writer.Write(Unknown_25Ch);
		writer.WriteBlock(KeyframeProps);
		writer.Write(Unknown_270h);
		writer.Write(Unknown_274h);
		writer.Write(Unknown_278h);
		writer.Write(Unknown_27Ch);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[5]
		{
			new Tuple<long, IResourceBlock>(24L, KeyframeProp0),
			new Tuple<long, IResourceBlock>(168L, KeyframeProp1),
			new Tuple<long, IResourceBlock>(312L, KeyframeProp2),
			new Tuple<long, IResourceBlock>(456L, KeyframeProp3),
			new Tuple<long, IResourceBlock>(608L, KeyframeProps)
		};
	}

	public IResourceSystemBlock GetType(ResourceDataReader reader, params object[] parameters)
	{
		reader.Position += 12L;
		byte b = reader.ReadByte();
		reader.Position -= 13L;
		return b switch
		{
			0 => new DomainBox(), 
			1 => new DomainSphere(), 
			2 => new DomainCylinder(), 
			3 => new DomainAttractor(), 
			_ => throw new Exception("Unknown domain type"), 
		};
	}
}
