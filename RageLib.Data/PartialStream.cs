using System;
using System.IO;

namespace RageLib.Data;

public class PartialStream : Stream
{
	private Stream baseStream;

	private GetOffsetDelegate getOffsetDelegate;

	private GetLengthDelegate getLengthDelegate;

	private SetLengthDelegate setLengthDelegate;

	private long relativePosiiton;

	public override bool CanSeek => true;

	public override bool CanRead => baseStream.CanRead;

	public override bool CanWrite => baseStream.CanWrite;

	public override long Length => getLengthDelegate();

	public override long Position
	{
		get
		{
			return relativePosiiton;
		}
		set
		{
			if (Position > Length)
			{
				SetLength(Position);
			}
			relativePosiiton = value;
		}
	}

	public PartialStream(Stream baseStream, GetOffsetDelegate getOffsetDelegate, GetLengthDelegate getLengthDelegate, SetLengthDelegate setLengthDelegate = null)
	{
		this.baseStream = baseStream;
		this.getOffsetDelegate = getOffsetDelegate;
		this.getLengthDelegate = getLengthDelegate;
		this.setLengthDelegate = setLengthDelegate;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		long position = baseStream.Position;
		int val = (int)(getLengthDelegate() - relativePosiiton);
		int count2 = Math.Min(count, val);
		baseStream.Position = getOffsetDelegate() + relativePosiiton;
		int num = baseStream.Read(buffer, offset, count2);
		relativePosiiton += num;
		baseStream.Position = position;
		return num;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		long position = baseStream.Position;
		long num = relativePosiiton + count;
		if (num > Length)
		{
			setLengthDelegate(num);
		}
		int val = (int)(getLengthDelegate() - relativePosiiton);
		Math.Min(count, val);
		baseStream.Position = getOffsetDelegate() + relativePosiiton;
		baseStream.Write(buffer, offset, count);
		relativePosiiton += count;
		baseStream.Position = position;
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		switch (origin)
		{
		case SeekOrigin.Begin:
			relativePosiiton = offset;
			break;
		case SeekOrigin.Current:
			relativePosiiton += offset;
			break;
		case SeekOrigin.End:
			relativePosiiton = getLengthDelegate() + offset;
			break;
		}
		return relativePosiiton;
	}

	public override void SetLength(long value)
	{
		setLengthDelegate(value);
	}

	public override void Flush()
	{
		baseStream.Flush();
	}
}
