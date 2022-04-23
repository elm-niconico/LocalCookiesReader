using System.Runtime.CompilerServices;
using LocalCookieReader.Cookie.Chrome.Composite;
using LocalCookieReader.Cookie.Chrome.EncryptedKey;
using LocalCookieReader.Cookie.Chrome.Fetcher;
using LocalCookieReader.Util;

[assembly: InternalsVisibleTo(ProjectName.Name)]

namespace LocalCookieReader.Cookie.CookieReader;

internal class ChromeCookiesReader : ICookiesReader
{
    ///
    public async Task<IEnumerable<CookieDataModel>> FetchCookiesAsync(string cookiesUri, string? localStatePath = null)
    {
        string Decrypt(byte[] encryptedValue)
        {
            var key = EncryptedKeyFetcherFactory
                .Fact(FetchEncryptedKeyType.Standard)
                .Fetch(localStatePath);

            return AesHelper.Decrypt(key, CompositeFactory.Fact(CompositeType.DpApi).Composite, encryptedValue);
        }

        return await CookiesFetcherFactory
            .Fact(FetchCookiesType.SqLite3)
            .FetchAsync(cookiesUri, Decrypt);
    }
}