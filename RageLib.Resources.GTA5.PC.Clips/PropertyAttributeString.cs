using System;
using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Clips;

public class PropertyAttributeString : PropertyAttribute
{
	public ulong ValuePointer;

	public ushort ValueLength1;

	public ushort ValueLength2;

	public uint Unknown_2Ch;

	public string_r Value;

	public override long Length => 48L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		ValuePointer = reader.ReadUInt64();
		ValueLength1 = reader.ReadUInt16();
		ValueLength2 = reader.ReadUInt16();
		Unknown_2Ch = reader.ReadUInt32();
		Value = reader.ReadBlockAt<string_r>(ValuePointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		ValuePointer = (ulong)((Value != null) ? Value.Position : 0);
		ValueLength1 = (ushort)((Value != null) ? ((uint)Value.Value.Length) : 0u);
		ValueLength2 = (ushort)((Value != null) ? ((uint)(Value.Value.Length + 1)) : 0u);
		writer.Write(ValuePointer);
		writer.Write(ValueLength1);
		writer.Write(ValueLength2);
		writer.Write(Unknown_2Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (Value != null)
		{
			list.Add(Value);
		}
		return list.ToArray();
	}
}
