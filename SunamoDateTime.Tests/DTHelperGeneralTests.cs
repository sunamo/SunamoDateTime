// variables names: ok
using SunamoDateTime.DT;

namespace SunamoDateTime.Tests;
/// <summary>
/// Tests for DTHelperGeneral week-of-year calculation methods.
/// </summary>
public class DTHelperGeneralTests
{
    /// <summary>
    /// Tests the WeekOfYearFromDate method returns the correct ISO week number.
    /// </summary>
    [Fact]
    public void WeekOfYearFromDateTest()
    {
        var dt = new DateTime(2025, 3, 17);

        Assert.Equal(12, DTHelperGeneral.WeekOfYearFromDate(dt));
    }
}
