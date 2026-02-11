namespace SunamoDateTime._public.SunamoEnums.Enums;

/// <summary>
/// Specifies how the FromTo time range values should be interpreted.
/// </summary>
public enum FromToUseDateTime
{
    /// <summary>
    /// Values represent standard DateTime ticks.
    /// </summary>
    DateTime,
    /// <summary>
    /// Values represent Unix timestamps (seconds since epoch).
    /// </summary>
    Unix,
    /// <summary>
    /// Values represent Unix timestamps for time-only comparisons.
    /// </summary>
    UnixJustTime,
    /// <summary>
    /// No specific time interpretation is applied.
    /// </summary>
    None
}