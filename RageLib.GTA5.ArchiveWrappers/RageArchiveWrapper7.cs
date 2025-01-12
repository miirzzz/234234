using System;
using System.Collections.Generic;
using System.IO;
using RageLib.Archives;
using RageLib.Data;
using RageLib.GTA5.Archives;
using RageLib.GTA5.Cryptography;

namespace RageLib.GTA5.ArchiveWrappers;

public class RageArchiveWrapper7 : IArchive, IDisposable
{
	public static int BLOCK_SIZE = 512;

	public RageArchive7 archive_;

	public string FileName { get; set; }

	public IArchiveDirectory Root => new RageArchiveDirectoryWrapper7(this, archive_.Root);

	private RageArchiveWrapper7(Stream stream, string fileName, bool leaveOpen = false)
	{
		archive_ = new RageArchive7(stream, leaveOpen);
		FileName = fileName;
	}

	public void Flush()
	{
		long headerSize = GetHeaderSize();
		while (true)
		{
			List<DataBlock> blocks = GetBlocks();
			if (ArchiveHelpers.FindSpace(blocks, blocks[0]) >= headerSize)
			{
				break;
			}
			long num = ArchiveHelpers.FindOffset(blocks, blocks[1].Length, 512L);
			ArchiveHelpers.MoveBytes(archive_.BaseStream, blocks[1].Offset, num, blocks[1].Length);
			((IRageArchiveFileEntry7)blocks[1].Tag).FileOffset = (uint)(num / 512);
			blocks = GetBlocks();
			ArchiveHelpers.FindSpace(blocks, blocks[0]);
		}
		uint num2 = (uint)((int)GTA5Hash.CalculateHash(FileName) + (int)archive_.BaseStream.Length + 61) % 101u;
		archive_.WriteHeader(GTA5Constants.PC_AES_KEY, GTA5Constants.PC_NG_KEYS[num2]);
		archive_.BaseStream.Flush();
	}

	public void Dispose()
	{
		if (archive_ != null)
		{
			archive_.Dispose();
		}
		archive_ = null;
	}

	internal Stream GetStream(RageArchiveBinaryFile7 file_)
	{
		return new PartialStream(archive_.BaseStream, () => 512 * file_.FileOffset, () => (file_.FileSize != 0) ? file_.FileSize : file_.FileUncompressedSize, delegate(long newLength)
		{
			RequestBytes(file_, newLength);
		});
	}

	private long GetHeaderSize()
	{
		long num = 16L;
		Stack<RageArchiveDirectory7> stack = new Stack<RageArchiveDirectory7>();
		stack.Push(archive_.Root);
		while (stack.Count > 0)
		{
			RageArchiveDirectory7 rageArchiveDirectory = stack.Pop();
			num += 16;
			num += rageArchiveDirectory.Name.Length + 1;
			foreach (RageArchiveDirectory7 directory in rageArchiveDirectory.Directories)
			{
				stack.Push(directory);
			}
			foreach (IRageArchiveEntry7 file in rageArchiveDirectory.Files)
			{
				num += 16 + file.Name.Length + 1;
			}
		}
		return num;
	}

	internal long FindSpace(long length)
	{
		GetHeaderSize();
		return ArchiveHelpers.FindOffset(GetBlocks(), length, 512L);
	}

	private List<DataBlock> GetBlocks()
	{
		List<DataBlock> list = new List<DataBlock>();
		list.Add(new DataBlock(0L, GetHeaderSize()));
		Stack<RageArchiveDirectory7> stack = new Stack<RageArchiveDirectory7>();
		stack.Push(archive_.Root);
		while (stack.Count > 0)
		{
			RageArchiveDirectory7 rageArchiveDirectory = stack.Pop();
			foreach (RageArchiveDirectory7 directory in rageArchiveDirectory.Directories)
			{
				stack.Push(directory);
			}
			foreach (IRageArchiveFileEntry7 file in rageArchiveDirectory.Files)
			{
				if (file is RageArchiveBinaryFile7)
				{
					RageArchiveBinaryFile7 rageArchiveBinaryFile = (RageArchiveBinaryFile7)file;
					long num = 0L;
					list.Add(new DataBlock(length: (file.FileSize != 0) ? rageArchiveBinaryFile.FileSize : rageArchiveBinaryFile.FileUncompressedSize, offset: file.FileOffset * 512, tag: file));
				}
				else
				{
					long length2 = ((RageArchiveResourceFile7)file).FileSize;
					list.Add(new DataBlock(file.FileOffset * 512, length2, file));
				}
			}
		}
		list.Sort(delegate(DataBlock a, DataBlock b)
		{
			_ = a.Offset;
			_ = b.Offset;
			return a.Offset.CompareTo(b.Offset);
		});
		return list;
	}

