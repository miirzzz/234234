using System;
using System.Collections.Generic;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Bounds;

namespace RageLib.Resources.GTA5.PC.Drawables;

public class GtaDrawable : Drawable
{
	public ulong NamePointer;

	public ulong LightAttributesPointer;

	public ushort LightAttributesCount1;

	public ushort LightAttributesCount2;

	public uint Unknown_BCh;

	public uint Unknown_C0h;

	public uint Unknown_C4h;

	public ulong BoundPointer;

	public string_r Name;

	public ResourceSimpleArray<LightAttributes> LightAttributes;

	public Bound Bound;

	public override long Length => 208L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		NamePointer = reader.ReadUInt64();
		LightAttributesPointer = reader.ReadUInt64();
		LightAttributesCount1 = reader.ReadUInt16();
		LightAttributesCount2 = reader.ReadUInt16();
		Unknown_BCh = reader.ReadUInt32();
		Unknown_C0h = reader.ReadUInt32();
		Unknown_C4h = reader.ReadUInt32();
		BoundPointer = reader.ReadUInt64();
		Name = reader.ReadBlockAt<string_r>(NamePointer, Array.Empty<object>());
		LightAttributes = reader.ReadBlockAt<ResourceSimpleArray<LightAttributes>>(LightAttributesPointer, new object[1] { LightAttributesCount1 });
		Bound = reader.ReadBlockAt<Bound>(BoundPointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		NamePointer = (ulong)((Name != null) ? Name.Position : 0);
		LightAttributesPointer = (ulong)((LightAttributes != null) ? LightAttributes.Position : 0);
		BoundPointer = (ulong)((Bound != null) ? Bound.Position : 0);
		writer.Write(NamePointer);
		writer.Write(LightAttributesPointer);
		writer.Write(LightAttributesCount1);
		writer.Write(LightAttributesCount2);
		writer.Write(Unknown_BCh);
		writer.Write(Unknown_C0h);
		writer.Write(Unknown_C4h);
		writer.Write(BoundPointer);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (Name != null)
		{
			list.Add(Name);
		}
		if (LightAttributes != null)
		{
			list.Add(LightAttributes);
		}
		if (Bound != null)
		{
			list.Add(Bound);
		}
		return list.ToArray();
	}
}
