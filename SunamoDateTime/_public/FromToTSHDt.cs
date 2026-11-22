namespace SunamoDateTime._public;

/// <summary>
/// Represents the from to TSH dt t type.
/// </summary>
public class FromToTSHDt<T>
{
    /// <summary>
    /// Gets or sets the is empty.
    /// </summary>
    public bool IsEmpty { get; set; }
    /// <summary>
    /// The from long.
    /// </summary>
    protected long fromLong;
    /// <summary>
    /// Gets or sets the use type.
    /// </summary>
    public FromToUseDateTime UseType { get; set; } = FromToUseDateTime.DateTime;
    /// <summary>
    /// The to long.
    /// </summary>
    protected long toLong;

    /// <summary>
    /// Initializes a new instance of the from to TSH dt class.
    /// </summary>
    public FromToTSHDt()
    {
        var type = typeof(T);
        if (type == typeof(int)) UseType = FromToUseDateTime.None;
    }

    private FromToTSHDt(bool isEmpty) : this()
    {
        this.IsEmpty = isEmpty;
    }

    /// <summary>
    /// Initializes a new instance of the from to TSH dt class.
    /// </summary>
    public FromToTSHDt(T from, T to, FromToUseDateTime useType = FromToUseDateTime.DateTime) : this()
    {
        this.From = from;
        this.To = to;
        this.UseType = useType;
    }

    /// <summary>
    /// The from.
    /// </summary>
    public T From
    {
        get => (T)(dynamic)fromLong!;
        set => fromLong = (long)(dynamic)value!;
    }

    /// <summary>
    /// The to.
    /// </summary>
    public T To
    {
        get => (T)(dynamic)toLong!;
        set => toLong = (long)(dynamic)value!;
    }

    /// <summary>
    /// Gets the from l.
    /// </summary>
    public long FromL => fromLong;

    /// <summary>
    /// Gets the to l.
    /// </summary>
    public long ToL => toLong;
}
