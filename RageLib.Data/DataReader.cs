using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RageLib.Data;

public class DataReader
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

	public DataReader(Stream stream, Endianess endianess = Endianess.LittleEndian)
	{
		baseStream = stream;
		Endianess = endianess;
	}

	protected virtual byte[] ReadFromStream(int count, bool ignoreEndianess = false)
	{
		byte[] array = new byte[count];
		baseStream.Read(array, 0, count);
		if (!ignoreEndianess && Endianess == Endianess.BigEndian)
		{
			Array.Reverse(array);
		}
		return array;
	}

	public byte ReadByte()
	{
		return ReadFromStream(1)[0];
	}

	public byte[] ReadBytes(int count)
	{
		return ReadFromStream(count, ignoreEndianess: true);
	}

	public short ReadInt16()
	{
		return BitConverter.ToInt16(ReadFromStream(2), 0);
	}

	public int ReadInt32()
	{
		return BitConverter.ToInt32(ReadFromStream(4), 0);
	}

	public long ReadInt64()
	{
		return BitConverter.ToInt64(ReadFromStream(8), 0);
	}

	public ushort ReadUInt16()
	{
		return BitConverter.ToUInt16(ReadFromStream(2), 0);
	}

	public uint ReadUInt32()
	{
		return BitConverter.ToUInt32(ReadFromStream(4), 0);
	}

	public ulong ReadUInt64()
	{
		return BitConverter.ToUInt64(ReadFromStream(8), 0);
	}

	public float ReadSingle()
	{
		return BitConverter.ToSingle(ReadFromStream(4), 0);
	}

	public double ReadDouble()
	{
		return BitConverter.ToDouble(ReadFromStream(8), 0);
	}

	public string ReadString()
	{
		List<byte> list = new List<byte>();
		for (byte b = ReadFromStream(1)[0]; b != 0; b = ReadFromStream(1)[0])
		{
			list.Add(b);
		}
		return Encoding.UTF8.GetString(list.ToArray());
	}
}
