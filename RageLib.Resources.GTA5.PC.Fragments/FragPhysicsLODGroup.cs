using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Fragments;

public class FragPhysicsLODGroup : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public ulong PhysicsLOD1Pointer;

	public ulong PhysicsLOD2Pointer;

	public ulong PhysicsLOD3Pointer;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public FragPhysicsLOD PhysicsLOD1;

	public FragPhysicsLOD PhysicsLOD2;

	public FragPhysicsLOD PhysicsLOD3;

	public override long Length => 48L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		PhysicsLOD1Pointer = reader.ReadUInt64();
		PhysicsLOD2Pointer = reader.ReadUInt64();
		PhysicsLOD3Pointer = reader.ReadUInt64();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		PhysicsLOD1 = reader.ReadBlockAt<FragPhysicsLOD>(PhysicsLOD1Pointer, Array.Empty<object>());
		PhysicsLOD2 = reader.ReadBlockAt<FragPhysicsLOD>(PhysicsLOD2Pointer, Array.Empty<object>());
		PhysicsLOD3 = reader.ReadBlockAt<FragPhysicsLOD>(PhysicsLOD3Pointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		PhysicsLOD1Pointer = (ulong)((PhysicsLOD1 != null) ? PhysicsLOD1.Position : 0);
		PhysicsLOD2Pointer = (ulong)((PhysicsLOD2 != null) ? PhysicsLOD2.Position : 0);
		PhysicsLOD3Pointer = (ulong)((PhysicsLOD3 != null) ? PhysicsLOD3.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(PhysicsLOD1Pointer);
		writer.Write(PhysicsLOD2Pointer);
		writer.Write(PhysicsLOD3Pointer);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (PhysicsLOD1 != null)
		{
			list.Add(PhysicsLOD1);
		}
		if (PhysicsLOD2 != null)
		{
			list.Add(PhysicsLOD2);
		}
		if (PhysicsLOD3 != null)
		{
			list.Add(PhysicsLOD3);
		}
		return list.ToArray();
	}
}
