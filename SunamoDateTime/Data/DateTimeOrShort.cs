namespace SunamoDateTime.Data;

/// <summary>
/// Represents the date time or short type.
/// </summary>
public class DateTimeOrShort
{
    /// <summary>
    /// Gets or sets the short value.
    /// </summary>
    public short ShortValue { get; set; }

    /// <summary>
    /// Gets or sets the date time value.
    /// </summary>
    public DateTime DateTimeValue { get; set; }

    private bool useDateTime = false;

    /// <summary>
    /// The value.
    /// </summary>
    public object Value
    {
        get
        {
            if (!useDateTime)
            {
                return ShortValue;
            }
            else
            {
                return DateTimeValue;
            }
        }
    }

    /// <summary>
    /// From short.
    /// </summary>
    /// <param name="dateTIme">The date t ime.</param>
    /// <returns>The from short result.</returns>
    public static DateTimeOrShort FromShort(DateTime dateTIme)
    {
        return FromShort(NormalizeDate.To(dateTIme));
    }

    /// <summary>
    /// From short.
    /// </summary>
    /// <param name="dateTIme">The date t ime.</param>
    /// <returns>The from short result.</returns>
    public static DateTimeOrShort FromShort(short value)
    {
        DateTimeOrShort result = new();
        result.ShortValue = value;
        return result;
    }

    /// <summary>
    /// From date time.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The from date time result.</returns>
    public static DateTimeOrShort FromDateTime(DateTime dateTime)
    {
        DateTimeOrShort result = new();
        result.useDateTime = true;
        result.DateTimeValue = dateTime;
        return result;
    }
}
