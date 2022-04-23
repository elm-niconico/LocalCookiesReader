# LocalCookiesReader

ローカルのCookiesファイルからクッキー情報を取得します。
現状WindowsかつChromeのものしか対応していません。

## 使用例

```c#
var cookiesPath = "";

var reader = CookieReaderFactory.Fact(BrowserType.Chrome);
IEnumerable<CookieDataModel> cookies = reader.GetCookies(cookiesPath);

var cookie = cookies.First();

```

CookieDataModelは次のように宣言されています

```c#
public class CookieDataModel
{
    public DateTime CreationUtc { get; internal set; }
    public string Name { get; internal set; }
    public string HostKey { get; internal set; }
    public string Value { get; internal set; }
    public string Path { get; internal set; }
    public DateTime ExpiresUtc { get; internal set; }
    public bool IsSecure { get; internal set; }
    public bool IsHttpOnly { get; internal set; }
    public DateTime LastAccessUtc { get; internal set; }
    public bool HasExpires { get; internal set; }
    public bool IsPersistent { get; internal set; }
    public long Priority { get; internal set; }
    public string EncryptedValue { get; internal set; }

    public override string ToString()
    {
        return
            $"creation_utc {CreationUtc}\n" +
            $"Name {Name}\n" +
            $"HostKey {HostKey}\n" +
            $"Value {Value}\n" +
            $"Path {Path}\n" +
            $"ExpiresUtc {ExpiresUtc}\n" +
            $"Secure {IsSecure}\n" +
            $"HttpOnly {IsHttpOnly}\n" +
            $"EncryptedValue {EncryptedValue}\n";
    }
}

```