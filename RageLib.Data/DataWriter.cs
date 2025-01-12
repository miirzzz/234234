using System;
using System.IO;

namespace RageLib.Data;

public class DataWriter
{
	private Stream baseStream;

	public Endianess Endianess { get; set; }

	public virtual long Length => baseStream.Length;

	public virtual long Position
	{
		get
		{
			return baseStream.Position;
		}
		set
		{
			baseStream.Position = value;
		}
	}

	public DataWriter(Stream stream, Endianess endianess = Endianess.LittleEndian)
	{
		baseStream = stream;
		Endianess = endianess;
	}

	protected virtual void WriteToStream(byte[] value, bool ignoreEndianess = true)
	{
		if (!ignoreEndianess && Endianess == Endianess.BigEndian)
		{
			byte[] array = (byte[])value.Clone();
			Array.Reverse(array);
			baseStream.Write(array, 0, array.Length);
		}
		else
		{
			baseStream.Write(value, 0, value.Length);
		}
	}

	public void Write(byte value)
	{
		WriteToStream(new byte[1] { value });
	}

	public void Write(byte[] value)
	{
		WriteToStream(value);
	}

	public void Write(short value)
	{
		WriteToStream(BitConverter.GetBytes(value));
	}

	public void Write(int value)
	{
		WriteToStream(BitConverter.GetBytes(value));
	}

	public void Write(long value)
	{
		WriteToStream(BitConverter.GetBytes(value));
	}

	public void Write(ushort value)
	{
		WriteToStream(BitConverter.GetBytes(value));
	}

	public void Write(uint value)
	{
		WriteToStream(BitConverter.GetBytes(value));
	}

	public void Write(ulong value)
	{
		WriteToStream(BitConverter.GetBytes(value));
	}

	public void Write(float value)
	{
		WriteToStream(BitConverter.GetBytes(value));
	}

	public void Write(double value)
	{
		WriteToStream(BitConverter.GetBytes(value));
	}

	public void Write(string value)
	{
		foreach (char c in value)
		{
			Write((byte)c);
		}
		Write((byte)0);
	}
}
