using RageLib.Compression;

namespace RageLib.Helpers;

public static class TextureConvert
{
	public static byte[] MakeRGBAFromA8(byte[] data, int width, int height)
	{
		byte[] array = new byte[width * height * 4];
		DXTex.ConvertImage(data, 65, width, array, 28, width * 4, width, height);
		return array;
	}

	public static byte[] MakeRGBAFromA8B8G8R8(byte[] data, int width, int height)
	{
		byte[] array = new byte[width * height * 4];
		DXTex.ConvertImage(data, 28, width * 4, array, 28, width * 4, width, height);
		return array;
	}

	public static byte[] MakeRGBAFromA8R8G8B8(byte[] data, int width, int height)
	{
		byte[] array = new byte[width * height * 4];
		DXTex.ConvertImage(data, 87, width * 4, array, 28, width * 4, width, height);
		return array;
	}

	public static byte[] MakeARGBFromL8(byte[] data, int width, int height)
	{
		byte[] array = new byte[width * height * 4];
		DXTex.ConvertImage(data, 61, width, array, 28, width * 4, width, height);
		return array;
	}

	public static byte[] MakeARGBFromA1R5G5B5(byte[] data, int width, int height)
	{
		byte[] array = new byte[width * height * 4];
		DXTex.ConvertImage(data, 86, width * 2, array, 28, width * 4, width, height);
		return array;
	}
}
