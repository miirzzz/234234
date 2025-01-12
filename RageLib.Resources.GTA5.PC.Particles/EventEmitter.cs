using System;
using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Particles;

public class EventEmitter : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public ulong p1;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public ulong p2;

	public ulong p3;

	public ulong p4;

	public ulong p5;

	public uint Unknown_50h;

	public uint Unknown_54h;

	public uint Unknown_58h;

	public uint Unknown_5Ch;

	public uint Unknown_60h;

	public uint Unknown_64h;

	public uint Unknown_68h;

	public uint Unknown_6Ch;

	public Unknown_P_005 p1data;

	public string_r p2data;

	public string_r p3data;

	public EmitterRule EmitterRule;

	public ParticleRule ParticleRule;

	public override long Length => 112L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		p1 = reader.ReadUInt64();
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		p2 = reader.ReadUInt64();
		p3 = reader.ReadUInt64();
		p4 = reader.ReadUInt64();
		p5 = reader.ReadUInt64();
		Unknown_50h = reader.ReadUInt32();
		Unknown_54h = reader.ReadUInt32();
		Unknown_58h = reader.ReadUInt32();
		Unknown_5Ch = reader.ReadUInt32();
		Unknown_60h = reader.ReadUInt32();
		Unknown_64h = reader.ReadUInt32();
		Unknown_68h = reader.ReadUInt32();
		Unknown_6Ch = reader.ReadUInt32();
		p1data = reader.ReadBlockAt<Unknown_P_005>(p1, Array.Empty<object>());
		p2data = reader.ReadBlockAt<string_r>(p2, Array.Empty<object>());
		p3data = reader.ReadBlockAt<string_r>(p3, Array.Empty<object>());
		EmitterRule = reader.ReadBlockAt<EmitterRule>(p4, Array.Empty<object>());
		ParticleRule = reader.ReadBlockAt<ParticleRule>(p5, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		p1 = (ulong)((p1data != null) ? p1data.Position : 0);
		p2 = (ulong)((p2data != null) ? p2data.Position : 0);
		p3 = (ulong)((p3data != null) ? p3data.Position : 0);
		p4 = (ulong)((EmitterRule != null) ? EmitterRule.Position : 0);
		p5 = (ulong)((ParticleRule != null) ? ParticleRule.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(p1);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
		writer.Write(p2);
		writer.Write(p3);
		writer.Write(p4);
		writer.Write(p5);
		writer.Write(Unknown_50h);
		writer.Write(Unknown_54h);
		writer.Write(Unknown_58h);
		writer.Write(Unknown_5Ch);
		writer.Write(Unknown_60h);
		writer.Write(Unknown_64h);
		writer.Write(Unknown_68h);
		writer.Write(Unknown_6Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (p1data != null)
		{
			list.Add(p1data);
		}
		if (p2data != null)
		{
			list.Add(p2data);
		}
		if (p3data != null)
		{
			list.Add(p3data);
		}
		if (EmitterRule != null)
		{
			list.Add(EmitterRule);
		}
		if (ParticleRule != null)
		{
			list.Add(ParticleRule);
		}
		return list.ToArray();
	}
}
