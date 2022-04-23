using System.Runtime.Versioning;
using ExtractLocalCookie.EncryptedKey;
using Xunit.Abstractions;

namespace ExtractLocalCookieTest.Composite;

[SupportedOSPlatform("windows")]
public class ChromeCookieCompositeTest
{
    private readonly ITestOutputHelper _out;
    private readonly string key = new StandardEncryptedKeyPreference().ExtractEncryptedKey();

    public ChromeCookieCompositeTest(ITestOutputHelper testOutputHelper)
    {
        _out = testOutputHelper;
    }
}