namespace RageLib.ResourceWrappers.Drawables;

public interface IDrawableFile : IResourceFile
{
	IDrawable Drawable { get; }
}
