// variables names: ok
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
}
