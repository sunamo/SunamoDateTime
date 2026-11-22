using SunamoDateTime.DT;

/// <summary>
/// Tests for English/US DateTime parsing methods.
/// </summary>
public class DTHelperEnTests
{
    /// <summary>
    /// Tests parsing a US-formatted date-time string.
    /// </summary>
    [Fact]
    public void ParseDateTimeUSATest()
    {
        var input = "5/19/2021 09:59 AM";
        var actual = DTHelperEn.ParseDateTimeUSA(input);
    }

    /// <summary>
    /// Tests that ParseDateUSAOrMin parses a valid date and returns MinValue for bad input.
    /// </summary>
    [Fact]
    public void ParseDateUSAOrMinTest()
    {
        Assert.Equal(new DateTime(2026, 1, 15), DTHelperEn.ParseDateUSAOrMin("1/15/2026"));
        Assert.Equal(DateTime.MinValue, DTHelperEn.ParseDateUSAOrMin("garbage"));
        Assert.Equal(DateTime.MinValue, DTHelperEn.ParseDateUSAOrMin("13/45/2026"));
        Assert.Equal(DateTime.MinValue, DTHelperEn.ParseDateUSAOrMin(""));
    }}
