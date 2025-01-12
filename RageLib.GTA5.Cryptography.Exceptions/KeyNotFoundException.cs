using System;

namespace RageLib.GTA5.Cryptography.Exceptions;

public class KeyNotFoundException : Exception
{
	public KeyNotFoundException()
	{
	}

	public KeyNotFoundException(string message)
		: base(message)
	{
	}
}
