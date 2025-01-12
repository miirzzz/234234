using System.IO;
using RageLib.Data;

namespace RageLib.GTA5.PSO;

public class PsoFile
{
	public PsoDataSection DataSection { get; set; }

	public PsoDataMappingSection DataMappingSection { get; set; }

	public PsoDefinitionSection DefinitionSection { get; set; }

	public void Load(string fileName)
	{
		using FileStream stream = new FileStream(fileName, FileMode.Open);
		Load(stream);
	}

	public virtual void Load(Stream stream)
	{
		stream.Position = 0L;
		DataReader dataReader = new DataReader(stream, Endianess.BigEndian);
		while (dataReader.Position < dataReader.Length)
		{
			PsoSection psoSection = (PsoSection)dataReader.ReadUInt32();
			int count = dataReader.ReadInt32();
			dataReader.Position -= 8L;
			DataReader reader = new DataReader(new MemoryStream(dataReader.ReadBytes(count)), Endianess.BigEndian);
			switch (psoSection)
			{
			case PsoSection.Data:
				DataSection = new PsoDataSection();
				DataSection.Read(reader);
				break;
			case PsoSection.DataMapping:
				DataMappingSection = new PsoDataMappingSection();
				DataMappingSection.Read(reader);
				break;
			case PsoSection.Definition:
				DefinitionSection = new PsoDefinitionSection();
				DefinitionSection.Read(reader);
				break;
			}
		}
	}

	public void Save(string fileName)
	{
		using FileStream stream = new FileStream(fileName, FileMode.Create);
		Save(stream);
	}

	public virtual void Save(Stream stream)
	{
		DataWriter writer = new DataWriter(stream, Endianess.BigEndian);
		if (DataSection != null)
		{
			DataSection.Write(writer);
		}
		if (DataMappingSection != null)
		{
			DataMappingSection.Write(writer);
		}
		if (DefinitionSection != null)
		{
			DefinitionSection.Write(writer);
		}
	}

	public static bool IsPSO(string fileName)
	{
		using FileStream stream = new FileStream(fileName, FileMode.Open);
		return !IsRBF(stream);
	}

	public static bool IsPSO(Stream stream)
	{
		return !IsRBF(stream);
	}

	public static bool IsRBF(Stream stream)
	{
		uint num = new DataReader(stream, Endianess.BigEndian).ReadUInt32();
		stream.Position = 0L;
		return (num & 0xFFFFFF00u) == 1380075008;
	}
}
