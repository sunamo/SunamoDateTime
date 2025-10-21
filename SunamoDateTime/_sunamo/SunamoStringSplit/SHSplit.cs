// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoDateTime._sunamo.SunamoStringSplit;

//namespace SunamoDateTime;
internal class SHSplit
{
    internal static List<string> SplitNone(string p, params string[] newLine)
    {
        return p.Split(newLine, StringSplitOptions.None).ToList();
    }

    internal static List<string> SplitToParts(string what, int parts, string deli)
    {
        var text = what.Split(new string[] { deli }, StringSplitOptions.RemoveEmptyEntries).ToList(); //SHSplit.Split(, deli);
        if (text.Count < parts)
        {
            // Pokud je pocet ziskanych partu mensi, vlozim do zbytku prazdne retezce
            if (text.Count > 0)
            {
                List<string> vr2 = new List<string>();
                for (int i = 0; i < parts; i++)
                {
                    if (i < text.Count)
                    {
                        vr2.Add(text[i]);
                    }
                    else
                    {
                        vr2.Add("");
                    }
                }
                return vr2;
                //return new string[] { text[0] };
            }
            else
            {
                return null;
            }
        }
        else if (text.Count == parts)
        {
            // Pokud pocet ziskanych partu souhlasim presne, vratim jak je
            return text;
        }

        // Pokud je pocet ziskanych partu vetsi nez kolik ma byt, pripojim ty co josu navic do zbytku
        parts--;
        List<string> vr = new List<string>();
        for (int i = 0; i < text.Count; i++)
        {
            if (i < parts)
            {
                vr.Add(text[i]);
            }
            else if (i == parts)
            {
                vr.Add(text[i] + deli);
            }
            else if (i != text.Count - 1)
            {
                vr[parts] += text[i] + deli;
            }
            else
            {
                vr[parts] += text[i];
            }
        }
        return vr;
    }

    #region SplitToPartsFromEnd
    internal static List<string> SplitToPartsFromEnd(string what, int parts, params char[] deli)
    {
        List<char> chs = null;
        List<bool> bw = null;
        List<int> delimitersIndexes = null;
        SHSplit.SplitCustom(what, out chs, out bw, out delimitersIndexes, deli);

        List<string> vr = new List<string>(parts);
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = chs.Count - 1; i >= 0; i--)
        {
            if (!bw[i])
            {
                while (i != 0 && !bw[i - 1])
                {
                    i--;
                }
                string d = stringBuilder.ToString();
                stringBuilder.Clear();
                if (d != "")
                {
                    vr.Add(d);
                }
            }
            else
            {
                stringBuilder.Insert(0, chs[i]);
                //stringBuilder.Append(chs[i]);
            }
        }
        string d2 = stringBuilder.ToString();
        stringBuilder.Clear();
        if (d2 != "")
        {
            vr.Add(d2);
        }
        List<string> v = new List<string>(parts);
        for (int i = 0; i < vr.Count; i++)
        {
            if (v.Count != parts)
            {
                v.Insert(0, vr[i]);
            }
            else
            {
                string ds = what[delimitersIndexes[i - 1]].ToString();
                v[0] = vr[i] + ds + v[0];
            }
        }
        return v;
    }

    internal static void SplitCustom(string what, out List<char> chs, out List<bool> bs, out List<int> delimitersIndexes, params char[] deli)
    {
        chs = new List<char>(what.Length);
        bs = new List<bool>(what.Length);
        delimitersIndexes = new List<int>(what.Length / 6);
        for (int i = 0; i < what.Length; i++)
        {
            bool isNotDeli = true;
            var ch = what[i];
            foreach (var item in deli)
            {
                if (item == ch)
                {
                    delimitersIndexes.Add(i);
                    isNotDeli = false;
                    break;
                }
            }
            chs.Add(ch);
            bs.Add(isNotDeli);
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