using System;
using System.IO;
using System.Windows.Forms;
using RageLib.Compression;
using RageLib.ResourceWrappers;

namespace RageLib.Helpers;

public class DDSIO
{
	public static void LoadTextureData(ITexture texture, Stream stream)
	{
		byte[] array = new byte[16777216];
		_ = IntPtr.Zero;
		int width = 0;
		int height = 0;
		int mipLevels = 0;
		int format = 0;
		int stride = 0;
		int dataLength = 16777216;
		byte[] array2 = new byte[stream.Length];
		stream.Position = 0L;
		stream.Read(array2, 0, array2.Length);
		DXTexdds.LoadDDSImageFromStream(array2, array2.Length, array, ref dataLength, ref width, ref height, ref stride, ref mipLevels, ref format);
		if (dataLength > 16777216)
		{
			array = new byte[dataLength];
			DXTexdds.LoadDDSImageFromStream(array2, array2.Length, array, ref dataLength, ref width, ref height, ref stride, ref mipLevels, ref format);
		}
		Array.Resize(ref array, dataLength);
		switch ((DXGI_FORMAT)format)
		{
		case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM:
			texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_DXT1);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM:
			texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_DXT3);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM:
			texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_DXT5);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM:
			texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_ATI1);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM:
			texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_ATI2);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM:
			texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_BC7);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM:
			texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_A1R5G5B5);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_A8_UNORM:
			texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_A8);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM:
			texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_A8B8G8R8);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_R8_UNORM:
			texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_L8);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM:
			texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_A8R8G8B8);
			texture.SetTextureData(array);
			break;
		default:
			MessageBox.Show("format not supported!");
			throw new Exception("unsupported format");
		}
	}

	public static void LoadTextureData(ITexture texture, string fileName)
	{
		byte[] array = new byte[16777216];
		_ = IntPtr.Zero;
		int width = 0;
		int height = 0;
		int mipLevels = 0;
		int format = 0;
		int stride = 0;
		int dataLength = 16777216;
		DXTexdds.LoadDDSImage(fileName, array, ref dataLength, ref width, ref height, ref stride, ref mipLevels, ref format);
		if (dataLength > 16777216)
		{
			array = new byte[dataLength];
			DXTexdds.LoadDDSImage(fileName, array, ref dataLength, ref width, ref height, ref stride, ref mipLevels, ref format);
		}
		Array.Resize(ref array, dataLength);
		switch ((DXGI_FORMAT)format)
		{
		case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM:
			texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_DXT1);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM:
			texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_DXT3);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM:
			texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_DXT5);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM:
			texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_ATI1);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM:
			texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_ATI2);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM:
			texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_BC7);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM:
			texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_A1R5G5B5);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_A8_UNORM:
			texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_A8);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM:
			texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_A8B8G8R8);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_R8_UNORM:
			texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_L8);
			texture.SetTextureData(array);
			break;
		case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM:
			texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_A8R8G8B8);
			texture.SetTextureData(array);
			break;
		default:
			MessageBox.Show("format not supported!");
			throw new Exception("unsupported format");
		}
	}

	public static void SaveTextureData(ITexture texture, Stream stream)
	{
		byte[] textureData = texture.GetTextureData();
		DXGI_FORMAT format = DXGI_FORMAT.DXGI_FORMAT_UNKNOWN;
		switch (texture.Format)
		{
		case TextureFormat.D3DFMT_DXT1:
			format = DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM;
			break;
		case TextureFormat.D3DFMT_DXT3:
			format = DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM;
			break;
		case TextureFormat.D3DFMT_DXT5:
			format = DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM;
			break;
		case TextureFormat.D3DFMT_ATI1:
			format = DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM;
			break;
		case TextureFormat.D3DFMT_ATI2:
			format = DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM;
			break;
		case TextureFormat.D3DFMT_BC7:
			format = DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM;
			break;
		case TextureFormat.D3DFMT_A1R5G5B5:
			format = DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM;
			break;
		case TextureFormat.D3DFMT_A8:
			format = DXGI_FORMAT.DXGI_FORMAT_A8_UNORM;
			break;
		case TextureFormat.D3DFMT_A8B8G8R8:
			format = DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM;
			break;
		case TextureFormat.D3DFMT_L8:
			format = DXGI_FORMAT.DXGI_FORMAT_R8_UNORM;
			break;
		case TextureFormat.D3DFMT_A8R8G8B8:
			format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM;
			break;
		}
		byte[] array = new byte[16777216];
		int length = 16777216;
		DXTexdds.SaveDDSImageToStream(array, ref length, textureData, 0, texture.Width, texture.Height, 2 * texture.Width, texture.MipMapLevels, (int)format);
		if (length > 16777216)
		{
			array = new byte[length];
			DXTexdds.SaveDDSImageToStream(array, ref length, textureData, 0, texture.Width, texture.Height, 2 * texture.Width, texture.MipMapLevels, (int)format);
		}
		stream.Write(array, 0, length);
	}

	public static void SaveTextureData(ITexture texture, string fileName)
	{
		byte[] textureData = texture.GetTextureData();
		DXGI_FORMAT format = DXGI_FORMAT.DXGI_FORMAT_UNKNOWN;
		switch (texture.Format)
		{
		case TextureFormat.D3DFMT_DXT1:
			format = DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM;
			break;
		case TextureFormat.D3DFMT_DXT3:
			format = DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM;
			break;
		case TextureFormat.D3DFMT_DXT5:
			format = DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM;
			break;
		case TextureFormat.D3DFMT_ATI1:
			format = DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM;
			break;
		case TextureFormat.D3DFMT_ATI2:
			format = DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM;
			break;
		case TextureFormat.D3DFMT_BC7:
			format = DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM;
			break;
		case TextureFormat.D3DFMT_A1R5G5B5:
			format = DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM;
			break;
		case TextureFormat.D3DFMT_A8:
			format = DXGI_FORMAT.DXGI_FORMAT_A8_UNORM;
			break;
		case TextureFormat.D3DFMT_A8B8G8R8:
			format = DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM;
			break;
		case TextureFormat.D3DFMT_L8:
			format = DXGI_FORMAT.DXGI_FORMAT_R8_UNORM;
			break;
		case TextureFormat.D3DFMT_A8R8G8B8:
			format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM;
			break;
		}
		DXTexdds.SaveDDSImage(fileName, textureData, 0, texture.Width, texture.Height, 2 * texture.Width, texture.MipMapLevels, (int)format);
	}
}
