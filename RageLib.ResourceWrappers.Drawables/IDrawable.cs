namespace RageLib.ResourceWrappers.Drawables;

public interface IDrawable
{
	string Name { get; }

	IShaderGroup ShaderGroup { get; }
}
