namespace SunamoDateTime._public;

// Must have both from and to values entered. No event can have unlimited time.
/// <summary>
/// Represents the from to dt type.
/// </summary>
public class FromToDt : FromToTSHDt<long>
{
    /// <summary>
    /// The empty.
    /// </summary>
    public static FromToDt Empty = new(true);

    /// <summary>
    /// From to dt.
    /// </summary>
    /// <param name="true">The true.</param>
    /// <returns>The from to dt result.</returns>
    public FromToDt()
    {
    }

    private FromToDt(bool isEmpty)
    {
        this.IsEmpty = isEmpty;
    }

    /// <summary>
    /// From to dt.
    /// </summary>
    /// <param name="from">The from.</param>
    /// <param name="to">The to.</param>
    /// <param name="useType">The use type.</param>
    /// <returns>The from to dt result.</returns>
    public FromToDt(long from, long to, FromToUseDateTime useType = FromToUseDateTime.DateTime)
    {
        this.From = from;
        this.To = to;
        this.UseType = useType;
    }
}
