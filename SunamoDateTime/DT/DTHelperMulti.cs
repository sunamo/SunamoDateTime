namespace SunamoDateTime.DT;

/// <summary>
/// Represents the DT helper multi type.
/// </summary>
public partial class DTHelperMulti
{
    /// <summary>
    /// The last date time.
    /// </summary>
    public System.DateTime lastDateTime = System.DateTime.Today;

    /// <summary>
    /// Try parse date time.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <returns>The try parse date time result.</returns>
    public bool TryParseDateTime(string r)
    {
        bool isValid = false;
        lastDateTime = DTHelper.IsValidDateTimeText(r);
        isValid = lastDateTime != System.DateTime.MinValue;
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
