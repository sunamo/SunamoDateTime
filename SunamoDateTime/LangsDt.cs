namespace SunamoDateTime;

// Must be in SunamoEnums because it is shared e.g. in SunamoDateTime too
// For projects for which is reference whole Xlf useless
// But it is only one file (like here Langs), consider import it instead create standalone project
// Tool which will copy it automatilly also could not be bad
// Langs -> LangsDt because many methods need it here and therefore it must be public
public enum LangsDt
{
    #region For easy copying to other files

    cs = 0,
    en = 1

    #endregion
}
