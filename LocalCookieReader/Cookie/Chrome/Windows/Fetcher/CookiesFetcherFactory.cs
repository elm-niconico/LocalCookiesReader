using System.Runtime.Versioning;

namespace LocalCookieReader.Cookie.Chrome.Windows.Fetcher;

public enum FetchCookiesType
{
    SqLite3
}

[SupportedOSPlatform("Windows")]
internal static class CookiesFetcherFactory
{
    public static ICookiesFetcher Fact(FetchCookiesType type)
    {
        return type switch
        {
            FetchCookiesType.SqLite3 => new WinChromeCookiesSqLite3(),
            _ => throw new NotSupportedException()
        };
    }
}