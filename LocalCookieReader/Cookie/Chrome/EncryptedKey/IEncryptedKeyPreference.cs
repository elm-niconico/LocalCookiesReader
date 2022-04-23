using LocalCookieReader.Exceptions;

namespace LocalCookieReader.Cookie.Chrome.EncryptedKey;

/// <summary>
///     Windows版ChromeのCookiesファイルを複合するための鍵を取得します
/// </summary>
public interface IEncryptedKeyPreference
{
    /// <summary>
    ///     指定したファイルパスからWindows版ChromeのCookiesファイルを複合するための鍵を取得します
    ///     null または引数を指定しない場合はデフォルトで保存されるパスから取得します
    /// </summary>
    /// <param name="localStatePath">暗号化された鍵が格納されたファイルの絶対パス</param>
    /// <returns>暗号化された鍵</returns>
    /// <exception cref="FailedExtractEncryptedKeyException">キーの取得に失敗した場合</exception>
    public string Fetch(string? localStatePath = null);
}