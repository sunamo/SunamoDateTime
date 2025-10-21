// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoDateTime._public;


public class FromToTSHDt<T>
{

    public bool empty;
    protected long fromL;
    public FromToUseDateTime ftUse = FromToUseDateTime.DateTime;
    protected long toL;
    public FromToTSHDt()
    {
        var type = typeof(type);
        if (type == typeof(int)) ftUse = FromToUseDateTime.None;
    }
    /// <summary>
    ///     Use Empty contstant outside of class
    /// </summary>
    /// <param name="empty"></param>
    private FromToTSHDt(bool empty) : this()
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
    public FromToTSHDt(type from, type to, FromToUseDateTime ftUse = FromToUseDateTime.DateTime) : this()
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }
    public type from
    {
        get => (type)(dynamic)fromL;
        set => fromL = (long)(dynamic)value;
    }
    public type to
    {
        get => (type)(dynamic)toL;
        set => toL = (long)(dynamic)value;
    }
    public long FromL => fromL;
    public long ToL => toL;
}