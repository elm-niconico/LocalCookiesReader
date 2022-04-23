namespace LocalCookieReader.Cookie.Chrome.Windows.EncryptedKey;

internal enum FetchEncryptedKeyType
{
    Standard
}

internal static class EncryptedKeyFetcherFactory
{
    public static IEncryptedKeyPreference Fact(FetchEncryptedKeyType type)
    {
        return type switch
        {
            FetchEncryptedKeyType.Standard => new StandardEncryptedKeyPreference(),
            _ => throw new NotSupportedException()
        };
    }
}