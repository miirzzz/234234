using RageLib.Data;
using RageLib.GTA5.PSO;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoFlagsByte : IPsoValue
{
	public PsoEnumInfo TypeInfo;

	public byte Value { get; set; }

	public PsoFlagsByte()
	{
	}

	public PsoFlagsByte(byte value)
	{
		Value = value;
	}

	public PsoFlagsByte(PsoEnumInfo typeInfo, byte value)
	{
		TypeInfo = typeInfo;
		Value = value;
	}

	public void Read(PsoDataReader reader)
	{
		Value = reader.ReadByte();
	}

	public void Write(DataWriter writer)
	{
		writer.Write(Value);
	}
}
