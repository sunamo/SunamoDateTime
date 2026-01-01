namespace SunamoDateTime._public;

/// <summary>
/// Represents a time range with From and To values of type T.
/// EN: Generic base class for time range with configurable usage type.
/// CZ: Generická bázová třída pro časový rozsah s konfigurovatelným typem použití.
/// </summary>
/// <typeparam name="T">The type of the From and To values (typically long for Unix timestamps or int for other purposes)</typeparam>
public class FromToTSHDt<T>
{
    public bool IsEmpty { get; set; }
    protected long fromLong;
    public FromToUseDateTime UseType { get; set; } = FromToUseDateTime.DateTime;
    protected long toLong;

    /// <summary>
    /// Initializes a new instance of the FromToTSHDt class.
    /// EN: Sets default UseType based on generic type T.
    /// CZ: Nastaví výchozí UseType podle generického typu T.
    /// </summary>
    public FromToTSHDt()
    {
        var type = typeof(T);
        if (type == typeof(int)) UseType = FromToUseDateTime.None;
    }

    /// <summary>
    /// Initializes an empty time range.
    /// EN: Use Empty constant outside of class instead of calling this constructor.
    /// CZ: Použijte konstantu Empty mimo třídu místo volání tohoto konstruktoru.
    /// </summary>
    /// <param name="isEmpty">True to create an empty time range</param>
    private FromToTSHDt(bool isEmpty) : this()
    {
        this.IsEmpty = isEmpty;
    }

    /// <summary>
    /// Initializes a time range with specified From and To values.
    /// EN: Creates a time range with the given start and end values.
    /// CZ: Vytvoří časový rozsah se zadanými počáteční a koncovou hodnotou.
    /// </summary>
    /// <param name="from">The start value of the time range</param>
    /// <param name="to">The end value of the time range</param>
    /// <param name="useType">The type of time range usage (DateTime, Unix, etc.)</param>
    public FromToTSHDt(T from, T to, FromToUseDateTime useType = FromToUseDateTime.DateTime) : this()
    {
        this.From = from;
        this.To = to;
        this.UseType = useType;
    }

    /// <summary>
    /// Gets or sets the start value of the time range.
    /// EN: Start value converted from/to long backing field.
    /// CZ: Počáteční hodnota konvertovaná z/na long backing field.
    /// </summary>
    public T From
    {
        get => (T)(dynamic)fromLong;
        set => fromLong = (long)(dynamic)value;
    }

    /// <summary>
    /// Gets or sets the end value of the time range.
    /// EN: End value converted from/to long backing field.
    /// CZ: Koncová hodnota konvertovaná z/na long backing field.
    /// </summary>
    public T To
    {
        get => (T)(dynamic)toLong;
        set => toLong = (long)(dynamic)value;
    }

    /// <summary>
    /// Gets the start value as long.
    /// EN: Returns the backing field value directly.
    /// CZ: Vrací hodnotu backing fieldu přímo.
    /// </summary>
    public long FromL => fromLong;

    /// <summary>
    /// Gets the end value as long.
    /// EN: Returns the backing field value directly.
    /// CZ: Vrací hodnotu backing fieldu přímo.
    /// </summary>
    public long ToL => toLong;
}