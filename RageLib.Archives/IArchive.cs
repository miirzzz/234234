using System;

namespace RageLib.Archives;

public interface IArchive : IDisposable
{
	IArchiveDirectory Root { get; }

	void Flush();
}
