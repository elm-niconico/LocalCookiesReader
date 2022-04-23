using LocalCookieReader.Cookie.Chrome.EncryptedKey;
using Xunit;

namespace LocalCookieReaderTest.EncryptedKey;

public class StandardEncryptedKeyPreferenceTest
{
    [Fact]
    public void ShouldGetEncryptedKey()
    {
        var pre = new StandardEncryptedKeyPreference();
        var key = pre.ExtractEncryptedKey();
        Assert.NotNull(key);
    }
}