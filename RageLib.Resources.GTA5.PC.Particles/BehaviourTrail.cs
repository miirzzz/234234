using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Particles;

public class BehaviourTrail : Behaviour
{
	public ResourcePointerList64<KeyframeProp> KeyframeProps;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public KeyframeProp KeyframeProp0;

	public uint Unknown_C0h;

	public uint Unknown_C4h;

	public uint Unknown_C8h;

	public uint Unknown_CCh;

	public uint Unknown_D0h;

	public uint Unknown_D4h;

	public uint Unknown_D8h;

	public uint Unknown_DCh;

	public uint Unknown_E0h;

	public uint Unknown_E4h;

	public uint Unknown_E8h;

	public uint Unknown_ECh;

	public override long Length => 240L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		KeyframeProps = reader.ReadBlock<ResourcePointerList64<KeyframeProp>>(Array.Empty<object>());
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		KeyframeProp0 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		Unknown_C0h = reader.ReadUInt32();
		Unknown_C4h = reader.ReadUInt32();
		Unknown_C8h = reader.ReadUInt32();
		Unknown_CCh = reader.ReadUInt32();
		Unknown_D0h = reader.ReadUInt32();
		Unknown_D4h = reader.ReadUInt32();
		Unknown_D8h = reader.ReadUInt32();
		Unknown_DCh = reader.ReadUInt32();
		Unknown_E0h = reader.ReadUInt32();
		Unknown_E4h = reader.ReadUInt32();
		Unknown_E8h = reader.ReadUInt32();
		Unknown_ECh = reader.ReadUInt32();
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
		writer.Write(Unknown_C0h);
		writer.Write(Unknown_C4h);
		writer.Write(Unknown_C8h);
		writer.Write(Unknown_CCh);
		writer.Write(Unknown_D0h);
		writer.Write(Unknown_D4h);
		writer.Write(Unknown_D8h);
		writer.Write(Unknown_DCh);
		writer.Write(Unknown_E0h);
		writer.Write(Unknown_E4h);
		writer.Write(Unknown_E8h);
		writer.Write(Unknown_ECh);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[2]
		{
			new Tuple<long, IResourceBlock>(16L, KeyframeProps),
			new Tuple<long, IResourceBlock>(48L, KeyframeProp0)
		};
	}
}
