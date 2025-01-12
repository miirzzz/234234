using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Fragments;

public class ArticulatedBodyType : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public uint Unknown_30h;

	public uint Unknown_34h;

	public uint Unknown_38h;

	public uint Unknown_3Ch;

	public uint Unknown_40h;

	public uint Unknown_44h;

	public uint Unknown_48h;

	public uint Unknown_4Ch;

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

	public ulong JointTypesPointer;

	public ulong p2;

	public byte c1;

	public byte JointTypesCount;

	public ushort Unknown_8Ah;

	public uint Unknown_8Ch;

	public uint Unknown_90h;

	public uint Unknown_94h;

	public uint Unknown_98h;

	public uint Unknown_9Ch;

	public uint Unknown_A0h;

	public uint Unknown_A4h;

	public uint Unknown_A8h;

	public uint Unknown_ACh;

	public ResourcePointerArray64<JointType> JointTypes;

	public ResourceSimpleArray<RAGE_Vector4> p2data;

	public override long Length => 176L;

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
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		Unknown_30h = reader.ReadUInt32();
		Unknown_34h = reader.ReadUInt32();
		Unknown_38h = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
		Unknown_40h = reader.ReadUInt32();
		Unknown_44h = reader.ReadUInt32();
		Unknown_48h = reader.ReadUInt32();
		Unknown_4Ch = reader.ReadUInt32();
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
		JointTypesPointer = reader.ReadUInt64();
		p2 = reader.ReadUInt64();
		c1 = reader.ReadByte();
		JointTypesCount = reader.ReadByte();
		Unknown_8Ah = reader.ReadUInt16();
		Unknown_8Ch = reader.ReadUInt32();
		Unknown_90h = reader.ReadUInt32();
		Unknown_94h = reader.ReadUInt32();
		Unknown_98h = reader.ReadUInt32();
		Unknown_9Ch = reader.ReadUInt32();
		Unknown_A0h = reader.ReadUInt32();
		Unknown_A4h = reader.ReadUInt32();
		Unknown_A8h = reader.ReadUInt32();
		Unknown_ACh = reader.ReadUInt32();
		JointTypes = reader.ReadBlockAt<ResourcePointerArray64<JointType>>(JointTypesPointer, new object[1] { JointTypesCount });
		p2data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Vector4>>(p2, new object[1] { c1 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		JointTypesPointer = (ulong)((JointTypes != null) ? JointTypes.Position : 0);
		p2 = (ulong)((p2data != null) ? p2data.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
		writer.Write(Unknown_30h);
		writer.Write(Unknown_34h);
		writer.Write(Unknown_38h);
		writer.Write(Unknown_3Ch);
		writer.Write(Unknown_40h);
		writer.Write(Unknown_44h);
		writer.Write(Unknown_48h);
		writer.Write(Unknown_4Ch);
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
		writer.Write(JointTypesPointer);
		writer.Write(p2);
		writer.Write(c1);
		writer.Write(JointTypesCount);
		writer.Write(Unknown_8Ah);
		writer.Write(Unknown_8Ch);
		writer.Write(Unknown_90h);
		writer.Write(Unknown_94h);
		writer.Write(Unknown_98h);
		writer.Write(Unknown_9Ch);
		writer.Write(Unknown_A0h);
		writer.Write(Unknown_A4h);
		writer.Write(Unknown_A8h);
		writer.Write(Unknown_ACh);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (JointTypes != null)
		{
			list.Add(JointTypes);
		}
		if (p2data != null)
		{
			list.Add(p2data);
		}
		return list.ToArray();
	}
}
