using System.Runtime.Versioning;

namespace LocalCookieReader.Cookie.Chrome.Windows.Composite;

internal enum CompositeType
{
    DpApi
}

[SupportedOSPlatform("Windows")]
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