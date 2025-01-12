namespace RageLib.GTA5.Cryptography;

public class GTA5Hash
{
	public static byte[] LUT;

	static GTA5Hash()
	{
		LUT = GTA5Constants.PC_LUT;
	}

	public static uint CalculateHash(string text)
	{
		uint num = 0u;
		for (int i = 0; i < text.Length; i++)
		{
			uint num2 = 1025 * (LUT[(uint)text[i]] + num);
			num = (num2 >> 6) ^ num2;
		}
		return 32769 * ((9 * num >> 11) ^ (9 * num));
	}
}
