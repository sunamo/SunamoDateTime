using SunamoDateTime.DT;

namespace SunamoDateTime.Tests.DT;
public class DTHelperCsTests
{
    [Fact]
    public void ToTimeAgoTest()
    {
        var dt = DateTime.Now;

        var d = DTHelperCs.ToTimeAgo(DateTime.Now.AddDays(-7));
        var d2 = DTHelperCs.ToTimeAgo(DateTime.Now.AddDays(-6).AddHours(-12));

    }

    [Fact]
    public void CalculateAgeAndAddRightStringTest()
    {
        var d = DTHelperCs.CalculateAgeAndAddRightString(DateTime.Now.AddDays(-7), true);
    }
}
