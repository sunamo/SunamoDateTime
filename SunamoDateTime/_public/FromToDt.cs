namespace SunamoDateTime._public;

/// <summary>
/// Represents a time range with long values (typically Unix timestamps).
/// EN: Must have both from and to values entered. No event can have unlimited time.
/// CZ: Musí mít zadané obě hodnoty from a to. Žádná událost nemůže mít neomezený čas.
/// </summary>
public class FromToDt : FromToTSHDt<long>
{
    /// <summary>
    /// Represents an empty time range.
    /// EN: Static constant for empty time range.
    /// CZ: Statická konstanta pro prázdný časový rozsah.
    /// </summary>
    public static FromToDt Empty = new(true);

    /// <summary>
    /// Initializes a new empty instance of the FromToDt class.
    /// EN: Default constructor creates empty time range.
    /// CZ: Výchozí konstruktor vytvoří prázdný časový rozsah.
    /// </summary>
    public FromToDt()
    {
    }

    /// <summary>
    /// Initializes an empty time range.
    /// EN: Use Empty constant outside of class instead of calling this constructor.
    /// CZ: Použijte konstantu Empty mimo třídu místo volání tohoto konstruktoru.
    /// </summary>
    /// <param name="isEmpty">True to create an empty time range</param>
    private FromToDt(bool isEmpty)
    {
        this.IsEmpty = isEmpty;
    }

    /// <summary>
    /// Initializes a time range with specified From and To values.
    /// EN: Creates a time range with the given start and end Unix timestamp values.
    /// CZ: Vytvoří časový rozsah se zadanými počáteční a koncovou hodnotou Unix timestampu.
    /// </summary>
    /// <param name="from">The start Unix timestamp of the time range</param>
    /// <param name="to">The end Unix timestamp of the time range</param>
    /// <param name="useType">The type of time range usage (DateTime, Unix, etc.)</param>
    public FromToDt(long from, long to, FromToUseDateTime useType = FromToUseDateTime.DateTime)
    {
        this.From = from;
        this.To = to;
        this.UseType = useType;
    }
}