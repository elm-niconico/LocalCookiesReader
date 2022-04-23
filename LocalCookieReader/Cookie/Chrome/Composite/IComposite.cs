namespace LocalCookieReader.Cookie.Chrome.Composite;

internal interface IComposite
{
    public byte[] CompositeEncryptedKey(string key);
}