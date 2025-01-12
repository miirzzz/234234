using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Particles;

public class BehaviourDampening : Behaviour
{
	public ResourcePointerList64<KeyframeProp> KeyframeProps;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public KeyframeProp KeyframeProp0;

	public KeyframeProp KeyframeProp1;

	public uint Unknown_150h;

	public uint Unknown_154h;

	public uint Unknown_158h;

	public uint Unknown_15Ch;

	public uint Unknown_160h;

	public uint Unknown_164h;

	public uint Unknown_168h;

	public uint Unknown_16Ch;

	public override long Length => 368L;

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
		Unknown_150h = reader.ReadUInt32();
		Unknown_154h = reader.ReadUInt32();
		Unknown_158h = reader.ReadUInt32();
		Unknown_15Ch = reader.ReadUInt32();
		Unknown_160h = reader.ReadUInt32();
		Unknown_164h = reader.ReadUInt32();
		Unknown_168h = reader.ReadUInt32();
		Unknown_16Ch = reader.ReadUInt32();
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
		writer.Write(Unknown_150h);
		writer.Write(Unknown_154h);
		writer.Write(Unknown_158h);
		writer.Write(Unknown_15Ch);
		writer.Write(Unknown_160h);
		writer.Write(Unknown_164h);
		writer.Write(Unknown_168h);
		writer.Write(Unknown_16Ch);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[3]
		{
			new Tuple<long, IResourceBlock>(16L, KeyframeProps),
			new Tuple<long, IResourceBlock>(48L, KeyframeProp0),
			new Tuple<long, IResourceBlock>(192L, KeyframeProp1)
		};
	}
}
