using System;
using System.Collections.Generic;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Bounds;
using RageLib.Resources.GTA5.PC.Drawables;

namespace RageLib.Resources.GTA5.PC.Fragments;

public class FragDrawable : Drawable
{
	public uint Unknown_A8h;

	public uint Unknown_ACh;

	public RAGE_Matrix4 Unknown_B0h;

	public ulong BoundPointer;

	public ulong Unknown_F8h_Pointer;

	public ushort Count1;

	public ushort Count2;

	public uint Unknown_104h;

	public ulong Unknown_108h_Pointer;

	public ushort Count3;

	public ushort Count4;

	public uint Unknown_114h;

	public uint Unknown_118h;

	public uint Unknown_11Ch;

	public uint Unknown_120h;

	public uint Unknown_124h;

	public uint Unknown_128h;

	public uint Unknown_12Ch;

	public ulong NamePointer;

	public uint Unknown_138h;

	public uint Unknown_13Ch;

	public uint Unknown_140h;

	public uint Unknown_144h;

	public uint Unknown_148h;

	public uint Unknown_14Ch;

	public Bound Bound;

	public ResourceSimpleArray<ulong_r> Unknown_F8h_Data;

	public ResourceSimpleArray<RAGE_Matrix4> Unknown_108h_Data;

	public string_r Name;

	public override long Length => 336L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Unknown_A8h = reader.ReadUInt32();
		Unknown_ACh = reader.ReadUInt32();
		Unknown_B0h = reader.ReadBlock<RAGE_Matrix4>(Array.Empty<object>());
		BoundPointer = reader.ReadUInt64();
		Unknown_F8h_Pointer = reader.ReadUInt64();
		Count1 = reader.ReadUInt16();
		Count2 = reader.ReadUInt16();
		Unknown_104h = reader.ReadUInt32();
		Unknown_108h_Pointer = reader.ReadUInt64();
		Count3 = reader.ReadUInt16();
		Count4 = reader.ReadUInt16();
		Unknown_114h = reader.ReadUInt32();
		Unknown_118h = reader.ReadUInt32();
		Unknown_11Ch = reader.ReadUInt32();
		Unknown_120h = reader.ReadUInt32();
		Unknown_124h = reader.ReadUInt32();
		Unknown_128h = reader.ReadUInt32();
		Unknown_12Ch = reader.ReadUInt32();
		NamePointer = reader.ReadUInt64();
		Unknown_138h = reader.ReadUInt32();
		Unknown_13Ch = reader.ReadUInt32();
		Unknown_140h = reader.ReadUInt32();
		Unknown_144h = reader.ReadUInt32();
		Unknown_148h = reader.ReadUInt32();
		Unknown_14Ch = reader.ReadUInt32();
		Bound = reader.ReadBlockAt<Bound>(BoundPointer, Array.Empty<object>());
		Unknown_F8h_Data = reader.ReadBlockAt<ResourceSimpleArray<ulong_r>>(Unknown_F8h_Pointer, new object[1] { Count1 });
		Unknown_108h_Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Matrix4>>(Unknown_108h_Pointer, new object[1] { Count2 });
		Name = reader.ReadBlockAt<string_r>(NamePointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		BoundPointer = (ulong)((Bound != null) ? Bound.Position : 0);
		Unknown_F8h_Pointer = (ulong)((Unknown_F8h_Data != null) ? Unknown_F8h_Data.Position : 0);
		Unknown_108h_Pointer = (ulong)((Unknown_108h_Data != null) ? Unknown_108h_Data.Position : 0);
		NamePointer = (ulong)((Name != null) ? Name.Position : 0);
		writer.Write(Unknown_A8h);
		writer.Write(Unknown_ACh);
		writer.WriteBlock(Unknown_B0h);
		writer.Write(BoundPointer);
		writer.Write(Unknown_F8h_Pointer);
		writer.Write(Count1);
		writer.Write(Count2);
		writer.Write(Unknown_104h);
		writer.Write(Unknown_108h_Pointer);
		writer.Write(Count3);
		writer.Write(Count4);
		writer.Write(Unknown_114h);
		writer.Write(Unknown_118h);
		writer.Write(Unknown_11Ch);
		writer.Write(Unknown_120h);
		writer.Write(Unknown_124h);
		writer.Write(Unknown_128h);
		writer.Write(Unknown_12Ch);
		writer.Write(NamePointer);
		writer.Write(Unknown_138h);
		writer.Write(Unknown_13Ch);
		writer.Write(Unknown_140h);
		writer.Write(Unknown_144h);
		writer.Write(Unknown_148h);
		writer.Write(Unknown_14Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (Bound != null)
		{
			list.Add(Bound);
		}
		if (Unknown_F8h_Data != null)
		{
			list.Add(Unknown_F8h_Data);
		}
		if (Unknown_108h_Data != null)
		{
			list.Add(Unknown_108h_Data);
		}
		if (Name != null)
		{
			list.Add(Name);
		}
		return list.ToArray();
	}
}
