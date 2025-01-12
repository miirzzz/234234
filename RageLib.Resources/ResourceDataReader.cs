using System;
using System.Collections.Generic;
using System.IO;
using RageLib.Data;

namespace RageLib.Resources;

public class ResourceDataReader : DataReader
{
	private const long SYSTEM_BASE = 1342177280L;

	private const long GRAPHICS_BASE = 1610612736L;

	private Stream systemStream;

	private Stream graphicsStream;

	private Dictionary<long, List<IResourceBlock>> blockPool;

	public override long Length => -1L;

	public override long Position { get; set; }

	public ResourceDataReader(Stream systemStream, Stream graphicsStream, Endianess endianess = Endianess.LittleEndian)
		: base(null, endianess)
	{
		this.systemStream = systemStream;
		this.graphicsStream = graphicsStream;
		blockPool = new Dictionary<long, List<IResourceBlock>>();
	}

	protected override byte[] ReadFromStream(int count, bool ignoreEndianess = false)
	{
		if ((Position & 0x50000000) == 1342177280)
		{
			systemStream.Position = Position & -1342177281;
			byte[] array = new byte[count];
			systemStream.Read(array, 0, count);
			if (!ignoreEndianess && base.Endianess == Endianess.BigEndian)
			{
				Array.Reverse(array);
			}
			Position = systemStream.Position | 0x50000000;
			return array;
		}
		if ((Position & 0x60000000) == 1610612736)
		{
			graphicsStream.Position = Position & -1610612737;
			byte[] array2 = new byte[count];
			graphicsStream.Read(array2, 0, count);
			if (!ignoreEndianess && base.Endianess == Endianess.BigEndian)
			{
				Array.Reverse(array2);
			}
			Position = graphicsStream.Position | 0x60000000;
			return array2;
		}
		throw new Exception("illegal position!");
	}

	public T ReadBlock<T>(params object[] parameters) where T : IResourceBlock, new()
	{
		if (blockPool.ContainsKey(Position))
		{
			foreach (IResourceBlock item in blockPool[Position])
			{
				if (item is T)
				{
					Position += item.Length;
					return (T)item;
				}
			}
		}
		T val = new T();
		if (val is IResourceXXSystemBlock)
		{
			val = (T)((IResourceXXSystemBlock)(object)val).GetType(this, parameters);
		}
		if (blockPool.ContainsKey(Position))
		{
			blockPool[Position].Add(val);
		}
		else
		{
			List<IResourceBlock> list = new List<IResourceBlock>();
			list.Add(val);
			blockPool.Add(Position, list);
		}
		long position = Position;
		val.Read(this, parameters);
		val.Position = position;
		return val;
	}

	public T ReadBlockAt<T>(ulong position, params object[] parameters) where T : IResourceBlock, new()
	{
		if (position != 0L)
		{
			long position2 = Position;
			Position = (long)position;
			T result = ReadBlock<T>(parameters);
			Position = position2;
			return result;
		}
		return default(T);
	}
}
