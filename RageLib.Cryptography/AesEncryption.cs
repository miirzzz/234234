using System.Security.Cryptography;

namespace RageLib.Cryptography;

public class AesEncryption : IEncryptionAlgorithm
{
	public byte[] Key { get; set; }

	public int Rounds { get; set; }

	public AesEncryption(byte[] key, int rounds = 1)
	{
		Key = key;
		Rounds = rounds;
	}

	public byte[] Encrypt(byte[] data)
	{
		return EncryptData(data, Key, Rounds);
	}

	public byte[] Decrypt(byte[] data)
	{
		return DecryptData(data, Key, Rounds);
	}

	public static byte[] EncryptData(byte[] data, byte[] key, int rounds = 1)
	{
		Rijndael rijndael = Rijndael.Create();
		rijndael.KeySize = 256;
		rijndael.Key = key;
		rijndael.BlockSize = 128;
		rijndael.Mode = CipherMode.ECB;
		rijndael.Padding = PaddingMode.None;
		byte[] array = (byte[])data.Clone();
		int num = data.Length - data.Length % 16;
		if (num > 0)
		{
			ICryptoTransform cryptoTransform = rijndael.CreateEncryptor();
			for (int i = 0; i < rounds; i++)
			{
				cryptoTransform.TransformBlock(array, 0, num, array, 0);
			}
		}
		return array;
	}

	public static byte[] DecryptData(byte[] data, byte[] key, int rounds = 1)
	{
		Rijndael rijndael = Rijndael.Create();
		rijndael.KeySize = 256;
		rijndael.Key = key;
		rijndael.BlockSize = 128;
		rijndael.Mode = CipherMode.ECB;
		rijndael.Padding = PaddingMode.None;
		byte[] array = (byte[])data.Clone();
		int num = data.Length - data.Length % 16;
		if (num > 0)
		{
			ICryptoTransform cryptoTransform = rijndael.CreateDecryptor();
			for (int i = 0; i < rounds; i++)
			{
				cryptoTransform.TransformBlock(array, 0, num, array, 0);
			}
		}
		return array;
	}
}
