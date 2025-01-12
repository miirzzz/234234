namespace RageLib.Cryptography;

public interface IEncryptionAlgorithm
{
	byte[] Encrypt(byte[] data);

	byte[] Decrypt(byte[] data);
}
