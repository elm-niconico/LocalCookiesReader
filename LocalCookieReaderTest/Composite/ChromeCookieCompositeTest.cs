using System.Runtime.Versioning;
using LocalCookieReader.Cookie.Chrome.EncryptedKey;
using Xunit.Abstractions;

namespace LocalCookieReaderTest.Composite;

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