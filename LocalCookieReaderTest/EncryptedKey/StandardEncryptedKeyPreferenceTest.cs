using LocalCookieReader.Cookie.Chrome.Windows.EncryptedKey;
using Xunit;

namespace LocalCookieReaderTest.EncryptedKey;

public class StandardEncryptedKeyPreferenceTest
{
    [Fact]
    public void ShouldGetEncryptedKey()
    {
        var pre = new StandardEncryptedKeyPreference();
        var key = pre.Fetch();
        Assert.NotNull(key);
    }
}