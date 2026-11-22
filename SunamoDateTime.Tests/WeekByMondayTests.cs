using SunamoDateTime.DT;

namespace SunamoDateTime.Tests;

/// <summary>
/// Tests for the Monday based week helpers of DTHelperGeneral.
/// </summary>
public class WeekByMondayTests
{
    /// <summary>
    /// Tests that the last days of December 2025 belong to week 53.
    /// </summary>
    [Fact]
    public void WeekOfYearByMonday_EndOfYear()
    {
        Assert.Equal(53, DTHelperGeneral.WeekOfYearByMonday(new DateTime(2025, 12, 31)));
    }

    /// <summary>
    /// Tests that the Monday returned for the week of a date is the Monday of that date.
    /// </summary>
    [Fact]
    public void GetFirstDayOfWeekByMonday_RoundTrip()
    {
        var date = new DateTime(2026, 6, 17);
        var monday = DTHelperGeneral.GetFirstDayOfWeekByMonday(2026, DTHelperGeneral.WeekOfYearByMonday(date));
        Assert.Equal(new DateTime(2026, 6, 15), monday);
    }

    /// <summary>
    /// Tests that a week number outside the year is refused.
    /// </summary>
    [Fact]
    public void GetFirstDayOfWeekByMonday_OutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => DTHelperGeneral.GetFirstDayOfWeekByMonday(2026, 60));
    }
}
