using System.Security.Cryptography;
using System.Text;

namespace LocalCookieReader.Util;

internal static class AesHelper
{
    public static string Decrypt(string key, Func<string, byte[]> unprotect, byte[] value)
    {
        return Decrypt(key, DecryptToBytes, unprotect, value);
    }


    public static string Decrypt(
        string key,
        Func<byte[], byte[], byte[]> decryptToBytes,
        Func<string, byte[]> unprotect,
        byte[] value)
    {
        return Encoding.UTF8.GetString(decryptToBytes(unprotect(key), value));
    }

    private static byte[] DecryptToBytes(byte[] keyBytes, byte[] value)
    {
        var cypher = value.Skip(15).SkipLast(16).ToArray();

        var gcm = new AesGcm(keyBytes);
        var plain = new byte[cypher.Length];
        var nonce = value.Skip(3).Take(12).ToArray();
        var tag = value.TakeLast(16).ToArray();
        gcm.Decrypt(nonce, cypher, tag, plain);

        return plain;
    }
}