using System;
using System.Collections.Generic;
using System.IO;
using RageLib.Data;

namespace RageLib.GTA5.PSO;

public class PsoDefinitionSection
{
	public uint Count;

	public List<PsoElementIndexInfo> EntriesIdx;

	public List<PsoElementInfo> Entries;

	public int Ident { get; private set; } = 1347633992;

	public void Read(DataReader reader)
	{
		Ident = reader.ReadInt32();
		reader.ReadInt32();
		Count = reader.ReadUInt32();
		EntriesIdx = new List<PsoElementIndexInfo>();
		for (int i = 0; i < Count; i++)
		{
			PsoElementIndexInfo psoElementIndexInfo = new PsoElementIndexInfo();
			psoElementIndexInfo.Read(reader);
			EntriesIdx.Add(psoElementIndexInfo);
		}
		Entries = new List<PsoElementInfo>();
		for (int j = 0; j < Count; j++)
		{
			reader.Position = EntriesIdx[j].Offset;
			byte b = reader.ReadByte();
			reader.Position = EntriesIdx[j].Offset;
			switch (b)
			{
			case 0:
			{
				PsoStructureInfo psoStructureInfo = new PsoStructureInfo();
				psoStructureInfo.Read(reader);
				Entries.Add(psoStructureInfo);
				break;
			}
			case 1:
			{
				PsoEnumInfo psoEnumInfo = new PsoEnumInfo();
				psoEnumInfo.Read(reader);
				Entries.Add(psoEnumInfo);
				break;
			}
			default:
				throw new Exception("unknown type!");
			}
		}
	}

	public void Write(DataWriter writer)
	{
		MemoryStream memoryStream = new MemoryStream();
		DataWriter dataWriter = new DataWriter(memoryStream, Endianess.BigEndian);
		for (int i = 0; i < Entries.Count; i++)
		{
			EntriesIdx[i].Offset = 12 + 8 * Entries.Count + (int)dataWriter.Position;
			Entries[i].Write(dataWriter);
		}
		MemoryStream memoryStream2 = new MemoryStream();
		DataWriter writer2 = new DataWriter(memoryStream2, Endianess.BigEndian);
		foreach (PsoElementIndexInfo item in EntriesIdx)
		{
			item.Write(writer2);
		}
		writer.Write(Ident);
		writer.Write((int)(12 + memoryStream.Length + memoryStream2.Length));
		writer.Write(Entries.Count);
		byte[] array = new byte[memoryStream2.Length];
		memoryStream2.Position = 0L;
		memoryStream2.Read(array, 0, array.Length);
		writer.Write(array);
		byte[] array2 = new byte[memoryStream.Length];
		memoryStream.Position = 0L;
		memoryStream.Read(array2, 0, array2.Length);
		writer.Write(array2);
	}
}
