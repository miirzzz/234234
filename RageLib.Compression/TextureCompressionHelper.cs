namespace RageLib.Compression;

public static class TextureCompressionHelper
{
	public static byte[] DecompressBC1(byte[] data, int width, int height)
	{
		byte[] array = new byte[width * height * 4];
		DXTex.DeompressImage(data, array, width, height, width * 2, 71);
		return array;
	}

	public static byte[] DecompressBC2(byte[] data, int width, int height)
	{
		byte[] array = new byte[width * height * 4];
		DXTex.DeompressImage(data, array, width, height, width * 4, 74);
		return array;
	}

	public static byte[] DecompressBC3(byte[] data, int width, int height)
	{
		byte[] array = new byte[width * height * 4];
		DXTex.DeompressImage(data, array, width, height, width * 4, 77);
		return array;
	}

	public static byte[] DecompressBC4(byte[] data, int width, int height)
	{
		byte[] array = new byte[width * height * 4];
		DXTex.DeompressImage(data, array, width, height, width * 2, 80);
		return array;
	}

	public static byte[] DecompressBC5(byte[] data, int width, int height)
	{
		byte[] array = new byte[width * height * 4];
		DXTex.DeompressImage(data, array, width, height, width * 4, 83);
		return array;
	}

	public static byte[] DecompressBC7(byte[] data, int width, int height)
	{
		byte[] array = new byte[width * height * 4];
		DXTex.DeompressImage(data, array, width, height, width * 4, 98);
		return array;
	}
}
