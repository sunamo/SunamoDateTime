// variables names: ok
// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

using SunamoDateTime.DT;

namespace SunamoDateTime.Tests.DT;
/// <summary>
/// Tests for Czech-localized DateTime helper methods.
/// </summary>
public class DTHelperCsTests
{
    /// <summary>
    /// Tests the ToTimeAgo method with various date offsets.
    /// </summary>
    [Fact]
    public void ToTimeAgoTest()
    {
        var dt = DateTime.Now;

        var data = DTHelperCs.ToTimeAgo(DateTime.Now.AddDays(-7));
        var d2 = DTHelperCs.ToTimeAgo(DateTime.Now.AddDays(-6).AddHours(-12));

    }

    /// <summary>
    /// Tests the CalculateAgeAndAddRightString method with a date 7 days in the past.
    /// </summary>
    [Fact]
    public void CalculateAgeAndAddRightStringTest()
    {
        var data = DTHelperCs.CalculateAgeAndAddRightString(DateTime.Now.AddDays(-7), true);
    }
}
