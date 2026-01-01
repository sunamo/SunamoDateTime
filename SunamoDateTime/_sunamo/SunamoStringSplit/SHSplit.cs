namespace SunamoDateTime._sunamo.SunamoStringSplit;

/// <summary>
/// String Helper Split utilities.
/// EN: Provides advanced string splitting operations.
/// CZ: Poskytuje pokročilé operace pro rozdělení řetězců.
/// </summary>
internal class SHSplit
{
    /// <summary>
    /// Splits text by delimiters without removing empty entries.
    /// EN: Returns all parts including empty strings.
    /// CZ: Vrací všechny části včetně prázdných řetězců.
    /// </summary>
    /// <param name="text">Text to split</param>
    /// <param name="delimiters">Delimiter strings</param>
    /// <returns>List of all split parts</returns>
    internal static List<string> SplitNone(string text, params string[] delimiters)
    {
        return text.Split(delimiters, StringSplitOptions.None).ToList();
    }

    internal static List<string> SplitToParts(string text, int parts, string delimiter)
    {
        var splitParts = text.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries).ToList(); //SHSplit.Split(, delimiter);
        if (splitParts.Count < parts)
        {
            // EN: If number of obtained parts is smaller, insert empty strings to the rest
            // CZ: Pokud je pocet ziskanych partu mensi, vlozim do zbytku prazdne retezce
            if (splitParts.Count > 0)
            {
                List<string> result = new List<string>();
                for (int i = 0; i < parts; i++)
                {
                    if (i < splitParts.Count)
                    {
                        result.Add(splitParts[i]);
                    }
                    else
                    {
                        result.Add("");
                    }
                }
                return result;
                //return new string[] { splitParts[0] };
            }
            else
            {
                return null;
            }
        }
        else if (splitParts.Count == parts)
        {
            // EN: If number of obtained parts matches exactly, return as is
            // CZ: Pokud pocet ziskanych partu souhlasim presne, vratim jak je
            return splitParts;
        }

        // EN: If number of obtained parts is greater than expected, append extras to the rest
        // CZ: Pokud je pocet ziskanych partu vetsi nez kolik ma byt, pripojim ty co jsou navic do zbytku
        parts--;
        List<string> result2 = new List<string>();
        for (int i = 0; i < splitParts.Count; i++)
        {
            if (i < parts)
            {
                result2.Add(splitParts[i]);
            }
            else if (i == parts)
            {
                result2.Add(splitParts[i] + delimiter);
            }
            else if (i != splitParts.Count - 1)
            {
                result2[parts] += splitParts[i] + delimiter;
            }
            else
            {
                result2[parts] += splitParts[i];
            }
        }
        return result2;
    }

    #region SplitToPartsFromEnd
    internal static List<string> SplitToPartsFromEnd(string text, int parts, params char[] delimiters)
    {
        List<char> characters = null;
        List<bool> isNotDelimiterFlags = null;
        List<int> delimitersIndexes = null;
        SHSplit.SplitCustom(text, out characters, out isNotDelimiterFlags, out delimitersIndexes, delimiters);

        List<string> result = new List<string>(parts);
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = characters.Count - 1; i >= 0; i--)
        {
            if (!isNotDelimiterFlags[i])
            {
                while (i != 0 && !isNotDelimiterFlags[i - 1])
                {
                    i--;
                }
                string part = stringBuilder.ToString();
                stringBuilder.Clear();
                if (part != "")
                {
                    result.Add(part);
                }
            }
            else
            {
                stringBuilder.Insert(0, characters[i]);
                //stringBuilder.Append(characters[i]);
            }
        }
        string lastPart = stringBuilder.ToString();
        stringBuilder.Clear();
        if (lastPart != "")
        {
            result.Add(lastPart);
        }
        List<string> finalResult = new List<string>(parts);
        for (int i = 0; i < result.Count; i++)
        {
            if (finalResult.Count != parts)
            {
                finalResult.Insert(0, result[i]);
            }
            else
            {
                string delimiterString = text[delimitersIndexes[i - 1]].ToString();
                finalResult[0] = result[i] + delimiterString + finalResult[0];
            }
        }
        return finalResult;
    }

    internal static void SplitCustom(string text, out List<char> characters, out List<bool> isNotDelimiterFlags, out List<int> delimitersIndexes, params char[] delimiters)
    {
        characters = new List<char>(text.Length);
        isNotDelimiterFlags = new List<bool>(text.Length);
        delimitersIndexes = new List<int>(text.Length / 6);
        for (int i = 0; i < text.Length; i++)
        {
            bool isNotDelimiter = true;
            var character = text[i];
            foreach (var item in delimiters)
            {
                if (item == character)
                {
                    delimitersIndexes.Add(i);
                    isNotDelimiter = false;
                    break;
                }
            }
            characters.Add(character);
            isNotDelimiterFlags.Add(isNotDelimiter);
        }
        delimitersIndexes.Reverse();
    }
    #endregion

    //    internal static Func<string, char[], List<string>> SplitChar;
    //    internal static Func<string, String[], List<int>> SplitToIntList;
    //    internal static Func<string, string, List<string>> Split;
    //    internal static Func<string, String[], List<string>> SplitNone;
    //    internal static Func<string, int, Char[], List<string>> SplitToPartsFromEnd;
    //    internal static Func<string, int, string, List<string>> SplitToParts;
}