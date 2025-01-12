using RageLib.Data;
using RageLib.GTA5.PSO;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoEnumByte : IPsoValue
{
	public PsoEnumInfo TypeInfo { get; set; }

	public byte Value { get; set; }

	public PsoEnumByte()
	{
	}

	public PsoEnumByte(byte value)
	{
		Value = value;
	}

	public PsoEnumByte(PsoEnumInfo typeInfo, byte value)
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
