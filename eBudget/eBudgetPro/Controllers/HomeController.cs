using eBudgetPro.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using eBudgetPro.Extensions;
using System.Net.Mail;

namespace eBudgetPro.Controllers
{
    [Authorize]
    public class HomeController : MyBaseController
    {


        public ActionResult Index()
        {
            MailAddress to = new MailAddress("sharp9@outlook.com");
            MailAddress from = new MailAddress("pero@gmail.com");
            MailMessage mail = new MailMessage(from, to);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.google.com";
            mail.Subject = "this is a test email.";
            mail.Body = "this is my test email body";
            mail.Bcc.Add("zlatko.herzl@outlook.com");
            client.Send(mail);


            return View();
            try
            {
                MyContextSharpPc db = new MyContextSharpPc();
                GetHomeData getData = new GetHomeData();
                int userId = int.Parse(User.Identity.GetUserId());
				DateTime dt = DateTime.Now;
                // Get table data
                IEnumerable<Amount> amntsIncome = getData.AmountList(db, userId, 1); // THis one is passed as a Model
                IEnumerable<Amount> amntsExpense = getData.AmountList(db, userId, 2);
                ViewBag.expense = amntsExpense;
                
                // Create Sums for data above
                List<Saldo> balanceList = getData.Balance(db, userId);
                Dictionary<string, decimal> sumIncomDict = getData.SumAmountsByCurrency(amntsIncome);
                Dictionary<string, decimal> sumExpenseDict = getData.SumAmountsByCurrency(amntsExpense);

                ViewBag.sumIncome = sumIncomDict; //amntsIncome.Sum(x => x.AmountValue);
                ViewBag.sumExpense = sumExpenseDict; //amntsExpense.Sum(x => x.AmountValue);
                ViewBag.balance = balanceList;
                ViewBag.balanceSum = getData.SumBalanceDict(balanceList);

                return View(amntsIncome);

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message + "\n" + ex.InnerException;
                return View("Error");
            }
            
            #region Entity exception handling for testing
            // Exception lovi pohranu podataka -> korišteno u svrhe testiranja
            //catch (DbUpdateException ex)
            //{ System.Diagnostics.Debug.WriteLine(ex.InnerException); }
            //catch (DbEntityValidationException ex)
            //{
            //    foreach (var validationErrors in ex.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            string message = string.Format("{0}:{1}",
            //                validationErrors.Entry.Entity.ToString(),
            //                validationError.ErrorMessage);
            //        }
            //    }
            //}
            #endregion
        }

        public ActionResult Somewhere()
        {
            return View();
        }
        
        
        

        [Authorize(Roles = "Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }



        public ActionResult ChangeLanguage(string lang)
        {
            //new SiteLanguages().SetLanguage(lang);
            SiteLanguages.SetCookie(lang);
            return RedirectToAction("Index", "Home");
        }




        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        

    }
}