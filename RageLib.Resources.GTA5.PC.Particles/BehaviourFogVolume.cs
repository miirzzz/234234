using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Particles;

public class BehaviourFogVolume : Behaviour
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

	public uint Unknown_420h;

	public uint Unknown_424h;

	public uint Unknown_428h;

	public uint Unknown_42Ch;

	public override long Length => 1072L;

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
		Unknown_420h = reader.ReadUInt32();
		Unknown_424h = reader.ReadUInt32();
		Unknown_428h = reader.ReadUInt32();
		Unknown_42Ch = reader.ReadUInt32();
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
		writer.Write(Unknown_420h);
		writer.Write(Unknown_424h);
		writer.Write(Unknown_428h);
		writer.Write(Unknown_42Ch);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[8]
		{
			new Tuple<long, IResourceBlock>(16L, KeyframeProps),
			new Tuple<long, IResourceBlock>(48L, KeyframeProp0),
			new Tuple<long, IResourceBlock>(192L, KeyframeProp1),
			new Tuple<long, IResourceBlock>(336L, KeyframeProp2),
			new Tuple<long, IResourceBlock>(480L, KeyframeProp3),
			new Tuple<long, IResourceBlock>(624L, KeyframeProp4),
			new Tuple<long, IResourceBlock>(768L, KeyframeProp5),
			new Tuple<long, IResourceBlock>(912L, KeyframeProp6)
		};
	}
}
