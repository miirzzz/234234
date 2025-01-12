namespace RageLib.Archives;

public class DataBlock
{
	public long Offset { get; set; }

	public long Length { get; set; }

	public object Tag { get; set; }

	public DataBlock(long offset, long length, object tag = null)
	{
		Offset = offset;
		Length = length;
		Tag = tag;
	}
}
