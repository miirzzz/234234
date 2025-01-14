using RageLib.Data;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoByte : IPsoValue
{
	public byte Value { get; set; }

	public void Read(PsoDataReader reader)
	{
		Value = reader.ReadByte();
	}

	public void Write(DataWriter writer)
	{
	}
}
