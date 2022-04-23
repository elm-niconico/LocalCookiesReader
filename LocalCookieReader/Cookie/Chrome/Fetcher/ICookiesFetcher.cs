using LocalCookieReader.Cookie.CookieReader;

namespace LocalCookieReader.Cookie.Chrome.Fetcher;

internal interface ICookiesFetcher
{
    public Task<IEnumerable<CookieDataModel>> FetchAsync(string cookiesUrl, Func<byte[], string> decrypt);
}