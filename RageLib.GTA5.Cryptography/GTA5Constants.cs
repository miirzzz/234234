using System;
using System.IO;
using RageLib.GTA5.Cryptography.Exceptions;
using RageLib.GTA5.Cryptography.Helpers;
using RageLib.Helpers;

namespace RageLib.GTA5.Cryptography;

public static class GTA5Constants
{
	public static byte[] PC_AES_KEY;

	public static byte[][] PC_NG_KEYS;

	public static uint[][][] PC_NG_DECRYPT_TABLES;

	public static byte[] PC_LUT;

	public static void Generate(byte[] exeData)
	{
		MemoryStream stream = new MemoryStream(exeData);
		PC_AES_KEY = HashSearch.SearchHash(stream, GTA5HashConstants.PC_AES_KEY_HASH);
		if (PC_AES_KEY == null)
		{
			throw new KeyNotFoundException("AES key not found.");
		}
		Console.WriteLine("aes key found");
		PC_NG_KEYS = HashSearch.SearchHashes(stream, GTA5HashConstants.PC_NG_KEY_HASHES, 1, 272);
		for (int i = 0; i < PC_NG_KEYS.Length; i++)
		{
			if (PC_NG_KEYS[i] == null)
			{
				throw new KeyNotFoundException("NG key not found.");
			}
		}
		Console.WriteLine("ng keys found");
		byte[][] array = HashSearch.SearchHashes(stream, GTA5HashConstants.PC_NG_DECRYPT_TABLE_HASHES, 1, 1024);
		for (int j = 0; j < array.Length; j++)
		{
			if (array[j] == null)
			{
				throw new KeyNotFoundException("NG decryption table not found.");
			}
		}
		Console.WriteLine("ng decrypt tables found");
		PC_NG_DECRYPT_TABLES = new uint[17][][];
		for (int k = 0; k < 17; k++)
		{
			PC_NG_DECRYPT_TABLES[k] = new uint[16][];
			for (int l = 0; l < 16; l++)
			{
				byte[] src = array[l + 16 * k];
				PC_NG_DECRYPT_TABLES[k][l] = new uint[256];
				Buffer.BlockCopy(src, 0, PC_NG_DECRYPT_TABLES[k][l], 0, 1024);
			}
		}
		PC_LUT = HashSearch.SearchHash(stream, GTA5HashConstants.PC_LUT_HASH, 1, 256);
		if (PC_LUT == null)
		{
			throw new KeyNotFoundException("LUT not found.");
		}
		Console.WriteLine("ng hash LUTs found");
	}

	public static void LoadFromPath(string path)
	{
		PC_AES_KEY = File.ReadAllBytes(path + "\\gtav_aes_key.dat");
		PC_NG_KEYS = CryptoIO.ReadNgKeys(path + "\\gtav_ng_key.dat");
		PC_NG_DECRYPT_TABLES = CryptoIO.ReadNgTables(path + "\\gtav_ng_decrypt_tables.dat");
		PC_LUT = File.ReadAllBytes(path + "\\gtav_hash_lut.dat");
	}

	public static void SaveToPath(string path)
	{
		File.WriteAllBytes(path + "\\gtav_aes_key.dat", PC_AES_KEY);
		CryptoIO.WriteNgKeys(path + "\\gtav_ng_key.dat", PC_NG_KEYS);
		CryptoIO.WriteNgTables(path + "\\gtav_ng_decrypt_tables.dat", PC_NG_DECRYPT_TABLES);
		File.WriteAllBytes(path + "\\gtav_hash_lut.dat", PC_LUT);
	}
}
