// variables names: ok
namespace sunamo.Tests.Helpers.DT;

using SunamoDateTime.DT;

/// <summary>
/// Tests for formalized date parsing and validation methods.
/// </summary>
public class DTHelperFormalizedTests
{
    /// <summary>
    /// Tests whether an ISO-formatted date string is recognized as a valid formalized date.
    /// </summary>
    [Fact]
    public void IsFormalizedDateTest()
    {
        bool b = DTHelperFormalized.IsFormalizedDate("2022-09-26T11:57:57.8410000Z");
    }
}
