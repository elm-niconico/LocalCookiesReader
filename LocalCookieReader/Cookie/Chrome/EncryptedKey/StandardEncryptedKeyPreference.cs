using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using LocalCookieReader.Cookie.Chrome.EncryptedKey.JsonDataModel;
using LocalCookieReader.Exceptions;
using LocalCookieReader.Util;

[assembly: InternalsVisibleTo(ProjectName.Name)]

namespace LocalCookieReader.Cookie.Chrome.EncryptedKey;

internal class StandardEncryptedKeyPreference : IEncryptedKeyPreference
{
    public string Fetch(string? localStatePath = null)
    {
        var path = localStatePath ?? PathHelper.DefaultLocalState;
        var json = FileReaderHelper.ReadAllText(path, true, Encoding.UTF8);
        var data = JsonSerializer.Deserialize<EncryptedKeyData>(json);
        return data?.OsCrypt?.EncryptedKey ?? throw new FailedExtractEncryptedKeyException("ファイルから複合鍵が見つかりませんでした");
    }
}