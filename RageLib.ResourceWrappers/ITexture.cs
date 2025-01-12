namespace RageLib.ResourceWrappers;

public interface ITexture
{
	string Name { get; set; }

	int Width { get; }

	int Height { get; }

	int MipMapLevels { get; }

	TextureFormat Format { get; }

	int Stride { get; }

	byte[] GetTextureData();

	byte[] GetTextureData(int mipMapLevel);

	void SetTextureData(byte[] data);

	void SetTextureData(byte[] data, int mipMapLevel);

	void Reset(int width, int height, int mipMapLevels, int stride, TextureFormat Format);
}
