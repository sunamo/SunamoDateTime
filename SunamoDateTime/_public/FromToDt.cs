namespace SunamoDateTime._public;

/// <summary>
///     Must have always entered both from and to
///     None of event could have unlimited time!
/// </summary>
public class FromToDt : FromToTSHDt<long>
{
    public static FromToDt Empty = new(true);
    public FromToDt()
    {
    }
    /// <summary>
    ///     Use Empty contstant outside of class
    /// </summary>
    /// <param name="empty"></param>
    private FromToDt(bool empty)
    {
        this.empty = empty;
    }
    /// <summary>
    ///     A3 true = DateTime
    ///     A3 False = None
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="ftUse"></param>
    public FromToDt(long from, long to, FromToUseDateTime ftUse = FromToUseDateTime.DateTime)
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }
}