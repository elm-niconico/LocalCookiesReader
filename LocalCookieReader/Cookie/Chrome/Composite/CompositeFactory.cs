namespace LocalCookieReader.Cookie.Chrome.Composite;

internal enum CompositeType
{
    DpApi
}

internal static class CompositeFactory
{
    public static IComposite Fact(CompositeType type)
    {
        return type switch
        {
            CompositeType.DpApi => new DpapiComposite(),
            _ => throw new NotSupportedException()
        };
    }
}