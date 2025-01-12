using System;
using RageLib.Helpers;
using RageLib.ResourceWrappers;

namespace RageLib.Compression;

public static class TextureHelper
{
	public static byte[] GetRgbaImage(ITexture model, int mipMapLevel = 0)
	{
		byte[] textureData = model.GetTextureData(mipMapLevel);
		return model.Format switch
		{
			TextureFormat.D3DFMT_DXT1 => TextureCompressionHelper.DecompressBC1(textureData, model.Width, model.Height), 
			TextureFormat.D3DFMT_DXT3 => TextureCompressionHelper.DecompressBC2(textureData, model.Width, model.Height), 
			TextureFormat.D3DFMT_DXT5 => TextureCompressionHelper.DecompressBC3(textureData, model.Width, model.Height), 
			TextureFormat.D3DFMT_ATI1 => TextureCompressionHelper.DecompressBC4(textureData, model.Width, model.Height), 
			TextureFormat.D3DFMT_ATI2 => TextureCompressionHelper.DecompressBC5(textureData, model.Width, model.Height), 
			TextureFormat.D3DFMT_BC7 => TextureCompressionHelper.DecompressBC7(textureData, model.Width, model.Height), 
			TextureFormat.D3DFMT_A8 => TextureConvert.MakeRGBAFromA8(textureData, model.Width, model.Height), 
			TextureFormat.D3DFMT_L8 => TextureConvert.MakeARGBFromL8(textureData, model.Width, model.Height), 
			TextureFormat.D3DFMT_A1R5G5B5 => TextureConvert.MakeARGBFromA1R5G5B5(textureData, model.Width, model.Height), 
			TextureFormat.D3DFMT_A8B8G8R8 => TextureConvert.MakeRGBAFromA8B8G8R8(textureData, model.Width, model.Height), 
			TextureFormat.D3DFMT_A8R8G8B8 => TextureConvert.MakeRGBAFromA8R8G8B8(textureData, model.Width, model.Height), 
			_ => throw new Exception("unknown format"), 
		};
	}
}
