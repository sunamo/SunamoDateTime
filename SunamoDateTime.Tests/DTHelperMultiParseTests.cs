using SunamoDateTime.DT;

namespace SunamoDateTime.Tests;

/// <summary>
/// Tests for parsing a date with an optional day range and for DTHelperGeneral.Create.
/// </summary>
public class DTHelperMultiParseTests
{
    /// <summary>
    /// Tests that the end of a day range such as 3-5 is returned in dayTo.
    /// </summary>
    [Fact]
    public void ParseDateMonthDayYearRangeTest()
    {
        var date = DTHelperMulti.ParseDateMonthDayYear("6/3-5/2026", out var dayTo);
        Assert.Equal(new DateTime(2026, 6, 3), date);
        Assert.Equal(5, dayTo);
    }

    /// <summary>
    /// Tests that a day outside the month gives null instead of an exception.
    /// </summary>
    [Fact]
    public void CreateInvalidDayReturnsNullTest()
    {
        Assert.Null(DTHelperGeneral.Create(2026, 2, 31));
        Assert.Equal(new DateTime(2026, 2, 28), DTHelperGeneral.Create(2026, 2, 28));
    }
}
