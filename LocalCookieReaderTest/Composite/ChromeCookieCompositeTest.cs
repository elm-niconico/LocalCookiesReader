using System.Runtime.Versioning;
using LocalCookieReader.Cookie.Chrome.Windows.EncryptedKey;
using Xunit.Abstractions;

namespace LocalCookieReaderTest.Composite;

[SupportedOSPlatform("windows")]
public class ChromeCookieCompositeTest
{
    private readonly ITestOutputHelper _out;
    private readonly string key = new StandardEncryptedKeyPreference().Fetch();

    public ChromeCookieCompositeTest(ITestOutputHelper testOutputHelper)
    {
        _out = testOutputHelper;
    }
}