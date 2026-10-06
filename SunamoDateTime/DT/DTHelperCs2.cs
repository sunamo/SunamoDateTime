namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class DTHelperCs
{
    public static string CalculateAgeAndAddRightString(DateTime dateTime, bool calculateTime, DateTime dtMinVal = new DateTime())
    {
        if (dateTime == dtMinVal)
        {
            return "";
        }

        int age = DTHelperGeneral.CalculateAge(dateTime, dtMinVal);
        if (age == 0)
        {
            DateTime Date1 = dateTime;
            DateTime Date2 = DateTime.Now;
            int months = (Date2.Year - Date1.Year) * 12 + Date2.Month - Date1.Month;
            if (months < 3)
            {
                TimeSpan timeElapsed = Date2 - Date1;
                int totalWeeks = timeElapsed.Days / 7;
                if (totalWeeks == 0)
                {
                    if (timeElapsed.Days == 1)
                    {
                        return "  den";
                    }
                    else if (timeElapsed.Days < 5 && timeElapsed.Days > 1)
                    {
                        return timeElapsed.Days + " dny";
                    }
                    else
                    {
                        if (calculateTime)
                        {
                            if (timeElapsed.Hours == 1)
                            {
                                return timeElapsed.Hours + " hodina";
                            }
                            else if (timeElapsed.Hours > 1 && timeElapsed.Hours < 5)
                            {
                                return timeElapsed.Hours + " hodiny";
                            }
                            else if (timeElapsed.Hours > 4)
                            {
                                return timeElapsed.Hours + " hodin";
                            }
                            else
                            {
                                // Hodin je méně než 1
                                if (timeElapsed.Minutes == 1)
                                {
                                    return timeElapsed.Minutes + " minuta";
                                }
                                else if (timeElapsed.Minutes > 1 && timeElapsed.Minutes < 5)
                                {
                                    return timeElapsed.Minutes + " minuty";
                                }
                                else if (timeElapsed.Minutes > 4)
                                {
                                    return timeElapsed.Minutes + " minut";
                                }
                                else //if (timeElapsed.Minutes == 0)
                                {
                                    if (timeElapsed.Seconds == 1)
                                    {
                                        return timeElapsed.Seconds + " sekunda";
                                    }
                                    else if (timeElapsed.Seconds > 1 && timeElapsed.Seconds < 5)
                                    {
                                        return timeElapsed.Seconds + " sekundy";
                                    }
                                    else //if (timeElapsed.Seconds > 4)
                                    {
                                        return timeElapsed.Seconds + " sekund";
                                    }
                                }
                            }
                        }
                        else
                        {
                            return timeElapsed.Days + " dnů";
                        }
                    }
                }
                else if (totalWeeks == 1)
                {
                    return totalWeeks + " týden";
                }
                else if (totalWeeks < 5 && totalWeeks > 1)
                {
                    return totalWeeks + " týdny";
                }
                else
                {
                    return totalWeeks + " týdnů";
                }
            }
            else
            {
                if (months == 1)
                {
                    return months + " měsíc";
                }
                else if (months > 1 && months < 5)
                {
                    return months + " měsíce";
                }
                else
                {
                    return months + " měsíců";
                }
            }
        }
        else if (age == 1)
        {
            return "  rok";
        }
        else if (age > 1 && age < 5)
        {
            return age + " roky";
        }
        else if (age > 4 || age == 0)
        {
            return age + " roků";
        }
        else
        {
            return "Neznámý věk";
        }
    }
}
