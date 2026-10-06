namespace SunamoDateTime.Converters;

public class ConvertDateTimeToFileNamePostfix
{
    private static char s_delimiter = '_';

    public static string ToConvention(string postfix, DateTime dateTime, bool includeTime)
    {
        return DTHelper.DateTimeToFileName(dateTime, includeTime) + s_delimiter + postfix;
    }

    public static DateTime? FromConvention(string fileNameWithoutExtension, bool includeTime)
    {
        string postfix = "";
        return DTHelper.FileNameToDateTimePostfix(fileNameWithoutExtension, includeTime, out postfix);
    }
}
