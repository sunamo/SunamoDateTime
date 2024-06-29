
namespace SunamoDateTime;
public partial class DTHelperMulti
{
    /// <summary>
    /// 21.6.1989 / 6/21/1989
    /// </summary>
    /// <param name="p"></param>
    public static string DateToString(DateTime p, LangsDt l)
    {
        if (l == LangsDt.cs)
        {
            return p.Day + AllStrings.dot + p.Month + AllStrings.dot + p.Year;
        }
        return p.Month + AllStrings.slash + p.Day + AllStrings.slash + p.Year;
    }
}
