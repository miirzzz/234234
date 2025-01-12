namespace RageLib.Resources.Common;

public class ushort_r : ResourceSystemBlock
{
	public override long Length => 2L;

	public ushort Value { get; set; }

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Value = reader.ReadUInt16();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Value);
	}

	public static explicit operator ushort(ushort_r value)
	{
		return value.Value;
	}

	public static explicit operator ushort_r(ushort value)
	{
		return new ushort_r
		{
			Value = value
		};
	}
}
