using System;
using System.IO;
using RageLib.Data;

namespace RageLib.Resources;

public class ResourceDataWriter : DataWriter
{
	private const long SYSTEM_BASE = 1342177280L;

	private const long GRAPHICS_BASE = 1610612736L;

	private Stream systemStream;

	private Stream graphicsStream;

	public override long Length => -1L;

	public override long Position { get; set; }

	public ResourceDataWriter(Stream systemStream, Stream graphicsStream, Endianess endianess = Endianess.LittleEndian)
		: base(null, endianess)
	{
		this.systemStream = systemStream;
		this.graphicsStream = graphicsStream;
	}

	protected override void WriteToStream(byte[] value, bool ignoreEndianess = true)
	{
		if ((Position & 0x50000000) == 1342177280)
		{
			systemStream.Position = Position & -1342177281;
			if (!ignoreEndianess && base.Endianess == Endianess.BigEndian)
			{
				byte[] array = (byte[])value.Clone();
				Array.Reverse(array);
				systemStream.Write(array, 0, array.Length);
			}
			else
			{
				systemStream.Write(value, 0, value.Length);
			}
			Position = systemStream.Position | 0x50000000;
			return;
		}
		if ((Position & 0x60000000) == 1610612736)
		{
			graphicsStream.Position = Position & -1610612737;
			if (!ignoreEndianess && base.Endianess == Endianess.BigEndian)
			{
				byte[] array2 = (byte[])value.Clone();
				Array.Reverse(array2);
				graphicsStream.Write(array2, 0, array2.Length);
			}
			else
			{
				graphicsStream.Write(value, 0, value.Length);
			}
			Position = graphicsStream.Position | 0x60000000;
			return;
		}
		throw new Exception("illegal position!");
	}

	public void WriteBlock(IResourceBlock value)
	{
		value.Write(this);
	}
}
