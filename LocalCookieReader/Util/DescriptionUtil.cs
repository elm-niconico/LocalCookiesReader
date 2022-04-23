using System.ComponentModel;

namespace LocalCookieReader.Util;

internal static class DescriptionUtil
{
    public static string? GetDescription(Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());

        if (fieldInfo == null) return null;

        var attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

        var descAttr = (DescriptionAttribute) attr!;
        return descAttr?.Description;
    }
}