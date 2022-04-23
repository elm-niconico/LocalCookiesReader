namespace ExtractLocalCookie.Util;

internal static class DateTimeUtil
{
    public static DateTime FromLong(long unixDate)
    {
        var dtDateTime = new DateTime(1601, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        return dtDateTime.AddSeconds(unixDate / 1000000).ToLocalTime();
    }
}