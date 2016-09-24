using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using LocalizationTest.Resourcess;

namespace LocalizationTest.Controllers
{
    public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {

            string lang = "hr-HR";
            //HttpCookie langCookie = HttpContext.Request.Cookies["culture"];
            //if (langCookie != null)
            //    lang = langCookie.Value;
            //else
            //{
            //    var userLanguage = Request.UserLanguages;
            //    var userLang = userLanguage != null ? userLanguage[0] : "";
            //    if (userLang != "")
            //        lang = userLang;
            //    else
            //        lang = SiteLanguages.GetDefaultLanguage();

            //}
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr-HR");
            new SiteLanguages().SetLanguage(lang);
            return base.BeginExecuteCore(callback, state);
        }
    }







    public class SiteLanguages
    {
        public static List<Languages> AvailableLanguages = new List<Languages>
        {
            new Languages { LangFullName = "English", LangCultureName = "en-US" },
            new Languages { LangFullName = "Hrvatski", LangCultureName = "hr-HR" }
        };
        public static bool IsLanguageAvailable(string lang)
        {
            return AvailableLanguages.Where(x => x.LangCultureName.Equals(lang)).FirstOrDefault() != null ? true : false;
        }

        public static string GetDefaultLanguage()
        {
            return AvailableLanguages[1].LangCultureName;
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
    }



}