using ExtractLocalCookie.EncryptedKey;
using Xunit;

namespace ExtractLocalCookieTest.EncryptedKey;

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