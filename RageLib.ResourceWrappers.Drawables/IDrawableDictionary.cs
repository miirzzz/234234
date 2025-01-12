namespace RageLib.ResourceWrappers.Drawables;

public interface IDrawableDictionary
{
	IDrawableList Drawables { get; set; }

	uint GetHash(int index);
}
