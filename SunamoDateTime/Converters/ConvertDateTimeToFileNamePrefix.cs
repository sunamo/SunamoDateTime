namespace SunamoDateTime.Converters;

public class ConvertDateTimeToFileNamePrefix
{
    private static char s_delimiter = '_';

    public static string ToConvention(string prefix, DateTime dateTime, bool includeTime)
    {
        return prefix + s_delimiter + DTHelper.DateTimeToFileName(dateTime, includeTime);
    }

    public static DateTime? FromConvention(string fileNameWithoutExtension, bool includeTime)
    {
        string prefix = "";
        return DTHelper.FileNameToDateTimePrefix(fileNameWithoutExtension, includeTime, out prefix);
    }
}
