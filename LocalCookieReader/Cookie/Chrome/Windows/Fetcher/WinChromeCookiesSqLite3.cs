using System.Data;
using System.Data.SQLite;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using LocalCookieReader.Cookie.Chrome.Windows.Composite;
using LocalCookieReader.Cookie.Chrome.Windows.EncryptedKey;
using LocalCookieReader.Cookie.CookieReader;
using LocalCookieReader.Util;

namespace LocalCookieReader.Cookie.Chrome.Windows.Fetcher;

[SupportedOSPlatform("Windows")]
// めっちゃ処理ながくなったーー
public class WinChromeCookiesSqLite3 : ICookiesFetcher
{
    public async Task<IEnumerable<CookieDataModel>> FetchAsync(string cookiesUrl)
    {
        var sqlConnectionSb = new SQLiteConnectionStringBuilder
        {
            DataSource = cookiesUrl
        };

        await using var cn = new SQLiteConnection(sqlConnectionSb.ToString());


        await using var cmd = new SQLiteCommand(cn);
        cmd.CommandText = "SELECT * FROM cookies";
        cn.Open();
        await using var reader = cmd.ExecuteReader();

        var list = new List<CookieDataModel>();
        while (await reader.ReadAsync())
            list.Add(new CookieDataModel
            {
                CreationUtc = ToDate(reader, "creation_utc"),
                Name = ToStr(reader, "name"),
                HostKey = ToStr(reader, "host_key"),
                Value = ToStr(reader, "value"),
                Path = ToStr(reader, "path"),
                ExpiresUtc = ToDate(reader, "expires_utc"),
                IsSecure = ToBool(reader, "is_secure"),
                IsHttpOnly = ToBool(reader, "is_httponly"),
                LastAccessUtc = ToDate(reader, "last_access_utc"),
                HasExpires = ToBool(reader, "has_expires"),
                IsPersistent = ToBool(reader, "is_persistent"),
                Priority = ToLong(reader, "priority"),
                EncryptedValue = Decrypt(FetchEncryptedKeyType.Standard, (byte[]) reader["encrypted_value"])
            });

        return list;
    }


    private static string Decrypt(FetchEncryptedKeyType fetchKey, byte[] value)
    {
        var key = EncryptedKeyFetcherFactory
            .Fact(fetchKey)
            .Fetch();

        var keyBytes = CompositeFactory
            .Fact(CompositeType.DpApi)
            .Composite(key);

        return Encoding.UTF8.GetString(DecryptToBytes(keyBytes, value));
    }


    private static byte[] DecryptToBytes(byte[] keyBytes, byte[] value)
    {
        var cypher = value.Skip(15).SkipLast(16).ToArray();

        var gcm = new AesGcm(keyBytes);
        var plain = new byte[cypher.Length];
        var nonce = value.Skip(3).Take(12).ToArray();
        var tag = value.TakeLast(16).ToArray();
        gcm.Decrypt(nonce, cypher, tag, plain);

        return plain;
    }

    private static DateTime ToDate(IDataRecord reader, string name)
    {
        return DateTimeUtil.FromLong(Convert.ToInt64(reader[name]));
    }

    private static long ToLong(IDataRecord reader, string name)
    {
        return Convert.ToInt64(reader[name]);
    }

    private static bool ToBool(IDataRecord reader, string name)
    {
        return Convert.ToBoolean(reader[name]);
    }

    private static string ToStr(IDataRecord reader, string name)
    {
        return Convert.ToString(reader[name])!;
    }
}