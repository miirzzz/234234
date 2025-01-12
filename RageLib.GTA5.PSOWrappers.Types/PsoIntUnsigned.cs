using RageLib.Data;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoIntUnsigned : IPsoValue
{
	public uint Value { get; set; }

	public void Read(PsoDataReader reader)
	{
		Value = reader.ReadUInt32();
	}

	public void Write(DataWriter writer)
	{
		writer.Write(Value);
	}
}
