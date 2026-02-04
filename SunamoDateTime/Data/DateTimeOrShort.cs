namespace SunamoDateTime.Data;

/// <summary>
/// Represents a value that can be either a short or a DateTime.
/// EN: Union type for storing either short or DateTime values.
/// CZ: Union typ pro ukládání buď short nebo DateTime hodnot.
/// </summary>
public class DateTimeOrShort
{
    /// <summary>
    /// Gets or sets the short value when UseDateTime is false.
    /// EN: Stores the short representation of the value.
    /// CZ: Ukládá short reprezentaci hodnoty.
    /// </summary>
    public short ShortValue { get; set; }

    /// <summary>
    /// Gets or sets the DateTime value when UseDateTime is true.
    /// EN: Stores the DateTime representation of the value.
    /// CZ: Ukládá DateTime reprezentaci hodnoty.
    /// </summary>
    public DateTime DateTimeValue { get; set; }

    private bool useDateTime = false;

    /// <summary>
    /// Gets the value as either short or DateTime based on the current mode.
    /// EN: Returns ShortValue if UseDateTime is false, otherwise returns DateTimeValue.
    /// CZ: Vrací ShortValue pokud je UseDateTime false, jinak vrací DateTimeValue.
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
    /// Creates a DateTimeOrShort from a DateTime value by converting it to short.
    /// EN: Converts DateTime to short using NormalizeDate.To.
    /// CZ: Převede DateTime na short pomocí NormalizeDate.To.
    /// </summary>
    /// <param name="dateTIme">The DateTime value to convert</param>
    /// <returns>DateTimeOrShort instance with short value</returns>
    public static DateTimeOrShort FromShort(DateTime dateTIme)
    {
        return FromShort(NormalizeDate.To(dateTIme));
    }

    /// <summary>
    /// Creates a DateTimeOrShort from a short value.
    /// EN: Initializes with short value mode.
    /// CZ: Inicializuje v režimu short hodnoty.
    /// </summary>
    /// <param name="value">The short value</param>
    /// <returns>DateTimeOrShort instance with short value</returns>
    public static DateTimeOrShort FromShort(short value)
    {
        DateTimeOrShort result = new DateTimeOrShort();
        result.ShortValue = value;
        return result;
    }

    /// <summary>
    /// Creates a DateTimeOrShort from a DateTime value.
    /// EN: Initializes with DateTime value mode.
    /// CZ: Inicializuje v režimu DateTime hodnoty.
    /// </summary>
    /// <param name="dateTime">The DateTime value</param>
    /// <returns>DateTimeOrShort instance with DateTime value</returns>
    public static DateTimeOrShort FromDateTime(DateTime dateTime)
    {
        DateTimeOrShort result = new DateTimeOrShort();
        result.useDateTime = true;
        result.DateTimeValue = dateTime;
        return result;
    }
}