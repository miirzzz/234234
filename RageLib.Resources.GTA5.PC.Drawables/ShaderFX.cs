using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Drawables;

public class ShaderFX : ResourceSystemBlock
{
	public ulong ParametersPointer;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public byte ParameterCount;

	public byte Unknown_11h;

	public ushort Unknown_12h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public uint Unknown_20h;

	public ushort Unknown_24h;

	public byte Unknown_26h;

	public byte TextureParametersCount;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public ShaderParametersBlock_GTA5_pc ParametersList;

	public override long Length => 48L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		ParametersPointer = reader.ReadUInt64();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		ParameterCount = reader.ReadByte();
		Unknown_11h = reader.ReadByte();
		Unknown_12h = reader.ReadUInt16();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt16();
		Unknown_26h = reader.ReadByte();
		TextureParametersCount = reader.ReadByte();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		ParametersList = reader.ReadBlockAt<ShaderParametersBlock_GTA5_pc>(ParametersPointer, new object[1] { ParameterCount });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		ParametersPointer = (ulong)((ParametersList != null) ? ParametersList.Position : 0);
		writer.Write(ParametersPointer);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(ParameterCount);
		writer.Write(Unknown_11h);
		writer.Write(Unknown_12h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_26h);
		writer.Write(TextureParametersCount);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (ParametersList != null)
		{
			list.Add(ParametersList);
		}
		return list.ToArray();
	}
}
