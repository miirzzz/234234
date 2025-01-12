namespace RageLib.Hash;

public class Jenkins
{
	public static uint Hash(string key)
	{
		uint num = 0u;
		for (int i = 0; i < key.Length; i++)
		{
			num += key[i];
			uint num2 = num;
			num = num2 + (num2 << 10);
			uint num3 = num;
			num = num3 ^ (num3 >> 6);
		}
		uint num4 = num;
		num = num4 + (num4 << 3);
		uint num5 = num;
		num = num5 ^ (num5 >> 11);
		uint num6 = num;
		return num6 + (num6 << 15);
	}
}
