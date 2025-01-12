namespace RageLib.Resources.Common;

public class byte_r : ResourceSystemBlock
{
	public override long Length => 1L;

	public byte Value { get; set; }

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Value = reader.ReadByte();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Value);
	}

	public static explicit operator byte(byte_r value)
	{
		return value.Value;
	}

	public static explicit operator byte_r(byte value)
	{
		return new byte_r
		{
			Value = value
		};
	}
}
