using eBudgetPro.Helpers;
using eBudgetPro.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace eBudgetPro.Controllers
{
    public class MyBaseController : Controller
    {

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            try
            {
                MyContextSharpPc db = new MyContextSharpPc();
                Session["expenseId"] = db.CategoryTypes.SingleOrDefault(x => x.Name.ToLower().Equals("trošak") || x.Name.ToLower().Equals("expense")).IDCatType;
                Session["incomeId"] = db.CategoryTypes.SingleOrDefault(x => x.Name.ToLower().Equals("prihod") || x.Name.ToLower().Equals("income")).IDCatType;
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Došlo je do pogreške, nije moguće pročitati ID troška ili prihoda";
            }


            string lang = null;
            HttpCookie langCookie = HttpContext. Request.Cookies["culture"];
            if (langCookie != null)
                lang = langCookie.Value;
            else
            {
                var userLanguage = Request.UserLanguages;
                var userLang = userLanguage != null ? userLanguage[0] : "";
                if (userLang != "")
                    lang = userLang;
                else
                    lang = SiteLanguages.GetDefaultLanguage();

            }
            
            new SiteLanguages().SetLanguage(lang);
            return base.BeginExecuteCore(callback, state);
        }


        
        
    }
}