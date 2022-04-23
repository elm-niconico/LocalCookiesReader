using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using LocalCookieReader.Util;
using static System.Security.Cryptography.ProtectedData;

[assembly: InternalsVisibleTo(ProjectName.Name)]

namespace LocalCookieReader.Cookie.Chrome.Composite;

internal class DpapiComposite : IComposite
{
    public byte[] Composite(string key)
    {
        //先頭5byteはプレフィックスのため、不必要
        var decode = Convert
            .FromBase64String(key)
            .Skip(5)
            .ToArray();

        return Unprotect(decode, null, DataProtectionScope.CurrentUser);
    }
}