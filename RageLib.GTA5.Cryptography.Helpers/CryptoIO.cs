using System.IO;
using RageLib.Data;

namespace RageLib.GTA5.Cryptography.Helpers;

public class CryptoIO
{
	public static byte[][] ReadNgKeys(string fileName)
	{
		FileStream fileStream = new FileStream(fileName, FileMode.Open);
		DataReader dataReader = new DataReader(fileStream);
		byte[][] array = new byte[101][];
		for (int i = 0; i < 101; i++)
		{
			array[i] = dataReader.ReadBytes(272);
		}
		fileStream.Close();
		return array;
	}

	public static void WriteNgKeys(string fileName, byte[][] keys)
	{
		FileStream fileStream = new FileStream(fileName, FileMode.Create);
		DataWriter dataWriter = new DataWriter(fileStream);
		for (int i = 0; i < 101; i++)
		{
			dataWriter.Write(keys[i]);
		}
		fileStream.Close();
	}

	public static uint[][][] ReadNgTables(string fileName)
	{
		FileStream fileStream = new FileStream(fileName, FileMode.Open);
		DataReader dataReader = new DataReader(fileStream);
		uint[][][] array = new uint[17][][];
		for (int i = 0; i < 17; i++)
		{
			array[i] = new uint[16][];
			for (int j = 0; j < 16; j++)
			{
				array[i][j] = new uint[256];
				for (int k = 0; k < 256; k++)
				{
					array[i][j][k] = dataReader.ReadUInt32();
				}
			}
		}
		fileStream.Close();
		return array;
	}

	public static void WriteNgTables(string fileName, uint[][][] tableData)
	{
		FileStream fileStream = new FileStream(fileName, FileMode.Create);
		DataWriter dataWriter = new DataWriter(fileStream);
		for (int i = 0; i < 17; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				for (int k = 0; k < 256; k++)
				{
					dataWriter.Write(tableData[i][j][k]);
				}
			}
		}
		fileStream.Close();
	}
}
