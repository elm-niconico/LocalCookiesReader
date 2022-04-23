namespace LocalCookieReader.Util;

internal static class PathHelper
{
    public static string LocalAppPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

    public static string DefaultLocalState => Path.Combine(
        LocalAppPath,
        @"Google\Chrome\User Data\Local State");
}