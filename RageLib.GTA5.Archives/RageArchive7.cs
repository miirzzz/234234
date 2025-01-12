using System;
using System.Collections.Generic;
using System.IO;
using RageLib.Cryptography;
using RageLib.Data;
using RageLib.GTA5.Cryptography;

namespace RageLib.GTA5.Archives;

public class RageArchive7 : IDisposable
{
	private const uint IDENT = 1380992567u;

	private bool LeaveOpen;

	public RageArchiveEncryption7 Encryption { get; set; }

	public Stream BaseStream { get; private set; }

	public RageArchiveDirectory7 Root { get; set; }

	public RageArchive7(Stream fileStream, bool leaveOpen = false)
	{
		BaseStream = fileStream;
		LeaveOpen = leaveOpen;
	}

	public void ReadHeader(byte[] aesKey = null, byte[] ngKey = null)
	{
		DataReader dataReader = new DataReader(BaseStream);
		long position = dataReader.Position;
		dataReader.Position = 0L;
		uint num = dataReader.ReadUInt32();
		if (num != 1380992567)
		{
			throw new Exception("The identifier " + num.ToString("X8") + " did not match the expected value of 0x52504637");
		}
		uint num2 = dataReader.ReadUInt32();
		uint count = dataReader.ReadUInt32();
		uint num3 = dataReader.ReadUInt32();
		byte[] array = null;
		byte[] array2 = null;
		switch (num3)
		{
		case 1313165391u:
			Encryption = RageArchiveEncryption7.None;
			array = dataReader.ReadBytes((int)(16 * num2));
			array2 = dataReader.ReadBytes((int)count);
			break;
		case 268435449u:
			Encryption = RageArchiveEncryption7.AES;
			array = AesEncryption.DecryptData(dataReader.ReadBytes((int)(16 * num2)), aesKey);
			array2 = AesEncryption.DecryptData(dataReader.ReadBytes((int)count), aesKey);
			break;
		default:
			Encryption = RageArchiveEncryption7.NG;
			array = GTA5Crypto.Decrypt(dataReader.ReadBytes((int)(16 * num2)), ngKey);
			array2 = GTA5Crypto.Decrypt(dataReader.ReadBytes((int)count), ngKey);
			break;
		}
		DataReader dataReader2 = new DataReader(new MemoryStream(array));
		DataReader dataReader3 = new DataReader(new MemoryStream(array2));
		List<IRageArchiveEntry7> list = new List<IRageArchiveEntry7>();
		for (int i = 0; i < num2; i++)
		{
			dataReader2.Position += 4L;
			int num4 = dataReader2.ReadInt32();
			dataReader2.Position -= 8L;
			if (num4 == 2147483392)
			{
				RageArchiveDirectory7 rageArchiveDirectory = new RageArchiveDirectory7();
				rageArchiveDirectory.Read(dataReader2);
				dataReader3.Position = rageArchiveDirectory.NameOffset;
				rageArchiveDirectory.Name = dataReader3.ReadString();
				list.Add(rageArchiveDirectory);
				continue;
			}
			if ((num4 & 0x80000000u) == 0L)
			{
				RageArchiveBinaryFile7 rageArchiveBinaryFile = new RageArchiveBinaryFile7();
				rageArchiveBinaryFile.Read(dataReader2);
				dataReader3.Position = rageArchiveBinaryFile.NameOffset;
				rageArchiveBinaryFile.Name = dataReader3.ReadString();
				list.Add(rageArchiveBinaryFile);
				continue;
			}
			RageArchiveResourceFile7 rageArchiveResourceFile = new RageArchiveResourceFile7();
			rageArchiveResourceFile.Read(dataReader2);
			if (rageArchiveResourceFile.FileSize == 16777215)
			{
				dataReader.Position = 512 * rageArchiveResourceFile.FileOffset;
				byte[] array3 = dataReader.ReadBytes(16);
				rageArchiveResourceFile.FileSize = (uint)(array3[7] | (array3[14] << 8) | (array3[5] << 16) | (array3[2] << 24));
			}
			dataReader3.Position = rageArchiveResourceFile.NameOffset;
			rageArchiveResourceFile.Name = dataReader3.ReadString();
			list.Add(rageArchiveResourceFile);
		}
		Stack<RageArchiveDirectory7> stack = new Stack<RageArchiveDirectory7>();
		stack.Push((RageArchiveDirectory7)list[0]);
		Root = (RageArchiveDirectory7)list[0];
		while (stack.Count > 0)
		{
			RageArchiveDirectory7 rageArchiveDirectory2 = stack.Pop();
			for (int j = (int)rageArchiveDirectory2.EntriesIndex; j < rageArchiveDirectory2.EntriesIndex + rageArchiveDirectory2.EntriesCount; j++)
			{
				if (list[j] is RageArchiveDirectory7)
				{
					rageArchiveDirectory2.Directories.Add(list[j] as RageArchiveDirectory7);
					stack.Push(list[j] as RageArchiveDirectory7);
				}
				else
				{
					rageArchiveDirectory2.Files.Add(list[j]);
				}
			}
		}
		dataReader.Position = position;
	}

