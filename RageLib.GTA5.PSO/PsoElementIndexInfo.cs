using RageLib.Data;

namespace RageLib.GTA5.PSO;

public class PsoElementIndexInfo
{
	public int NameHash;

	public int Offset;

	public void Read(DataReader reader)
	{
		NameHash = reader.ReadInt32();
		Offset = reader.ReadInt32();
	}

	public void Write(DataWriter writer)
	{
		writer.Write(NameHash);
		writer.Write(Offset);
	}
}
