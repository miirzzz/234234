using System.IO;
using System.IO.Compression;

namespace RageLib.Compression;

public class DeflateCompression : ICompressionAlgorithm
{
	public byte[] Compress(byte[] data)
	{
		return CompressData(data);
	}

	public byte[] Decompress(byte[] data, int decompressedLength)
	{
		return DecompressData(data, decompressedLength);
	}

	public static byte[] CompressData(byte[] data)
	{
		MemoryStream memoryStream = new MemoryStream(data);
		DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress);
		deflateStream.Write(data, 0, data.Length);
		byte[] array = new byte[memoryStream.Length];
		memoryStream.Position = 0L;
		memoryStream.Read(array, 0, (int)memoryStream.Length);
		deflateStream.Close();
		return array;
	}

	public static byte[] DecompressData(byte[] data, int decompressedLength)
	{
		DeflateStream deflateStream = new DeflateStream(new MemoryStream(data), CompressionMode.Decompress);
		byte[] array = new byte[decompressedLength];
		deflateStream.Read(array, 0, decompressedLength);
		deflateStream.Close();
		return array;
	}
}
