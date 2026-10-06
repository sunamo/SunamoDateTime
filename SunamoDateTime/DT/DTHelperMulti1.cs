namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class DTHelperMulti
{
    public static string AddRightStringToTimeSpan(TimeSpan timeSpan, bool calculateTime, LangsDt lang)
    {
        int age = timeSpan.TotalYears();
        if (timeSpan.TotalMilliseconds == 0)
        {
            int months = timeSpan.TotalMonths();
            if (months < 3)
            {
                int totalWeeks = timeSpan.Days / 7;
                if (totalWeeks == 0)
                {
                    if (timeSpan.Days == 1)
                    {
                        if (lang == LangsDt.cs)
                        {
                            return timeSpan.Days + " den";
                        }
                        else
                        {
                            return timeSpan.Days + " day";
                        }
                    }
                    else if (timeSpan.Days < 5 && timeSpan.Days > 1)
                    {
                        if (lang == LangsDt.cs)
                        {
                            return timeSpan.Days + " dní";
                        }
                        else
                        {
                            return timeSpan.Days + " days";
                        }
                    }
                    else
                    {
                        if (calculateTime)
                        {
                            if (timeSpan.Hours == 1)
                            {
                                if (lang == LangsDt.cs)
                                {
                                    return timeSpan.Hours + " hodinu";
                                }
                                else
                                {
                                    return timeSpan.Hours + " hour";
                                }
                            }
                            else if (timeSpan.Hours > 1 && timeSpan.Hours < 5)
                            {
                                if (lang == LangsDt.cs)
                                {
                                    return timeSpan.Hours + " hodiny";
                                }
                                else
                                {
                                    return timeSpan.Hours + " hours";
                                }
                            }
                            else if (timeSpan.Hours > 4)
                            {
                                if (lang == LangsDt.cs)
                                {
                                    return timeSpan.Hours + " hodin";
                                }
                                else
                                {
                                    return timeSpan.Hours + " hours";
                                }
                            }
                            else
                            {
                                // Hodin je méně než 1
                                if (timeSpan.Minutes == 1)
                                {
                                    if (lang == LangsDt.cs)
                                    {
                                        return timeSpan.Minutes + " minutu";
                                    }
                                    else
                                    {
                                        return timeSpan.Minutes + " minute";
                                    }
                                }
                                else if (timeSpan.Minutes > 1 && timeSpan.Minutes < 5)
                                {
                                    if (lang == LangsDt.cs)
                                    {
                                        return timeSpan.Minutes + " minuty";
                                    }
                                    else
                                    {
                                        return timeSpan.Minutes + " minutes";
                                    }
                                }
                                else if (timeSpan.Minutes > 4)
                                {
                                    if (lang == LangsDt.cs)
                                    {
                                        return timeSpan.Minutes + " minut";
                                    }
                                    else
                                    {
                                        return timeSpan.Minutes + " minutes";
                                    }
                                }
                                else //if (timeSpan.Minutes == 0)
                                {
                                    if (timeSpan.Seconds == 1)
                                    {
                                        if (lang == LangsDt.cs)
                                        {
                                            return timeSpan.Seconds + " sekundu";
                                        }
                                        else
                                        {
                                            return timeSpan.Seconds + " second";
                                        }
                                    }
                                    else if (timeSpan.Seconds > 1 && timeSpan.Seconds < 5)
                                    {
                                        if (lang == LangsDt.cs)
                                        {
                                            return timeSpan.Seconds + " sekundy";
                                        }
                                        else
                                        {
                                            return timeSpan.Seconds + " seconds";
                                        }
                                    }
                                    else //if (timeSpan.Seconds > 4)
                                    {
                                        if (lang == LangsDt.cs)
                                        {
                                            return timeSpan.Seconds + " sekund";
                                        }
                                        else
                                        {
                                            return timeSpan.Seconds + " seconds";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (lang == LangsDt.cs)
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
                    if (lang == LangsDt.cs)
                    {
                        return totalWeeks + " týden";
                    }
                    else
                    {
                        return totalWeeks + " week";
                    }
                }
                else if (totalWeeks < 5 && totalWeeks > 1)
                {
                    if (lang == LangsDt.cs)
                    {
                        return totalWeeks + " týdny";
                    }
                    else
                    {
                        return totalWeeks + " weeks";
                    }
                }
                else
                {
                    if (lang == LangsDt.cs)
                    {
                        return totalWeeks + " týdnů";
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
                    if (lang == LangsDt.cs)
                    {
                        return months + " měsíc";
                    }
                    else
                    {
                        return months + " months";
                    }
                }
                else if (months > 1 && months < 5)
                {
                    if (lang == LangsDt.cs)
                    {
                        return months + " měsíce";
                    }
                    else
                    {
                        return months + " months";
                    }
                }
                else
                {
                    if (lang == LangsDt.cs)
                    {
                        return months + " měsíců";
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
            if (lang == LangsDt.cs)
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
            if (lang == LangsDt.cs)
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
            if (lang == LangsDt.cs)
            {
                return age + " roků";
            }
            else
            {
                return age + " years";
            }
        }
        else
        {
            if (lang == LangsDt.cs)
            {
                return "Neznámý čas";
            }

            return XNoKnownPeriod;
        }
    }
}
