using System.Data;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using LocalCookieReader.Cookie.CookieReader;
using LocalCookieReader.Util;

[assembly: InternalsVisibleTo(ProjectName.Name)]

namespace LocalCookieReader.Cookie.Chrome.Fetcher;

// めっちゃ処理ながくなったーー
internal class WinChromeCookiesSqLite3 : ICookiesFetcher
{
    public async Task<IEnumerable<CookieDataModel>> FetchAsync(string cookiesUrl, Func<byte[], string> decrypt)
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
                EncryptedValue = decrypt((byte[]) reader["encrypted_value"])
            });

        return list;
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