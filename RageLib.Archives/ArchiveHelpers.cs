using System;
using System.Collections.Generic;
using System.IO;

namespace RageLib.Archives;

public static class ArchiveHelpers
{
	private const int BUFFER_SIZE = 16384;

	public static long FindSpace(List<DataBlock> blocks, DataBlock item)
	{
		blocks.Sort(delegate(DataBlock a, DataBlock b)
		{
			_ = a.Offset;
			_ = b.Offset;
			return a.Offset.CompareTo(b.Offset);
		});
		DataBlock dataBlock = null;
		foreach (DataBlock block in blocks)
		{
			if (block != item && block.Offset >= item.Offset)
			{
				if (dataBlock == null)
				{
					dataBlock = block;
				}
				else if (block.Offset < dataBlock.Offset)
				{
					dataBlock = block;
				}
			}
		}
		if (dataBlock == null)
		{
			return long.MaxValue;
		}
		return dataBlock.Offset - item.Offset;
	}

	public static long FindOffset(List<DataBlock> blocks, long neededSpace, long blockSize = 1L)
	{
		List<DataBlock> list = new List<DataBlock>();
		list.AddRange(blocks);
		list.Sort(delegate(DataBlock a, DataBlock b)
		{
			_ = a.Offset;
			_ = b.Offset;
			return a.Offset.CompareTo(b.Offset);
		});
		if (list.Count == 0)
		{
			return 0L;
		}
		for (int i = 0; i < list.Count - 1; i++)
		{
			list[i].Length = Math.Min(list[i].Length, list[i + 1].Offset - list[i].Offset);
		}
		long num = 0L;
		for (int j = 0; j < list.Count; j++)
		{
			if (list[j].Offset - num >= neededSpace)
			{
				return num;
			}
			num = list[j].Offset + list[j].Length;
			num = (long)Math.Ceiling((double)num / (double)blockSize) * blockSize;
		}
		return num;
	}

	public static void MoveBytes(Stream stream, long sourceOffset, long destinationOffset, long length)
	{
		byte[] buffer = new byte[16384];
		while (length > 0)
		{
			stream.Position = sourceOffset;
			int num = stream.Read(buffer, 0, (int)Math.Min(length, 16384L));
			stream.Position = destinationOffset;
			stream.Write(buffer, 0, num);
			sourceOffset += num;
			destinationOffset += num;
			length -= num;
		}
	}
}
