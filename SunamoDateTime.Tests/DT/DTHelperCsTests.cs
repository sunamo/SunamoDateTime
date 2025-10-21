// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

using SunamoDateTime.DT;

namespace SunamoDateTime.Tests.DT;
public class DTHelperCsTests
{
    [Fact]
    public void ToTimeAgoTest()
    {
        var dt = DateTime.Now;

        var data = DTHelperCs.ToTimeAgo(DateTime.Now.AddDays(-7));
        var d2 = DTHelperCs.ToTimeAgo(DateTime.Now.AddDays(-6).AddHours(-12));

    }

    [Fact]
    public void CalculateAgeAndAddRightStringTest()
    {
        var data = DTHelperCs.CalculateAgeAndAddRightString(DateTime.Now.AddDays(-7), true);
    }
}
