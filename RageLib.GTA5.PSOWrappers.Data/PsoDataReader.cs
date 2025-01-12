using System;
using System.IO;
using RageLib.Data;
using RageLib.GTA5.PSO;

namespace RageLib.GTA5.PSOWrappers.Data;

public class PsoDataReader : DataReader
{
	private readonly PsoFile psoFile;

	public override long Length => psoFile.DataMappingSection.Entries[CurrentSectionIndex].Length;

	public int CurrentSectionIndex { get; private set; }

	public int CurrentSectionHash { get; private set; }

	public override long Position { get; set; }

	public PsoDataReader(PsoFile psoFile)
		: base(null, Endianess.BigEndian)
	{
		this.psoFile = psoFile;
	}

	protected override byte[] ReadFromStream(int count, bool ignoreEndianess = false)
	{
		MemoryStream obj = new MemoryStream(psoFile.DataSection.Data)
		{
			Position = psoFile.DataMappingSection.Entries[CurrentSectionIndex].Offset
		};
		obj.Position += Position;
		byte[] array = new byte[count];
		obj.Read(array, 0, count);
		Position += count;
		if (!ignoreEndianess && base.Endianess == Endianess.BigEndian)
		{
			Array.Reverse(array);
		}
		return array;
	}

	public void SetSectionIndex(int index)
	{
		CurrentSectionIndex = index;
		CurrentSectionHash = psoFile.DataMappingSection.Entries[index].NameHash;
	}
}
