using RageLib.Data;

namespace RageLib.GTA5.PSO;

public class PsoDataMappingEntry
{
	public int NameHash { get; set; }

	public int Offset { get; set; }

	public int Unknown_8h { get; set; }

	public int Length { get; set; }

	public void Read(DataReader reader)
	{
		NameHash = reader.ReadInt32();
		Offset = reader.ReadInt32();
		Unknown_8h = reader.ReadInt32();
		Length = reader.ReadInt32();
	}

	public void Write(DataWriter writer)
	{
		writer.Write(NameHash);
		writer.Write(Offset);
		writer.Write(Unknown_8h);
		writer.Write(Length);
	}
}
