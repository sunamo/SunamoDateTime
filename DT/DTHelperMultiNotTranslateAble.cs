
namespace SunamoDateTime;



public partial class DTHelperMulti
{
    public static string FilesFounded(int c, LangsDt l)
    {
        if (l == LangsDt.cs)
        {
            if (c < 2)
            {
                return "soubor nalezen";
            }
            if (c < 5)
            {
                return "soubory nalezeny";
            }
            return "souborů nalezeno";
        }
        return xfilesFounded;
    }

    public static string xfilesFounded = "filesFounded";
}
