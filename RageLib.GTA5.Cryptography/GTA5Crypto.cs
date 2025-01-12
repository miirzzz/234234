using System;
using RageLib.Cryptography;

namespace RageLib.GTA5.Cryptography;

public class GTA5Crypto : IEncryptionAlgorithm
{
	public byte[] Key { get; set; }

	public byte[] Decrypt(byte[] data)
	{
		return Decrypt(data, Key);
	}

	public static byte[] Decrypt(byte[] data, byte[] key)
	{
		byte[] array = new byte[data.Length];
		uint[] array2 = new uint[key.Length / 4];
		Buffer.BlockCopy(key, 0, array2, 0, key.Length);
		for (int i = 0; i < data.Length / 16; i++)
		{
			byte[] array3 = new byte[16];
			Array.Copy(data, 16 * i, array3, 0, 16);
			Array.Copy(DecryptBlock(array3, array2), 0, array, 16 * i, 16);
		}
		if (data.Length % 16 != 0)
		{
			int num = data.Length % 16;
			Buffer.BlockCopy(data, data.Length - num, array, data.Length - num, num);
		}
		return array;
	}

	public static byte[] DecryptBlock(byte[] data, uint[] key)
	{
		byte[] data2 = data;
		uint[][] array = new uint[17][];
		for (int i = 0; i < 17; i++)
		{
			array[i] = new uint[4];
			array[i][0] = key[4 * i];
			array[i][1] = key[4 * i + 1];
			array[i][2] = key[4 * i + 2];
			array[i][3] = key[4 * i + 3];
		}
		data2 = DecryptRoundA(data2, array[0], GTA5Constants.PC_NG_DECRYPT_TABLES[0]);
		data2 = DecryptRoundA(data2, array[1], GTA5Constants.PC_NG_DECRYPT_TABLES[1]);
		for (int j = 2; j <= 15; j++)
		{
			data2 = DecryptRoundB(data2, array[j], GTA5Constants.PC_NG_DECRYPT_TABLES[j]);
		}
		return DecryptRoundA(data2, array[16], GTA5Constants.PC_NG_DECRYPT_TABLES[16]);
	}

	public static byte[] DecryptRoundA(byte[] data, uint[] key, uint[][] table)
	{
		uint value = table[0][data[0]] ^ table[1][data[1]] ^ table[2][data[2]] ^ table[3][data[3]] ^ key[0];
		uint value2 = table[4][data[4]] ^ table[5][data[5]] ^ table[6][data[6]] ^ table[7][data[7]] ^ key[1];
		uint value3 = table[8][data[8]] ^ table[9][data[9]] ^ table[10][data[10]] ^ table[11][data[11]] ^ key[2];
		uint value4 = table[12][data[12]] ^ table[13][data[13]] ^ table[14][data[14]] ^ table[15][data[15]] ^ key[3];
		byte[] array = new byte[16];
		Array.Copy(BitConverter.GetBytes(value), 0, array, 0, 4);
		Array.Copy(BitConverter.GetBytes(value2), 0, array, 4, 4);
		Array.Copy(BitConverter.GetBytes(value3), 0, array, 8, 4);
		Array.Copy(BitConverter.GetBytes(value4), 0, array, 12, 4);
		return array;
	}

	public static byte[] DecryptRoundB(byte[] data, uint[] key, uint[][] table)
	{
		uint num = table[0][data[0]] ^ table[7][data[7]] ^ table[10][data[10]] ^ table[13][data[13]] ^ key[0];
		uint num2 = table[1][data[1]] ^ table[4][data[4]] ^ table[11][data[11]] ^ table[14][data[14]] ^ key[1];
		uint num3 = table[2][data[2]] ^ table[5][data[5]] ^ table[8][data[8]] ^ table[15][data[15]] ^ key[2];
		uint num4 = table[3][data[3]] ^ table[6][data[6]] ^ table[9][data[9]] ^ table[12][data[12]] ^ key[3];
		return new byte[16]
		{
			(byte)(num & 0xFF),
			(byte)((num >> 8) & 0xFF),
			(byte)((num >> 16) & 0xFF),
			(byte)((num >> 24) & 0xFF),
			(byte)(num2 & 0xFF),
			(byte)((num2 >> 8) & 0xFF),
			(byte)((num2 >> 16) & 0xFF),
			(byte)((num2 >> 24) & 0xFF),
			(byte)(num3 & 0xFF),
			(byte)((num3 >> 8) & 0xFF),
			(byte)((num3 >> 16) & 0xFF),
			(byte)((num3 >> 24) & 0xFF),
			(byte)(num4 & 0xFF),
			(byte)((num4 >> 8) & 0xFF),
			(byte)((num4 >> 16) & 0xFF),
			(byte)((num4 >> 24) & 0xFF)
		};
	}
}
