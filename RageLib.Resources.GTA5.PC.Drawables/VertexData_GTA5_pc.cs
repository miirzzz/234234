using System;

namespace RageLib.Resources.GTA5.PC.Drawables;

public class VertexData_GTA5_pc : ResourceSystemBlock
{
	private int length;

	public int cnt;

	private VertexDeclaration info;

	public object[] VertexData;

	private uint[] Types;

	public override long Length => length;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		int num = Convert.ToInt32(parameters[0]);
		int num2 = Convert.ToInt32(parameters[1]);
		VertexDeclaration vertexDeclaration = (VertexDeclaration)parameters[2];
		cnt = num2;
		info = vertexDeclaration;
		bool[] array = new bool[16];
		for (int i = 0; i < 16; i++)
		{
			array[i] = ((vertexDeclaration.Flags >> i) & 1) == 1;
		}
		Types = new uint[16];
		for (int j = 0; j < 16; j++)
		{
			Types[j] = (uint)((vertexDeclaration.Types >> 4 * j) & 0xF);
		}
		VertexData = new object[16];
		for (int k = 0; k < 16; k++)
		{
			if (array[k])
			{
				switch (Types[k])
				{
				case 0u:
					VertexData[k] = new ushort[num2];
					break;
				case 1u:
					VertexData[k] = new ushort[2 * num2];
					break;
				case 2u:
					VertexData[k] = new ushort[3 * num2];
					break;
				case 3u:
					VertexData[k] = new ushort[4 * num2];
					break;
				case 4u:
					VertexData[k] = new float[num2];
					break;
				case 5u:
					VertexData[k] = new float[2 * num2];
					break;
				case 6u:
					VertexData[k] = new float[3 * num2];
					break;
				case 7u:
					VertexData[k] = new float[4 * num2];
					break;
				case 8u:
					VertexData[k] = new uint[num2];
					break;
				case 9u:
					VertexData[k] = new uint[num2];
					break;
				case 10u:
					VertexData[k] = new uint[num2];
					break;
				default:
					throw new Exception();
				}
			}
		}
		_ = reader.Position;
		for (int l = 0; l < num2; l++)
		{
			for (int m = 0; m < 16; m++)
			{
				if (array[m])
				{
					switch (Types[m])
					{
					case 0u:
						(VertexData[m] as ushort[])[l] = reader.ReadUInt16();
						break;
					case 1u:
					{
						ushort[] obj6 = VertexData[m] as ushort[];
						obj6[l * 2] = reader.ReadUInt16();
						obj6[l * 2 + 1] = reader.ReadUInt16();
						break;
					}
					case 2u:
					{
						ushort[] obj5 = VertexData[m] as ushort[];
						obj5[l * 3] = reader.ReadUInt16();
						obj5[l * 3 + 1] = reader.ReadUInt16();
						obj5[l * 3 + 2] = reader.ReadUInt16();
						break;
					}
					case 3u:
					{
						ushort[] obj4 = VertexData[m] as ushort[];
						obj4[l * 4] = reader.ReadUInt16();
						obj4[l * 4 + 1] = reader.ReadUInt16();
						obj4[l * 4 + 2] = reader.ReadUInt16();
						obj4[l * 4 + 3] = reader.ReadUInt16();
						break;
					}
					case 4u:
						(VertexData[m] as float[])[l] = reader.ReadSingle();
						break;
					case 5u:
					{
						float[] obj3 = VertexData[m] as float[];
						obj3[l * 2] = reader.ReadSingle();
						obj3[l * 2 + 1] = reader.ReadSingle();
						break;
					}
					case 6u:
					{
						float[] obj2 = VertexData[m] as float[];
						obj2[l * 3] = reader.ReadSingle();
						obj2[l * 3 + 1] = reader.ReadSingle();
						obj2[l * 3 + 2] = reader.ReadSingle();
						break;
					}
					case 7u:
					{
						float[] obj = VertexData[m] as float[];
						obj[l * 4] = reader.ReadSingle();
						obj[l * 4 + 1] = reader.ReadSingle();
						obj[l * 4 + 2] = reader.ReadSingle();
						obj[l * 4 + 3] = reader.ReadSingle();
						break;
					}
					case 8u:
					case 9u:
					case 10u:
						(VertexData[m] as uint[])[l] = reader.ReadUInt32();
						break;
					default:
						throw new Exception();
					}
				}
			}
		}
		length = num * num2;
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		for (int i = 0; i < cnt; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				if (VertexData[j] != null)
				{
					switch (Types[j])
					{
					case 0u:
					{
						ushort[] array9 = VertexData[j] as ushort[];
						writer.Write(array9[i]);
						break;
					}
					case 1u:
					{
						ushort[] array8 = VertexData[j] as ushort[];
						writer.Write(array8[i * 2]);
						writer.Write(array8[i * 2 + 1]);
						break;
					}
					case 2u:
					{
						ushort[] array7 = VertexData[j] as ushort[];
						writer.Write(array7[i * 3]);
						writer.Write(array7[i * 3 + 1]);
						writer.Write(array7[i * 3 + 2]);
						break;
					}
					case 3u:
					{
						ushort[] array6 = VertexData[j] as ushort[];
						writer.Write(array6[i * 4]);
						writer.Write(array6[i * 4 + 1]);
						writer.Write(array6[i * 4 + 2]);
						writer.Write(array6[i * 4 + 3]);
						break;
					}
					case 4u:
					{
						float[] array5 = VertexData[j] as float[];
						writer.Write(array5[i]);
						break;
					}
					case 5u:
					{
						float[] array4 = VertexData[j] as float[];
						writer.Write(array4[i * 2]);
						writer.Write(array4[i * 2 + 1]);
						break;
					}
					case 6u:
					{
						float[] array3 = VertexData[j] as float[];
						writer.Write(array3[i * 3]);
						writer.Write(array3[i * 3 + 1]);
						writer.Write(array3[i * 3 + 2]);
						break;
					}
					case 7u:
					{
						float[] array2 = VertexData[j] as float[];
						writer.Write(array2[i * 4]);
						writer.Write(array2[i * 4 + 1]);
						writer.Write(array2[i * 4 + 2]);
						writer.Write(array2[i * 4 + 3]);
						break;
					}
					case 8u:
					case 9u:
					case 10u:
					{
						uint[] array = VertexData[j] as uint[];
						writer.Write(array[i]);
						break;
					}
					default:
						throw new Exception();
					}
				}
			}
		}
	}
}
