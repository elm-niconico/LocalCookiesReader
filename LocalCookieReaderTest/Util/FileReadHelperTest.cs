using System.Text;
using LocalCookieReader.Util;
using Xunit;

namespace LocalCookieReaderTest.Util;

public class FileReadHelperTest
{
    [Fact]
    public void ShouldGetJsonText()
    {
        var json = FileReaderHelper.ReadAllText("test.json", true, Encoding.UTF8);

        Assert.Equal(@"{""test"":""test""}", json);
    }
}