using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using LocalCookieReader.Cookie.Chrome.Composite;
using LocalCookieReader.Cookie.Chrome.EncryptedKey;
using LocalCookieReader.Cookie.Chrome.SQL;
using LocalCookieReader.Util;

[assembly: InternalsVisibleTo(ProjectName.Name)]

namespace LocalCookieReader.Cookie.CookieReader;

internal class ChromeCookiesReader : ICookiesReader
{
    public IEnumerable<CookieDataModel> GetCookies(string cookiesPath)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return GetCookiesForWindows(cookiesPath);

        throw new NotImplementedException();
    }

    [SupportedOSPlatform("Windows")]
    private static IEnumerable<CookieDataModel> GetCookiesForWindows(string cookiesPath)
    {
        var cookies = new WinChromeCookiesSql().SelectCookies(cookiesPath);


        return cookies
            .Select(c => new CookieDataModel
            {
                CreationUtc = c.CreationUtc,
                Name = c.Name,
                HostKey = c.HostKey,
                Value = c.Value,
                Path = c.Path,
                IsHttpOnly = c.IsHttpOnly,
                IsSecure = c.IsSecure,
                HasExpires = c.HasExpires,
                LastAccessUtc = c.LastAccessUtc,
                ExpiresUtc = c.ExpiresUtc,
                EncryptedValue = Decrypt(c.EncryptedValue)
            });
    }

    [SupportedOSPlatform("Windows")]
    private static string Decrypt(byte[] value)
    {
        var key = new StandardEncryptedKeyPreference().ExtractEncryptedKey();

        var keyBytes = new ChromeCookieComposite().CompositeEncryptedKey(key);
        var cypher = value.Skip(15).SkipLast(16).ToArray();

        var gcm = new AesGcm(keyBytes);
        var plain = new byte[cypher.Length];
        var nonce = value.Skip(3).Take(12).ToArray();
        var tag = value.TakeLast(16).ToArray();
        gcm.Decrypt(nonce, cypher, tag, plain);

        return Encoding.UTF8.GetString(plain);
    }
}