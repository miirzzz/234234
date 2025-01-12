using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Particles;

public class BehaviourNoise : Behaviour
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

	public uint Unknown_270h;

	public uint Unknown_274h;

	public uint Unknown_278h;

	public uint Unknown_27Ch;

	public override long Length => 640L;

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
		Unknown_270h = reader.ReadUInt32();
		Unknown_274h = reader.ReadUInt32();
		Unknown_278h = reader.ReadUInt32();
		Unknown_27Ch = reader.ReadUInt32();
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
		writer.Write(Unknown_270h);
		writer.Write(Unknown_274h);
		writer.Write(Unknown_278h);
		writer.Write(Unknown_27Ch);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[5]
		{
			new Tuple<long, IResourceBlock>(16L, KeyframeProps),
			new Tuple<long, IResourceBlock>(48L, KeyframeProp0),
			new Tuple<long, IResourceBlock>(192L, KeyframeProp1),
			new Tuple<long, IResourceBlock>(336L, KeyframeProp2),
			new Tuple<long, IResourceBlock>(480L, KeyframeProp3)
		};
	}
}
