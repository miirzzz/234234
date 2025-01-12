using RageLib.Data;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoType9 : IPsoValue
{
	public int Value { get; set; }

	public void Read(PsoDataReader reader)
	{
		reader.ReadSingle();
		reader.ReadSingle();
		reader.ReadSingle();
		reader.ReadSingle();
	}

	public void Write(DataWriter writer)
	{
	}
}
