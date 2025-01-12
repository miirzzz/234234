using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace RageLib.Helpers;

public static class HashSearch
{
	private const int BLOCK_LENGTH = 1048576;

	private const int ALIGN_LENGTH = 16;

	public static byte[] SearchHash(Stream stream, byte[] hash, int length = 32)
	{
		return SearchHashes(stream, new List<byte[]> { hash }, length)[0];
	}

	public static byte[][] SearchHashes(Stream stream, IList<byte[]> hashes, int length = 32)
	{
		byte[][] result = new byte[hashes.Count][];
		Parallel.For(0, (int)(stream.Length / 1048576), delegate(int k)
		{
			SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
			byte[] array = new byte[length];
			for (int i = 0; i < 65536; i++)
			{
				int num = k * 1048576 + i * 16;
				if (num < stream.Length)
				{
					lock (stream)
					{
						stream.Position = num;
						stream.Read(array, 0, length);
					}
					byte[] first = sHA1CryptoServiceProvider.ComputeHash(array);
					for (int j = 0; j < hashes.Count; j++)
					{
						if (first.SequenceEqual(hashes[j]))
						{
							result[j] = (byte[])array.Clone();
						}
					}
				}
			}
		});
		return result;
	}
}
