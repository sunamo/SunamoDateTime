namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
/// <summary>
/// Provides multi-language DateTime formatting, parsing and utility methods supporting both Czech and English locales.
/// </summary>
public partial class DTHelperMulti
{
    /// <summary>
    /// Stores the last successfully parsed DateTime value from TryParseDateTime.
    /// </summary>
    public System.DateTime lastDateTime = System.DateTime.Today;
    /// <summary>
    /// Tries to parse a date-time, date, or time text. Result is stored in lastDateTime property.
    /// </summary>
    /// <param name="r">The text to parse as date-time, date, or time</param>
    /// <returns>True if parsing succeeds, false otherwise</returns>
    public bool TryParseDateTime(string r)
    {
        bool isValid = false;
        lastDateTime = DTHelper.IsValidDateTimeText(r);
        isValid = lastDateTime != System.DateTime.MinValue;
        //}
        if (!isValid)
        {
            lastDateTime = DTHelper.IsValidDateText(r);
            isValid = lastDateTime != System.DateTime.MinValue;
        }

        if (!isValid)
        {
            lastDateTime = DTHelper.IsValidTimeText(r);
            isValid = lastDateTime != System.DateTime.MinValue;
        }

        return lastDateTime != System.DateTime.MinValue;
    }
}