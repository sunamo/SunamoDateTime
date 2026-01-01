namespace SunamoDateTime._sunamo.SunamoData.Data;

/// <summary>
/// Simple date structure with day, month, and year.
/// EN: Lightweight date representation without time component.
/// CZ: Lehká reprezentace data bez časové složky.
/// </summary>
internal class Date
{
    /// <summary>
    /// Gets or sets the day of the month (1-31).
    /// </summary>
    internal int Day { get; set; }

    /// <summary>
    /// Gets or sets the month (1-12).
    /// </summary>
    internal int Month { get; set; }

    /// <summary>
    /// Gets or sets the year.
    /// </summary>
    internal int Year { get; set; }
}