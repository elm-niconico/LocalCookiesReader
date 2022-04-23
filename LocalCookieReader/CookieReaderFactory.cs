using LocalCookieReader.Cookie.CookieReader;

namespace LocalCookieReader;

public enum BrowserType
{
    Chrome
}

public static class CookieReaderFactory
{
    public static ICookiesReader Fact(BrowserType browser)
    {
        return browser switch
        {
            BrowserType.Chrome => new ChromeCookiesReader(),
            _ => throw new NotSupportedException()
        };
    }
}