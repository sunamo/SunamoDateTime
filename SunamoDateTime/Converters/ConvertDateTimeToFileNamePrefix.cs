namespace SunamoDateTime.Converters;

/// <summary>
/// Represents the convert date time to file name prefix type.
/// </summary>
public class ConvertDateTimeToFileNamePrefix
{
    private static char s_delimiter = '_';

    /// <summary>
    /// To convention.
    /// </summary>
    /// <param name="prefix">The prefix.</param>
    /// <param name="dateTime">The date time.</param>
    /// <param name="includeTime">The include time.</param>
    /// <returns>The to convention result.</returns>
    public static string ToConvention(string prefix, DateTime dateTime, bool includeTime)
    {
        return prefix + s_delimiter + DTHelper.DateTimeToFileName(dateTime, includeTime);
    }

    /// <summary>
    /// From convention.
    /// </summary>
    /// <param name="fileNameWithoutExtension">The file name without extension.</param>
    /// <param name="includeTime">The include time.</param>
    /// <returns>The from convention result.</returns>
    public static DateTime? FromConvention(string fileNameWithoutExtension, bool includeTime)
    {
        string prefix = "";
        return DTHelper.FileNameToDateTimePrefix(fileNameWithoutExtension, includeTime, out prefix);
    }
}
