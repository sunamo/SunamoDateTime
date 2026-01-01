namespace SunamoDateTime._sunamo.SunamoExtensions;

/// <summary>
/// TimeSpan extension methods for date calculations.
/// EN: Provides additional TimeSpan conversions to years and months.
/// CZ: Poskytuje další TimeSpan konverze na roky a měsíce.
/// </summary>
internal static class TimeSpanExtensions
{
    #region For easy copy from TimeSpanExtensionsSunamo.cs
    /// <summary>
    /// Calculates total years from TimeSpan.
    /// EN: Uses average year length of 365.2425 days (accounting for leap years).
    /// CZ: Používá průměrnou délku roku 365.2425 dní (zahrnuje přestupné roky).
    /// </summary>
    /// <param name="timespan">The TimeSpan to convert</param>
    /// <returns>Total years as integer</returns>
    internal static int TotalYears(this TimeSpan timespan)
    {
        return (int)(timespan.Days / 365.2425);
    }

    /// <summary>
    /// Calculates total months from TimeSpan.
    /// EN: Uses average month length of 30.436875 days (365.2425/12).
    /// CZ: Používá průměrnou délku měsíce 30.436875 dní (365.2425/12).
    /// </summary>
    /// <param name="timespan">The TimeSpan to convert</param>
    /// <returns>Total months as integer</returns>
    internal static int TotalMonths(this TimeSpan timespan)
    {
        return (int)(timespan.Days / 30.436875);
    }
    #endregion
}