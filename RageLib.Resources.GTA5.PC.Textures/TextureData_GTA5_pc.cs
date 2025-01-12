using System;

namespace RageLib.Resources.GTA5.PC.Textures;

public class TextureData_GTA5_pc : ResourceGraphicsBlock
{
	public byte[] FullData;

	public override long Length => FullData.Length;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Convert.ToUInt32(parameters[0]);
		Convert.ToInt32(parameters[1]);
		int num = Convert.ToInt32(parameters[2]);
		int num2 = Convert.ToInt32(parameters[3]);
		int num3 = Convert.ToInt32(parameters[4]);
		int num4 = 0;
		int num5 = num3 * num;
		for (int i = 0; i < num2; i++)
		{
			num4 += num5;
			num5 /= 4;
		}
		FullData = reader.ReadBytes(num4);
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(FullData);
	}
}