	public void WriteHeader(byte[] aesKey = null, byte[] ngKey = null)
	{
		long position = BaseStream.Position;
		DataWriter dataWriter = new DataWriter(BaseStream);
		List<IRageArchiveEntry7> list = new List<IRageArchiveEntry7>();
		Stack<RageArchiveDirectory7> stack = new Stack<RageArchiveDirectory7>();
		int num = 1;
		list.Add(Root);
		stack.Push(Root);
		Dictionary<string, uint> dictionary = new Dictionary<string, uint>();
		dictionary.Add("", 0u);
		while (stack.Count > 0)
		{
			RageArchiveDirectory7 rageArchiveDirectory = stack.Pop();
			rageArchiveDirectory.EntriesIndex = (uint)list.Count;
			rageArchiveDirectory.EntriesCount = (uint)(rageArchiveDirectory.Directories.Count + rageArchiveDirectory.Files.Count);
			List<IRageArchiveEntry7> list2 = new List<IRageArchiveEntry7>();
			foreach (RageArchiveDirectory7 directory in rageArchiveDirectory.Directories)
			{
				if (!dictionary.ContainsKey(directory.Name))
				{
					dictionary.Add(directory.Name, (uint)num);
					num += directory.Name.Length + 1;
				}
				directory.NameOffset = dictionary[directory.Name];
				list2.Add(directory);
			}
			foreach (IRageArchiveEntry7 file in rageArchiveDirectory.Files)
			{
				if (!dictionary.ContainsKey(file.Name))
				{
					dictionary.Add(file.Name, (uint)num);
					num += file.Name.Length + 1;
				}
				file.NameOffset = dictionary[file.Name];
				list2.Add(file);
			}
			list2.Sort((IRageArchiveEntry7 a, IRageArchiveEntry7 b) => string.CompareOrdinal(a.Name, b.Name));
			foreach (IRageArchiveEntry7 item in list2)
			{
				list.Add(item);
			}
			list2.Reverse();
			foreach (IRageArchiveEntry7 item2 in list2)
			{
				if (item2 is RageArchiveDirectory7)
				{
					stack.Push((RageArchiveDirectory7)item2);
				}
			}
		}
		foreach (IRageArchiveEntry7 item3 in list)
		{
			if (!(item3 is RageArchiveResourceFile7))
			{
				continue;
			}
			RageArchiveResourceFile7 rageArchiveResourceFile = item3 as RageArchiveResourceFile7;
			if (rageArchiveResourceFile.FileSize > 16777215)
			{
				byte[] array = new byte[16];
				array[7] = (byte)(rageArchiveResourceFile.FileSize & 0xFF);
				array[14] = (byte)((rageArchiveResourceFile.FileSize >> 8) & 0xFF);
				array[5] = (byte)((rageArchiveResourceFile.FileSize >> 16) & 0xFF);
				array[2] = (byte)((rageArchiveResourceFile.FileSize >> 24) & 0xFF);
				if (dataWriter.Length > 512 * rageArchiveResourceFile.FileOffset)
				{
					dataWriter.Position = 512 * rageArchiveResourceFile.FileOffset;
					dataWriter.Write(array);
				}
				rageArchiveResourceFile.FileSize = 16777215u;
			}
		}
		MemoryStream memoryStream = new MemoryStream();
		DataWriter writer = new DataWriter(memoryStream);
		foreach (IRageArchiveEntry7 item4 in list)
		{
			item4.Write(writer);
		}
		memoryStream.Flush();
		byte[] array2 = new byte[memoryStream.Length];
		memoryStream.Position = 0L;
		memoryStream.Read(array2, 0, array2.Length);
		if (Encryption == RageArchiveEncryption7.AES)
		{
			array2 = AesEncryption.EncryptData(array2, aesKey);
		}
		if (Encryption == RageArchiveEncryption7.NG)
		{
			Encryption = RageArchiveEncryption7.None;
		}
		MemoryStream memoryStream2 = new MemoryStream();
		DataWriter dataWriter2 = new DataWriter(memoryStream2);
		foreach (KeyValuePair<string, uint> item5 in dictionary)
		{
			dataWriter2.Write(item5.Key);
		}
		byte[] value = new byte[16 - dataWriter2.Length % 16];
		dataWriter2.Write(value);
		memoryStream2.Flush();
		byte[] array3 = new byte[memoryStream2.Length];
		memoryStream2.Position = 0L;
		memoryStream2.Read(array3, 0, array3.Length);
		if (Encryption == RageArchiveEncryption7.AES)
		{
			array3 = AesEncryption.EncryptData(array3, aesKey);
		}
		dataWriter.Position = 0L;
		dataWriter.Write(1380992567u);
		dataWriter.Write((uint)list.Count);
		dataWriter.Write((uint)array3.Length);
		switch (Encryption)
		{
		case RageArchiveEncryption7.None:
			dataWriter.Write(1313165391u);
			break;
		case RageArchiveEncryption7.AES:
			dataWriter.Write(268435449u);
			break;
		case RageArchiveEncryption7.NG:
			dataWriter.Write(267386879u);
			break;
		}
		dataWriter.Write(array2);
		dataWriter.Write(array3);
		BaseStream.Position = position;
	}

	public void Dispose()
	{
		if (BaseStream != null)
		{
			BaseStream.Dispose();
		}
		BaseStream = null;
		Root = null;
	}
}
