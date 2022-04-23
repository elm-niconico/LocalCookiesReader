using System.Data;
using System.Data.SQLite;
using LocalCookieReader.Cookie.Chrome.SQL.Table;
using LocalCookieReader.Util;

namespace LocalCookieReader.Cookie.Chrome.SQL;

public class WinChromeCookiesSql
{
    public IEnumerable<CookieTable> SelectCookies(string cookiesPath)
    {
        var sqlConnectionSb = new SQLiteConnectionStringBuilder
        {
            DataSource = cookiesPath
        };

        using var cn = new SQLiteConnection(sqlConnectionSb.ToString());


        using var cmd = new SQLiteCommand(cn);
        cmd.CommandText = "SELECT * FROM cookies";
        cn.Open();
        using var reader = cmd.ExecuteReader();

        var list = new List<CookieTable>();
        while (reader.Read())
            list.Add(new CookieTable
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
                EncryptedValue = (byte[]) reader["encrypted_value"]
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