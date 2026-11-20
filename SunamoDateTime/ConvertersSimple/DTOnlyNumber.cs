namespace SunamoDateTime.ConvertersSimple;

/// <summary>
/// Represents the DT only number type.
/// </summary>
public class DTOnlyNumber
{
    /// <summary>
    /// To.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The to result.</returns>
    public static string To(DateTime dateTime)
    {
        var result = DTHelperGeneral.ShortYear(dateTime.Year) + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2");
        return result;
    }
}
