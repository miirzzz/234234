using System.Globalization;

namespace RageLib.GTA5.PSOWrappers.Xml;

public static class HexConverter
{
	public static string ToHex(int value)
	{
		return "0x" + value.ToString("X8");
	}

	public static int ToUInt32(string value)
	{
		if (value.StartsWith("0x"))
		{
			return int.Parse(value.Substring(2), NumberStyles.HexNumber);
		}
		return int.Parse(value, NumberStyles.HexNumber);
	}
}
