
using SunamoDateTime._sunamo;

namespace SunamoDateTime.DT;
public partial class DTHelperCode
{
    #region Parse
    #region Date with time (without seconds)
    /// <summary>
    /// Input in format like 2015-09-03T21:01
    /// </summary>
    /// <param name="v"></param>
    /// <param name="dtMinVal"></param>
    public static DateTime StringToDateTimeFromInputDateTimeLocal(string v, DateTime dtMinVal)
    {
        if (!v.Contains(AllStrings.dash))
        {
            return dtMinVal;
        }
        //2015-09-03T21:01
        var sp = v.Split(new Char[] { AllChars.dash, 'T', AllChars.colon }).ToList();
        var dd = CAToNumber.ToInt0(sp);
        return new DateTime(dd[0], dd[1], dd[2], dd[3], dd[4], 0);
    }
    #endregion
    #endregion
}
