using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using HtmlAgilityPack;
using RageLib.Archives;
using RageLib.Cryptography;
using RageLib.GTA5.Archives;
using RageLib.GTA5.Cryptography;
using RageLib.GTA5.PSO;
using RageLib.GTA5.Resources.PC;
using RageLib.Hash;
using RageLib.Resources.GTA5;
using RageLib.Resources.GTA5.PC.Meta;

namespace RageLib.GTA5.Utilities;

public static class MetaUtilities
{
	public static HashSet<int> GetAllHashesFromMetas(string gameDirectoryName)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (int allHashesFromResourceMeta in GetAllHashesFromResourceMetas(gameDirectoryName))
		{
			hashSet.Add(allHashesFromResourceMeta);
		}
		foreach (int allHashesFromPsoMeta in GetAllHashesFromPsoMetas(gameDirectoryName))
		{
			hashSet.Add(allHashesFromPsoMeta);
		}
		return hashSet;
	}

	public static HashSet<int> GetAllHashesFromResourceMetas(string gameDirectoryName)
	{
		HashSet<int> hashes = new HashSet<int>();
		ArchiveUtilities.ForEachResourceFile(gameDirectoryName, delegate(string fullFileName, IArchiveResourceFile file, RageArchiveEncryption7 encryption)
		{
			if (file.Name.EndsWith(ResourceFileTypes_GTA5_pc.Meta.Extension, StringComparison.OrdinalIgnoreCase) || file.Name.EndsWith(ResourceFileTypes_GTA5_pc.Types.Extension, StringComparison.OrdinalIgnoreCase) || file.Name.EndsWith(ResourceFileTypes_GTA5_pc.Maps.Extension, StringComparison.OrdinalIgnoreCase))
			{
				MemoryStream memoryStream = new MemoryStream();
				file.Export(memoryStream);
				memoryStream.Position = 0L;
				ResourceFile_GTA5_pc<MetaFile> resourceFile_GTA5_pc = new ResourceFile_GTA5_pc<MetaFile>();
				resourceFile_GTA5_pc.Load(memoryStream);
				MetaFile resourceData = resourceFile_GTA5_pc.ResourceData;
				if (resourceData.StructureInfos != null)
				{
					foreach (StructureInfo structureInfo in resourceData.StructureInfos)
					{
						hashes.Add(structureInfo.StructureKey);
						hashes.Add(structureInfo.StructureNameHash);
						foreach (StructureEntryInfo entry in structureInfo.Entries)
						{
							if (entry.EntryNameHash != 256)
							{
								hashes.Add(entry.EntryNameHash);
							}
						}
					}
				}
				if (resourceData.EnumInfos != null)
				{
					foreach (EnumInfo enumInfo in resourceData.EnumInfos)
					{
						hashes.Add(enumInfo.EnumKey);
						hashes.Add(enumInfo.EnumNameHash);
						foreach (EnumEntryInfo entry2 in enumInfo.Entries)
						{
							hashes.Add(entry2.EntryNameHash);
						}
					}
				}
				Console.WriteLine(file.Name);
			}
		});
		return hashes;
	}

	public static HashSet<int> GetAllHashesFromPsoMetas(string gameDirectoryName)
	{
		HashSet<int> hashes = new HashSet<int>();
		ArchiveUtilities.ForEachBinaryFile(gameDirectoryName, delegate(string fullFileName, IArchiveBinaryFile file, RageArchiveEncryption7 encryption)
		{
			if (file.Name.EndsWith(".ymf") || file.Name.EndsWith(".ymt"))
			{
				MemoryStream memoryStream = new MemoryStream();
				file.Export(memoryStream);
				byte[] array = new byte[memoryStream.Length];
				memoryStream.Position = 0L;
				memoryStream.Read(array, 0, array.Length);
				if (file.IsEncrypted)
				{
					if (encryption == RageArchiveEncryption7.AES)
					{
						array = AesEncryption.DecryptData(array, GTA5Constants.PC_AES_KEY);
					}
					else
					{
						uint num = (uint)((int)GTA5Hash.CalculateHash(file.Name) + (int)file.UncompressedSize + 61) % 101u;
						array = GTA5Crypto.Decrypt(array, GTA5Constants.PC_NG_KEYS[num]);
					}
				}
				if (file.IsCompressed)
				{
					DeflateStream deflateStream = new DeflateStream(new MemoryStream(array), CompressionMode.Decompress);
					byte[] array2 = new byte[file.UncompressedSize];
					deflateStream.Read(array2, 0, (int)file.UncompressedSize);
					array = array2;
				}
				MemoryStream stream = new MemoryStream(array);
				if (PsoFile.IsPSO(stream))
				{
					PsoFile psoFile = new PsoFile();
					psoFile.Load(stream);
					foreach (PsoElementIndexInfo item in psoFile.DefinitionSection.EntriesIdx)
					{
						hashes.Add(item.NameHash);
					}
					foreach (PsoElementInfo entry in psoFile.DefinitionSection.Entries)
					{
						if (entry is PsoStructureInfo)
						{
							foreach (PsoStructureEntryInfo entry2 in ((PsoStructureInfo)entry).Entries)
							{
								hashes.Add(entry2.EntryNameHash);
							}
						}
						if (entry is PsoEnumInfo)
						{
							foreach (PsoEnumEntryInfo entry3 in ((PsoEnumInfo)entry).Entries)
							{
								hashes.Add(entry3.EntryNameHash);
							}
						}
					}
					Console.WriteLine(file.Name);
				}
			}
		});
		return hashes;
	}

	public static HashSet<string> GetAllStringsFromAllXmls(string gameDirectoryName)
	{
		HashSet<string> xmlStrings = new HashSet<string>();
		ArchiveUtilities.ForEachBinaryFile(gameDirectoryName, delegate(string fullFileName, IArchiveBinaryFile file, RageArchiveEncryption7 encryption)
		{
			if (file.Name.EndsWith(".meta", StringComparison.OrdinalIgnoreCase) || file.Name.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
			{
				MemoryStream memoryStream = new MemoryStream();
				file.Export(memoryStream);
				byte[] array = new byte[memoryStream.Length];
				memoryStream.Position = 0L;
				memoryStream.Read(array, 0, array.Length);
				if (file.IsEncrypted)
				{
					if (encryption == RageArchiveEncryption7.AES)
					{
						array = AesEncryption.DecryptData(array, GTA5Constants.PC_AES_KEY);
					}
					else
					{
						uint num = (uint)((int)GTA5Hash.CalculateHash(file.Name) + (int)file.UncompressedSize + 61) % 101u;
						array = GTA5Crypto.Decrypt(array, GTA5Constants.PC_NG_KEYS[num]);
					}
				}
				if (file.IsCompressed)
				{
					DeflateStream deflateStream = new DeflateStream(new MemoryStream(array), CompressionMode.Decompress);
					byte[] array2 = new byte[file.UncompressedSize];
					deflateStream.Read(array2, 0, (int)file.UncompressedSize);
					array = array2;
				}
				foreach (string item in GetAllStringsFromXml(new MemoryStream(array)))
				{
					xmlStrings.Add(item);
				}
				Console.WriteLine(file.Name);
			}
		});
		return xmlStrings;
	}

	public static HashSet<string> GetAllStringsFromXml(string xmlFileName)
	{
		using FileStream xmlFileStream = new FileStream(xmlFileName, FileMode.Open);
		return GetAllStringsFromXml(xmlFileStream);
	}

	public static HashSet<string> GetAllStringsFromXml(Stream xmlFileStream)
	{
		HashSet<string> hashSet = new HashSet<string>();
		HtmlDocument htmlDocument = new HtmlDocument();
		htmlDocument.OptionOutputOriginalCase = true;
		htmlDocument.OptionWriteEmptyNodes = true;
		htmlDocument.Load(xmlFileStream);
		Stack<HtmlNode> stack = new Stack<HtmlNode>();
		stack.Push(htmlDocument.DocumentNode);
		while (stack.Count > 0)
		{
			HtmlNode htmlNode = stack.Pop();
			foreach (HtmlNode item in htmlNode.Descendants())
			{
				stack.Push(item);
			}
			if (htmlNode.NodeType == HtmlNodeType.Text)
			{
				hashSet.Add(htmlNode.InnerText.Trim());
				string[] array = htmlNode.InnerText.Split(new char[3] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (string text in array)
				{
					hashSet.Add(text.Trim());
				}
			}
			if (htmlNode.NodeType != HtmlNodeType.Element)
			{
				continue;
			}
			hashSet.Add(htmlNode.OriginalName.Trim());
			foreach (HtmlAttribute item2 in (IEnumerable<HtmlAttribute>)htmlNode.Attributes)
			{
				hashSet.Add(item2.OriginalName.Trim());
				hashSet.Add(item2.Value.Trim());
			}
		}
		return hashSet;
	}

	public static HashSet<string> GetAllStringsThatMatchAHash(IEnumerable<string> listOfStrings, ISet<int> listOfHashes)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (string listOfString in listOfStrings)
		{
			int item = (int)Jenkins.Hash(listOfString);
			if (listOfHashes.Contains(item))
			{
				hashSet.Add(listOfString);
			}
		}
		return hashSet;
	}
}
