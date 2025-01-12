namespace RageLib.Resources.Common;

public class uint_r : ResourceSystemBlock
{
	public override long Length => 4L;

	public uint Value { get; set; }

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Value = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Value);
	}

	public static explicit operator uint(uint_r value)
	{
		return value.Value;
	}

	public static explicit operator uint_r(uint value)
	{
		return new uint_r
		{
			Value = value
		};
	}
}
