using SunamoDateTime.DT;

namespace SunamoDateTime.Tests;
public class DTHelperGeneralTests
{
    [Fact]
    public void WeekOfYearFromDateTest()
    {
        var dt = new DateTime(2025, 3, 17);

        Assert.Equal(12, DTHelperGeneral.WeekOfYearFromDate(dt));
    }
}
