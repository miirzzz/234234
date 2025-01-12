using RageLib.Data;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoIntSigned : IPsoValue
{
	public int Value { get; set; }

	public void Read(PsoDataReader reader)
	{
		Value = reader.ReadInt32();
	}

	public void Write(DataWriter writer)
	{
		writer.Write(Value);
	}
}