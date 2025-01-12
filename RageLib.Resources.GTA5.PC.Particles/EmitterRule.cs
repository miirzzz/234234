using System;
using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Particles;

public class EmitterRule : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public ulong NamePointer;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public uint Unknown_30h;

	public uint Unknown_34h;

	public ulong p2;

	public uint Unknown_40h;

	public uint Unknown_44h;

	public ulong p3;

	public uint Unknown_50h;

	public uint Unknown_54h;

	public ulong p4;

	public uint Unknown_60h;

	public uint Unknown_64h;

	public uint Unknown_68h;

	public uint Unknown_6Ch;

	public uint Unknown_70h;

	public uint Unknown_74h;

	public KeyframeProp KeyframeProp0;

	public KeyframeProp KeyframeProp1;

	public KeyframeProp KeyframeProp2;

	public KeyframeProp KeyframeProp3;

	public KeyframeProp KeyframeProp4;

	public KeyframeProp KeyframeProp5;

	public KeyframeProp KeyframeProp6;

	public KeyframeProp KeyframeProp7;

	public KeyframeProp KeyframeProp8;

	public KeyframeProp KeyframeProp9;

	public ulong KeyframePropsPointer;

	public ushort KeyframePropsCount1;

	public ushort KeyframePropsCount2;

	public uint Unknown_624h;

	public uint Unknown_628h;

	public uint Unknown_62Ch;

	public string_r Name;

	public Domain p2data;

	public Domain p3data;

	public Domain p4data;

	public ResourcePointerArray64<KeyframeProp> KeyframeProps;

	public override long Length => 1584L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		NamePointer = reader.ReadUInt64();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		Unknown_30h = reader.ReadUInt32();
		Unknown_34h = reader.ReadUInt32();
		p2 = reader.ReadUInt64();
		Unknown_40h = reader.ReadUInt32();
		Unknown_44h = reader.ReadUInt32();
		p3 = reader.ReadUInt64();
		Unknown_50h = reader.ReadUInt32();
		Unknown_54h = reader.ReadUInt32();
		p4 = reader.ReadUInt64();
		Unknown_60h = reader.ReadUInt32();
		Unknown_64h = reader.ReadUInt32();
		Unknown_68h = reader.ReadUInt32();
		Unknown_6Ch = reader.ReadUInt32();
		Unknown_70h = reader.ReadUInt32();
		Unknown_74h = reader.ReadUInt32();
		KeyframeProp0 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp1 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp2 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp3 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp4 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp5 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp6 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp7 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp8 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp9 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframePropsPointer = reader.ReadUInt64();
		KeyframePropsCount1 = reader.ReadUInt16();
		KeyframePropsCount2 = reader.ReadUInt16();
		Unknown_624h = reader.ReadUInt32();
		Unknown_628h = reader.ReadUInt32();
		Unknown_62Ch = reader.ReadUInt32();
		Name = reader.ReadBlockAt<string_r>(NamePointer, Array.Empty<object>());
		p2data = reader.ReadBlockAt<Domain>(p2, Array.Empty<object>());
		p3data = reader.ReadBlockAt<Domain>(p3, Array.Empty<object>());
		p4data = reader.ReadBlockAt<Domain>(p4, Array.Empty<object>());
		KeyframeProps = reader.ReadBlockAt<ResourcePointerArray64<KeyframeProp>>(KeyframePropsPointer, new object[1] { KeyframePropsCount2 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		NamePointer = (ulong)((Name != null) ? Name.Position : 0);
		p2 = (ulong)((p2data != null) ? p2data.Position : 0);
		p3 = (ulong)((p3data != null) ? p3data.Position : 0);
		p4 = (ulong)((p4data != null) ? p4data.Position : 0);
		KeyframePropsPointer = (ulong)((KeyframeProps != null) ? KeyframeProps.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.Write(NamePointer);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
		writer.Write(Unknown_30h);
		writer.Write(Unknown_34h);
		writer.Write(p2);
		writer.Write(Unknown_40h);
		writer.Write(Unknown_44h);
		writer.Write(p3);
		writer.Write(Unknown_50h);
		writer.Write(Unknown_54h);
		writer.Write(p4);
		writer.Write(Unknown_60h);
		writer.Write(Unknown_64h);
		writer.Write(Unknown_68h);
		writer.Write(Unknown_6Ch);
		writer.Write(Unknown_70h);
		writer.Write(Unknown_74h);
		writer.WriteBlock(KeyframeProp0);
		writer.WriteBlock(KeyframeProp1);
		writer.WriteBlock(KeyframeProp2);
		writer.WriteBlock(KeyframeProp3);
		writer.WriteBlock(KeyframeProp4);
		writer.WriteBlock(KeyframeProp5);
		writer.WriteBlock(KeyframeProp6);
		writer.WriteBlock(KeyframeProp7);
		writer.WriteBlock(KeyframeProp8);
		writer.WriteBlock(KeyframeProp9);
		writer.Write(KeyframePropsPointer);
		writer.Write(KeyframePropsCount1);
		writer.Write(KeyframePropsCount2);
		writer.Write(Unknown_624h);
		writer.Write(Unknown_628h);
		writer.Write(Unknown_62Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Name != null)
		{
			list.Add(Name);
		}
		if (p2data != null)
		{
			list.Add(p2data);
		}
		if (p3data != null)
		{
			list.Add(p3data);
		}
		if (p4data != null)
		{
			list.Add(p4data);
		}
		if (KeyframeProps != null)
		{
			list.Add(KeyframeProps);
		}
		return list.ToArray();
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[10]
		{
			new Tuple<long, IResourceBlock>(120L, KeyframeProp0),
			new Tuple<long, IResourceBlock>(264L, KeyframeProp1),
			new Tuple<long, IResourceBlock>(408L, KeyframeProp2),
			new Tuple<long, IResourceBlock>(552L, KeyframeProp3),
			new Tuple<long, IResourceBlock>(696L, KeyframeProp4),
			new Tuple<long, IResourceBlock>(840L, KeyframeProp5),
			new Tuple<long, IResourceBlock>(984L, KeyframeProp6),
			new Tuple<long, IResourceBlock>(1128L, KeyframeProp7),
			new Tuple<long, IResourceBlock>(1272L, KeyframeProp8),
			new Tuple<long, IResourceBlock>(1416L, KeyframeProp9)
		};
	}
}
