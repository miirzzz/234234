namespace RageLib.Compression;

public interface ICompressionAlgorithm
{
	byte[] Compress(byte[] data);

	byte[] Decompress(byte[] data, int decompressedLength);
}
