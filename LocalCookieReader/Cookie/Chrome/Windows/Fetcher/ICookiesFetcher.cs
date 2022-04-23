using LocalCookieReader.Cookie.CookieReader;

namespace LocalCookieReader.Cookie.Chrome.Windows.Fetcher;

internal interface ICookiesFetcher
{
    public Task<IEnumerable<CookieDataModel>> FetchAsync(string cookiesUrl);
}