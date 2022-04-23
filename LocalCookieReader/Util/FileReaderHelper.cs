using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("LocalCookieReaderTest")]

namespace LocalCookieReader.Util;

internal static class FileReaderHelper
{
    public static string ReadAllText(
        string filePath,
        bool detectEncodingFromByteOrderMarks,
        Encoding? encoding = null)
    {
        using var sw = encoding == null
            ? new StreamReader(filePath, detectEncodingFromByteOrderMarks)
            : new StreamReader(filePath, encoding, detectEncodingFromByteOrderMarks);

        return sw.ReadToEnd();
    }
}