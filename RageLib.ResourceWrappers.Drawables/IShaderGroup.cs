namespace RageLib.ResourceWrappers.Drawables;

public interface IShaderGroup
{
	ITextureDictionary TextureDictionary { get; }

	IShaderList Shaders { get; }
}
