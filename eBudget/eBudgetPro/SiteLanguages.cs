using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;


namespace eBudgetPro
{
    public class SiteLanguages
    {
        public static List<Languages> AvailableLanguages = new List<Languages>
        {
            new Languages { LangFullName = "English", LangCultureName = "en-US", LangClassName = "en-US" },
            new Languages { LangFullName = "Hrvatski", LangCultureName = "hr", LangClassName = "hr-HR" }
        };
        public static bool IsLanguageAvailable(string lang)
        {
            return AvailableLanguages.Where(x => x.LangCultureName.Equals(lang)).FirstOrDefault() != null ? true : false;
        }

        public static string GetDefaultLanguage()
        {
            return AvailableLanguages[0].LangCultureName;
        }

        public void SetLanguage(string lang)
        {
            try
            {
                if (!IsLanguageAvailable(lang))
                    lang = GetDefaultLanguage();
                
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture; //CultureInfo.CreateSpecificCulture(cultureInfo.Name);
            }
            catch (Exception)
            {
            }
        }

        public static void SetCookie(String lang)
        {
            HttpCookie langCookie = new HttpCookie("culture", lang);
            langCookie.Expires = DateTime.Now.AddYears(1);
            HttpContext.Current.Response.Cookies.Add(langCookie);
            //HttpContext.Current.Response.SetCookie(langCookie);
        }

    }

    public class Languages
    {
        public string LangFullName { get; set; }
        public string LangCultureName { get; set; }
        public string LangClassName { get; set; }
    }
}