namespace ExtractLocalCookie.Composite;

internal interface IComposite
{
    public byte[] CompositeEncryptedKey(string key);
}