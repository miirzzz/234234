using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Particles;

public class BehaviourLight : Behaviour
{
	public ResourcePointerList64<KeyframeProp> KeyframeProps;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public KeyframeProp KeyframeProp0;

	public KeyframeProp KeyframeProp1;

	public KeyframeProp KeyframeProp2;

	public KeyframeProp KeyframeProp3;

	public KeyframeProp KeyframeProp4;

	public KeyframeProp KeyframeProp5;

	public KeyframeProp KeyframeProp6;

	public KeyframeProp KeyframeProp7;

	public KeyframeProp KeyframeProp8;

	public uint Unknown_540h;

	public uint Unknown_544h;

	public uint Unknown_548h;

	public uint Unknown_54Ch;

	public override long Length => 1360L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		KeyframeProps = reader.ReadBlock<ResourcePointerList64<KeyframeProp>>(Array.Empty<object>());
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		KeyframeProp0 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp1 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp2 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp3 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp4 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp5 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp6 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp7 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp8 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		Unknown_540h = reader.ReadUInt32();
		Unknown_544h = reader.ReadUInt32();
		Unknown_548h = reader.ReadUInt32();
		Unknown_54Ch = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		writer.WriteBlock(KeyframeProps);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
		writer.WriteBlock(KeyframeProp0);
		writer.WriteBlock(KeyframeProp1);
		writer.WriteBlock(KeyframeProp2);
		writer.WriteBlock(KeyframeProp3);
		writer.WriteBlock(KeyframeProp4);
		writer.WriteBlock(KeyframeProp5);
		writer.WriteBlock(KeyframeProp6);
		writer.WriteBlock(KeyframeProp7);
		writer.WriteBlock(KeyframeProp8);
		writer.Write(Unknown_540h);
		writer.Write(Unknown_544h);
		writer.Write(Unknown_548h);
		writer.Write(Unknown_54Ch);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[10]
		{
			new Tuple<long, IResourceBlock>(16L, KeyframeProps),
			new Tuple<long, IResourceBlock>(48L, KeyframeProp0),
			new Tuple<long, IResourceBlock>(192L, KeyframeProp1),
			new Tuple<long, IResourceBlock>(336L, KeyframeProp2),
			new Tuple<long, IResourceBlock>(480L, KeyframeProp3),
			new Tuple<long, IResourceBlock>(624L, KeyframeProp4),
			new Tuple<long, IResourceBlock>(768L, KeyframeProp5),
			new Tuple<long, IResourceBlock>(912L, KeyframeProp6),
			new Tuple<long, IResourceBlock>(1056L, KeyframeProp7),
			new Tuple<long, IResourceBlock>(1200L, KeyframeProp8)
		};
	}
}
