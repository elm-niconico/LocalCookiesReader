using System.Text;
using ExtractLocalCookie.Util;
using Xunit;

namespace ExtractLocalCookieTest.Util;

public class FileReadHelperTest
{
    [Fact]
    public void ShouldGetJsonText()
    {
        var json = FileReaderHelper.ReadAllText("test.json", true, Encoding.UTF8);

        Assert.Equal(@"{""test"":""test""}", json);
    }
}