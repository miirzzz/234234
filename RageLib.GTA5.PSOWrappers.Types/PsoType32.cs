using RageLib.Data;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoType32 : IPsoValue
{
	public int Value { get; set; }

	public void Read(PsoDataReader reader)
	{
		reader.ReadInt32();
		reader.ReadInt32();
	}

	public void Write(DataWriter writer)
	{
	}
}
