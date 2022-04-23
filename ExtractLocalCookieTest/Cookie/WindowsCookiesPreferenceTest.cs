using Xunit.Abstractions;

namespace ExtractLocalCookieTest.Cookie;

public class WindowsCookiesPreferenceTest
{
    private readonly ITestOutputHelper _out;

    public WindowsCookiesPreferenceTest(ITestOutputHelper oute)
    {
        _out = oute;
    }

    // [Fact]
    // public void ShouldGetCookiesValue()
    // {
    //     var cookie = new ChromeCookiesReader().GetCookies("");
    //     _out.WriteLine(cookie);
    // }
}