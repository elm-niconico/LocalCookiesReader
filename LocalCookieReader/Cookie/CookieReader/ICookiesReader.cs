﻿namespace LocalCookieReader.Cookie.CookieReader;

public interface ICookiesReader
{
    public Task<IEnumerable<CookieDataModel>> FetchCookiesAsync(string cookiesUri);
}

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