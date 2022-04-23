using System.Text.Json.Serialization;

namespace ExtractLocalCookie.EncryptedKey.JsonDataModel;

[Serializable]
internal class EncryptedKeyData
{
    [JsonPropertyName("os_crypt")] public OsCrypt? OsCrypt { get; set; }
}

public class OsCrypt
{
    [JsonPropertyName("encrypted_key")] public string? EncryptedKey { get; set; }
}