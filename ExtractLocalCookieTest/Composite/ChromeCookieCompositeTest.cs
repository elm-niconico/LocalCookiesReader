using System;
using System.Runtime.Versioning;
using ExtractLocalCookie.Composite;
using ExtractLocalCookie.EncryptedKey;
using Xunit;
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

    [Fact]
    public void ShouldLength32()
    {
        var unProtect = new ChromeCookieComposite().CompositeEncryptedKey(key);


        Assert.Equal(32, Buffer.ByteLength(unProtect));
    }
}