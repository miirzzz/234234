using System;
using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Particles;

public class EffectRule : ResourceSystemBlock
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

	public ulong EventEmittersPointer;

	public ushort EventEmittersCount1;

	public ushort EventEmittersCount2;

	public uint Unknown_44h;

	public ulong p4;

	public uint Unknown_50h;

	public uint Unknown_54h;

	public uint Unknown_58h;

	public uint Unknown_5Ch;

	public uint Unknown_60h;

	public uint Unknown_64h;

	public uint Unknown_68h;

	public uint Unknown_6Ch;

	public uint Unknown_70h;

	public uint Unknown_74h;

	public uint Unknown_78h;

	public uint Unknown_7Ch;

	public uint Unknown_80h;

	public uint Unknown_84h;

	public uint Unknown_88h;

	public uint Unknown_8Ch;

	public uint Unknown_90h;

	public uint Unknown_94h;

	public uint Unknown_98h;

	public uint Unknown_9Ch;

	public uint Unknown_A0h;

	public uint Unknown_A4h;

	public uint Unknown_A8h;

	public uint Unknown_ACh;

	public uint Unknown_B0h;

	public uint Unknown_B4h;

	public uint Unknown_B8h;

	public uint Unknown_BCh;

	public KeyframeProp KeyframeProp0;

	public KeyframeProp KeyframeProp1;

	public KeyframeProp KeyframeProp2;

	public KeyframeProp KeyframeProp3;

	public KeyframeProp KeyframeProp4;

	public ulong KeyframePropsPointer;

	public ushort KeyframePropsCount1;

	public ushort KeyframePropsCount2;

	public uint Unknown_39Ch;

	public uint Unknown_3A0h;

	public uint Unknown_3A4h;

	public uint Unknown_3A8h;

	public uint Unknown_3ACh;

	public uint Unknown_3B0h;

	public uint Unknown_3B4h;

	public uint Unknown_3B8h;

	public uint Unknown_3BCh;

	public string_r Name;

	public ResourcePointerArray64<EventEmitter> EventEmitters;

	public Unknown_P_004 p4data;

	public ResourcePointerArray64<KeyframeProp> KeyframeProps;

	public override long Length => 960L;

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
		EventEmittersPointer = reader.ReadUInt64();
		EventEmittersCount1 = reader.ReadUInt16();
		EventEmittersCount2 = reader.ReadUInt16();
		Unknown_44h = reader.ReadUInt32();
		p4 = reader.ReadUInt64();
		Unknown_50h = reader.ReadUInt32();
		Unknown_54h = reader.ReadUInt32();
		Unknown_58h = reader.ReadUInt32();
		Unknown_5Ch = reader.ReadUInt32();
		Unknown_60h = reader.ReadUInt32();
		Unknown_64h = reader.ReadUInt32();
		Unknown_68h = reader.ReadUInt32();
		Unknown_6Ch = reader.ReadUInt32();
		Unknown_70h = reader.ReadUInt32();
		Unknown_74h = reader.ReadUInt32();
		Unknown_78h = reader.ReadUInt32();
		Unknown_7Ch = reader.ReadUInt32();
		Unknown_80h = reader.ReadUInt32();
		Unknown_84h = reader.ReadUInt32();
		Unknown_88h = reader.ReadUInt32();
		Unknown_8Ch = reader.ReadUInt32();
		Unknown_90h = reader.ReadUInt32();
		Unknown_94h = reader.ReadUInt32();
		Unknown_98h = reader.ReadUInt32();
		Unknown_9Ch = reader.ReadUInt32();
		Unknown_A0h = reader.ReadUInt32();
		Unknown_A4h = reader.ReadUInt32();
		Unknown_A8h = reader.ReadUInt32();
		Unknown_ACh = reader.ReadUInt32();
		Unknown_B0h = reader.ReadUInt32();
		Unknown_B4h = reader.ReadUInt32();
		Unknown_B8h = reader.ReadUInt32();
		Unknown_BCh = reader.ReadUInt32();
		KeyframeProp0 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp1 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp2 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp3 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframeProp4 = reader.ReadBlock<KeyframeProp>(Array.Empty<object>());
		KeyframePropsPointer = reader.ReadUInt64();
		KeyframePropsCount1 = reader.ReadUInt16();
		KeyframePropsCount2 = reader.ReadUInt16();
		Unknown_39Ch = reader.ReadUInt32();
		Unknown_3A0h = reader.ReadUInt32();
		Unknown_3A4h = reader.ReadUInt32();
		Unknown_3A8h = reader.ReadUInt32();
		Unknown_3ACh = reader.ReadUInt32();
		Unknown_3B0h = reader.ReadUInt32();
		Unknown_3B4h = reader.ReadUInt32();
		Unknown_3B8h = reader.ReadUInt32();
		Unknown_3BCh = reader.ReadUInt32();
		Name = reader.ReadBlockAt<string_r>(NamePointer, Array.Empty<object>());
		EventEmitters = reader.ReadBlockAt<ResourcePointerArray64<EventEmitter>>(EventEmittersPointer, new object[1] { EventEmittersCount1 });
		p4data = reader.ReadBlockAt<Unknown_P_004>(p4, Array.Empty<object>());
		KeyframeProps = reader.ReadBlockAt<ResourcePointerArray64<KeyframeProp>>(KeyframePropsPointer, new object[1] { KeyframePropsCount2 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		NamePointer = (ulong)((Name != null) ? Name.Position : 0);
		EventEmittersPointer = (ulong)((EventEmitters != null) ? EventEmitters.Position : 0);
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
		writer.Write(EventEmittersPointer);
		writer.Write(EventEmittersCount1);
		writer.Write(EventEmittersCount2);
		writer.Write(Unknown_44h);
		writer.Write(p4);
		writer.Write(Unknown_50h);
		writer.Write(Unknown_54h);
		writer.Write(Unknown_58h);
		writer.Write(Unknown_5Ch);
		writer.Write(Unknown_60h);
		writer.Write(Unknown_64h);
		writer.Write(Unknown_68h);
		writer.Write(Unknown_6Ch);
		writer.Write(Unknown_70h);
		writer.Write(Unknown_74h);
		writer.Write(Unknown_78h);
		writer.Write(Unknown_7Ch);
		writer.Write(Unknown_80h);
		writer.Write(Unknown_84h);
		writer.Write(Unknown_88h);
		writer.Write(Unknown_8Ch);
		writer.Write(Unknown_90h);
		writer.Write(Unknown_94h);
		writer.Write(Unknown_98h);
		writer.Write(Unknown_9Ch);
		writer.Write(Unknown_A0h);
		writer.Write(Unknown_A4h);
		writer.Write(Unknown_A8h);
		writer.Write(Unknown_ACh);
		writer.Write(Unknown_B0h);
		writer.Write(Unknown_B4h);
		writer.Write(Unknown_B8h);
		writer.Write(Unknown_BCh);
		writer.WriteBlock(KeyframeProp0);
		writer.WriteBlock(KeyframeProp1);
		writer.WriteBlock(KeyframeProp2);
		writer.WriteBlock(KeyframeProp3);
		writer.WriteBlock(KeyframeProp4);
		writer.Write(KeyframePropsPointer);
		writer.Write(KeyframePropsCount1);
		writer.Write(KeyframePropsCount2);
		writer.Write(Unknown_39Ch);
		writer.Write(Unknown_3A0h);
		writer.Write(Unknown_3A4h);
		writer.Write(Unknown_3A8h);
		writer.Write(Unknown_3ACh);
		writer.Write(Unknown_3B0h);
		writer.Write(Unknown_3B4h);
		writer.Write(Unknown_3B8h);
		writer.Write(Unknown_3BCh);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Name != null)
		{
			list.Add(Name);
		}
		if (EventEmitters != null)
		{
			list.Add(EventEmitters);
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
		return new Tuple<long, IResourceBlock>[5]
		{
			new Tuple<long, IResourceBlock>(192L, KeyframeProp0),
			new Tuple<long, IResourceBlock>(336L, KeyframeProp1),
			new Tuple<long, IResourceBlock>(480L, KeyframeProp2),
			new Tuple<long, IResourceBlock>(624L, KeyframeProp3),
			new Tuple<long, IResourceBlock>(768L, KeyframeProp4)
		};
	}
}
