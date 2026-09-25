namespace SunamoDateTime.ConvertersSimple;

/// <summary>
/// Converts DateTime values to number-only string representations without separators.
/// </summary>
public class DTOnlyNumber
{
    /// <summary>
    /// Converts DateTime to string with only numbers in format YYMMDD
    /// </summary>
    /// <param name="dateTime">The DateTime to convert</param>
    /// <returns>String with short year, month and day as YYMMDD</returns>
    public static string To(DateTime dateTime)
    {
        var result = DTHelperGeneral.ShortYear(dateTime.Year) + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2");
        return result;
    }
}