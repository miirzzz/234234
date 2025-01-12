namespace RageLib.Resources.Common;

public class ulong_r : ResourceSystemBlock
{
	public override long Length => 8L;

	public ulong Value { get; set; }

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Value = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Value);
	}

	public static explicit operator ulong(ulong_r value)
	{
		return value.Value;
	}

	public static explicit operator ulong_r(ulong value)
	{
		return new ulong_r
		{
			Value = value
		};
	}
}
