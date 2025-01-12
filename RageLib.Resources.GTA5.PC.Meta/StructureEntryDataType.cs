namespace RageLib.Resources.GTA5.PC.Meta;

public enum StructureEntryDataType : byte
{
	Boolean = 1,
	SignedByte = 16,
	UnsignedByte = 17,
	SignedShort = 18,
	UnsignedShort = 19,
	SignedInt = 20,
	UnsignedInt = 21,
	Float = 33,
	Float_XYZ = 51,
	Float_XYZW = 52,
	ByteEnum = 96,
	IntEnum = 98,
	ShortFlags = 100,
	IntFlags1 = 99,
	IntFlags2 = 101,
	Hash = 74,
	Array = 82,
	ArrayOfChars = 64,
	ArrayOfBytes = 80,
	DataBlockPointer = 89,
	CharPointer = 68,
	StructurePointer = 7,
	Structure = 5
}
