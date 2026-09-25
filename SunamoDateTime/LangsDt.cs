namespace SunamoDateTime;

// Musí být ve SunamoEnums protože je sdílen např. i ve SunamoDateTime
/// <summary>
///     For projects for which is reference whole Xlf useless
///     But it is only one file (like here Langs), consider import it instead create standalone project
///     Tool which will copy it automatilly also could not be bad
///     Langs -> LangsDt protože hodně metod jej zde potřebuje a tím pádem musí být public
/// </summary>
public enum LangsDt
{
    #region For easy copying to other files

    /// <summary>
    /// Czech language.
    /// </summary>
    cs = 0,
    /// <summary>
    /// English language.
    /// </summary>
    en = 1

    #endregion
}