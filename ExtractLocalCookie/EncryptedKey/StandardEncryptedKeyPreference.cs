﻿using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using ExtractLocalCookie.EncryptedKey.JsonDataModel;
using ExtractLocalCookie.Exceptions;
using ExtractLocalCookie.Util;

[assembly: InternalsVisibleTo(ProjectName.Name)]

namespace ExtractLocalCookie.EncryptedKey;

internal class StandardEncryptedKeyPreference : IEncryptedKeyPreference
{
    public string ExtractEncryptedKey(string localStatePath)
    {
        var json = FileReaderHelper.ReadAllText(localStatePath, true, Encoding.UTF8);
        var data = JsonSerializer.Deserialize<EncryptedKeyData>(json);
        return data?.OsCrypt?.EncryptedKey ?? throw new FailedExtractEncryptedKeyException("ファイルから複合鍵が見つかりませんでした");
    }

    public string ExtractEncryptedKey()
    {
        return ExtractEncryptedKey(PathHelper.DefaultLocalState);
    }
}