	public void RequestBytes(RageArchiveBinaryFile7 file_, long newLength)
	{
		GetHeaderSize();
		DataBlock dataBlock = null;
		List<DataBlock> blocks = GetBlocks();
		foreach (DataBlock item in blocks)
		{
			if (item.Tag == file_)
			{
				dataBlock = item;
			}
		}
		if (ArchiveHelpers.FindSpace(blocks, dataBlock) < newLength)
		{
			long num = ArchiveHelpers.FindOffset(blocks, newLength, 512L);
			ArchiveHelpers.MoveBytes(archive_.BaseStream, dataBlock.Offset, num, dataBlock.Length);
			((IRageArchiveFileEntry7)dataBlock.Tag).FileOffset = (uint)num / 512;
		}
		if (file_.FileSize != 0)
		{
			file_.FileSize = (uint)newLength;
		}
		else
		{
			file_.FileUncompressedSize = (uint)newLength;
		}
	}

	public void RequestBytesRES(RageArchiveResourceFile7 file_, long newLength)
	{
		GetHeaderSize();
		DataBlock dataBlock = null;
		List<DataBlock> blocks = GetBlocks();
		foreach (DataBlock item in blocks)
		{
			if (item.Tag == file_)
			{
				dataBlock = item;
			}
		}
		if (ArchiveHelpers.FindSpace(blocks, dataBlock) < newLength)
		{
			long num = ArchiveHelpers.FindOffset(blocks, newLength, 512L);
			ArchiveHelpers.MoveBytes(archive_.BaseStream, dataBlock.Offset, num, dataBlock.Length);
			((IRageArchiveFileEntry7)dataBlock.Tag).FileOffset = (uint)num / 512;
		}
		file_.FileSize = (uint)newLength;
	}

	public static RageArchiveWrapper7 Create(string fileName)
	{
		FileInfo fileInfo = new FileInfo(fileName);
		RageArchiveWrapper7 rageArchiveWrapper = new RageArchiveWrapper7(new FileStream(fileName, FileMode.Create), fileInfo.Name);
		RageArchiveDirectory7 root = new RageArchiveDirectory7
		{
			Name = ""
		};
		rageArchiveWrapper.archive_.Root = root;
		return rageArchiveWrapper;
	}

	public static RageArchiveWrapper7 Create(Stream stream, string fileName, bool leaveOpen = false)
	{
		RageArchiveWrapper7 rageArchiveWrapper = new RageArchiveWrapper7(stream, fileName, leaveOpen);
		RageArchiveDirectory7 root = new RageArchiveDirectory7
		{
			Name = ""
		};
		rageArchiveWrapper.archive_.Root = root;
		return rageArchiveWrapper;
	}

	public static RageArchiveWrapper7 Open(string fileName)
	{
		FileInfo fileInfo = new FileInfo(fileName);
		FileStream fileStream = new FileStream(fileName, FileMode.Open);
		RageArchiveWrapper7 rageArchiveWrapper = new RageArchiveWrapper7(fileStream, fileInfo.Name);
		try
		{
			if (GTA5Constants.PC_LUT != null && GTA5Constants.PC_NG_KEYS != null)
			{
				uint num = (uint)((int)GTA5Hash.CalculateHash(rageArchiveWrapper.FileName) + (int)fileInfo.Length + 61) % 101u;
				rageArchiveWrapper.archive_.ReadHeader(GTA5Constants.PC_AES_KEY, GTA5Constants.PC_NG_KEYS[num]);
			}
			else
			{
				rageArchiveWrapper.archive_.ReadHeader(GTA5Constants.PC_AES_KEY);
			}
			return rageArchiveWrapper;
		}
		catch
		{
			fileStream.Dispose();
			rageArchiveWrapper.Dispose();
			throw;
		}
	}

	public static RageArchiveWrapper7 Open(Stream stream, string fileName, bool leaveOpen = false)
	{
		RageArchiveWrapper7 rageArchiveWrapper = new RageArchiveWrapper7(stream, fileName, leaveOpen);
		try
		{
			if (GTA5Constants.PC_LUT != null && GTA5Constants.PC_NG_KEYS != null)
			{
				uint num = (uint)((int)GTA5Hash.CalculateHash(rageArchiveWrapper.FileName) + (int)stream.Length + 61) % 101u;
				rageArchiveWrapper.archive_.ReadHeader(GTA5Constants.PC_AES_KEY, GTA5Constants.PC_NG_KEYS[num]);
			}
			else
			{
				rageArchiveWrapper.archive_.ReadHeader(GTA5Constants.PC_AES_KEY);
			}
			return rageArchiveWrapper;
		}
		catch
		{
			rageArchiveWrapper.Dispose();
			throw;
		}
	}
}
