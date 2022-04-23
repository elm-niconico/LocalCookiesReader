using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using LocalCookieReader.Util;
using static System.Security.Cryptography.ProtectedData;

[assembly: InternalsVisibleTo(ProjectName.Name)]

namespace LocalCookieReader.Cookie.Chrome.Composite;

[SupportedOSPlatform("windows")]
internal class ChromeCookieComposite : IComposite
{
    public byte[] CompositeEncryptedKey(string key)
    {
        //先頭5byteはプレフィックスのため、不必要
        var decode = Convert.FromBase64String(key)
            .Skip(5)
            .ToArray();

        var unProtect =
            Unprotect(decode, null, DataProtectionScope.CurrentUser);
        return unProtect;
    }
}