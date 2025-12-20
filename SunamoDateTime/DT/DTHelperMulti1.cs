// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoDateTime.DT;
public partial class DTHelperMulti
{
    /// <summary>
    /// If A1 could be lower than 1d, return 1d
    /// </summary>
    /// <param name = "ts"></param>
    /// <param name = "calculateTime"></param>
    public static string AddRightStringToTimeSpan(TimeSpan tt, bool calculateTime, LangsDt l)
    {
        int age = tt.TotalYears();
        if (tt.TotalMilliseconds == 0)
        {
            int months = tt.TotalMonths();
            if (months < 3)
            {
                int totalWeeks = tt.Days / 7;
                if (totalWeeks == 0)
                {
                    if (tt.Days == 1)
                    {
                        if (l == LangsDt.cs)
                        {
                            return tt.Days + " den";
                        }
                        else
                        {
                            return tt.Days + " day";
                        }
                    }
                    else if (tt.Days < 5 && tt.Days > 1)
                    {
                        if (l == LangsDt.cs)
                        {
                            return tt.Days + " dn\u00ED";
                        }
                        else
                        {
                            return tt.Days + " days";
                        }
                    }
                    else
                    {
                        if (calculateTime)
                        {
                            if (tt.Hours == 1)
                            {
                                if (l == LangsDt.cs)
                                {
                                    return tt.Hours + " hodinu";
                                }
                                else
                                {
                                    return tt.Hours + " hour";
                                }
                            }
                            else if (tt.Hours > 1 && tt.Hours < 5)
                            {
                                if (l == LangsDt.cs)
                                {
                                    return tt.Hours + " hodiny";
                                }
                                else
                                {
                                    return tt.Hours + " hours";
                                }
                            }
                            else if (tt.Hours > 4)
                            {
                                if (l == LangsDt.cs)
                                {
                                    return tt.Hours + " hodin";
                                }
                                else
                                {
                                    return tt.Hours + " hours";
                                }
                            }
                            else
                            {
                                // Hodin je méně než 1
                                if (tt.Minutes == 1)
                                {
                                    if (l == LangsDt.cs)
                                    {
                                        return tt.Minutes + " minutu";
                                    }
                                    else
                                    {
                                        return tt.Minutes + " minute";
                                    }
                                }
                                else if (tt.Minutes > 1 && tt.Minutes < 5)
                                {
                                    if (l == LangsDt.cs)
                                    {
                                        return tt.Minutes + " minuty";
                                    }
                                    else
                                    {
                                        return tt.Minutes + " minutes";
                                    }
                                }
                                else if (tt.Minutes > 4)
                                {
                                    if (l == LangsDt.cs)
                                    {
                                        return tt.Minutes + " minut";
                                    }
                                    else
                                    {
                                        return tt.Minutes + " minutes";
                                    }
                                }
                                else //if (tt.Minutes == 0)
                                {
                                    if (tt.Seconds == 1)
                                    {
                                        if (l == LangsDt.cs)
                                        {
                                            return tt.Seconds + " sekundu";
                                        }
                                        else
                                        {
                                            return tt.Seconds + " second";
                                        }
                                    }
                                    else if (tt.Seconds > 1 && tt.Seconds < 5)
                                    {
                                        if (l == LangsDt.cs)
                                        {
                                            return tt.Seconds + " sekundy";
                                        }
                                        else
                                        {
                                            return tt.Seconds + " seconds";
                                        }
                                    }
                                    else //if (tt.Seconds > 4)
                                    {
                                        if (l == LangsDt.cs)
                                        {
                                            return tt.Seconds + " sekund";
                                        }
                                        else
                                        {
                                            return tt.Seconds + " seconds";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (l == LangsDt.cs)
                            {
                                return "~1 den";
                            }
                            else
                            {
                                return "~1 day";
                            }
                        }
                    }
                }
                else if (totalWeeks == 1)
                {
                    if (l == LangsDt.cs)
                    {
                        return totalWeeks + " t\u00FDden";
                    }
                    else
                    {
                        return totalWeeks + " week";
                    }
                }
                else if (totalWeeks < 5 && totalWeeks > 1)
                {
                    if (l == LangsDt.cs)
                    {
                        return totalWeeks + " t\u00FDdny";
                    }
                    else
                    {
                        return totalWeeks + " weeks";
                    }
                }
                else
                {
                    if (l == LangsDt.cs)
                    {
                        return totalWeeks + " t\u00FDdn\u016F";
                    }
                    else
                    {
                        return totalWeeks + " weeks";
                    }
                }
            }
            else
            {
                if (months == 1)
                {
                    if (l == LangsDt.cs)
                    {
                        return months + " m\u011Bs\u00EDc";
                    }
                    else
                    {
                        return months + " months";
                    }
                }
                else if (months > 1 && months < 5)
                {
                    if (l == LangsDt.cs)
                    {
                        return months + " m\u011Bs\u00EDce";
                    }
                    else
                    {
                        return months + " months";
                    }
                }
                else
                {
                    if (l == LangsDt.cs)
                    {
                        return months + " m\u011Bs\u00EDc\u016F";
                    }
                    else
                    {
                        return months + " months";
                    }
                }
            }
        }
        else if (age == 1)
        {
            if (l == LangsDt.cs)
            {
                return "  rok";
            }
            else
            {
                return "  year";
            }
        }
        else if (age > 1 && age < 5)
        {
            if (l == LangsDt.cs)
            {
                return age + " roky";
            }
            else
            {
                return age + " years";
            }
        }
        else if (age > 4 || age == 0)
        {
            if (l == LangsDt.cs)
            {
                return age + " rok\u016F";
            }
            else
            {
                return age + " years";
            }
        }
        else
        {
            if (l == LangsDt.cs)
            {
                return "Nezn\u00E1m\u00FD \u010Das";
            }

            return xNoKnownPeriod;
        }
    }
}