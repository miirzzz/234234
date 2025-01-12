using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.VehicleRecords;

public class VehicleRecords : FileBase64_GTA5_pc
{
	public ResourceSimpleList64<VehicleRecordsEntry> Entries;

	public override long Length => 32L;

	public VehicleRecords()
	{
		Entries = new ResourceSimpleList64<VehicleRecordsEntry>();
	}

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Entries = reader.ReadBlock<ResourceSimpleList64<VehicleRecordsEntry>>(Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		writer.WriteBlock(Entries);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[1]
		{
			new Tuple<long, IResourceBlock>(16L, Entries)
		};
	}
}
