using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using LocalCookieReader.Cookie.Chrome.Windows.Fetcher;
using LocalCookieReader.Util;

[assembly: InternalsVisibleTo(ProjectName.Name)]

namespace LocalCookieReader.Cookie.CookieReader;

internal class ChromeCookiesReader : ICookiesReader
{
    public async Task<IEnumerable<CookieDataModel>> FetchCookiesAsync(string cookiesUri)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return await CookiesFetcherFactory
                .Fact(FetchCookiesType.SqLite3)
                .FetchAsync(cookiesUri);

        throw new NotImplementedException();
    }
}