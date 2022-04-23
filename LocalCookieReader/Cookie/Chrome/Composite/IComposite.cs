namespace LocalCookieReader.Cookie.Chrome.Composite;

internal interface IComposite
{
    public byte[] Composite(string key);
}