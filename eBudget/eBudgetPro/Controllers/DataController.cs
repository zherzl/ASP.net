using eBudgetPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Infrastructure;
using eBudgetPro.Extensions;
using eBudgetPro.Helpers;

namespace eBudgetPro.Controllers
{
    public class DataController : MyBaseController
    {

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult DeleteItem(int idItem, String itemType)
        {

            MyContextSharpPc db = new MyContextSharpPc();
            try
            {
                ItemType iType = EnumClass.GetItemType(itemType);
                
                // Income or expense no difference for delete as it's same table
                if (iType.Equals(ItemType.Income) || iType.Equals(ItemType.Expense))
                {
                    Amount am = null;
                    am = db.Amounts.First(x => x.IDAmount == idItem);
                    db.Amounts.Remove(am);
                    db.SaveChanges();
                }
                else if (itemType.Equals(ItemType.Category.ToString()))
                {

                }
                else
                {
                    return Json(null);
                }

                return GetAmountSumJson(iType);
            }
            catch (Exception)
            {
                return Json(null);
            }

        }


        
        // Get back sum of income or expense to display for appropriate table
        public ActionResult GetAmountSumJson(ItemType itemType)
        {
            MyContextSharpPc db = new MyContextSharpPc();
            GetHomeData getData = new GetHomeData();
            int userID = int.Parse(User.Identity.GetUserId());

            ICollection<Amount> amntsSum = null;
            
            if (itemType.Equals(ItemType.Income))
                amntsSum = getData.AmountList(db, userID, 1);
            else if (itemType.Equals(ItemType.Expense))
                amntsSum = getData.AmountList(db, userID, 2);

            Dictionary<string, string> sumDict = getData.SumAmountsByCurrencyFormat(amntsSum);

            return Json(sumDict);
        }



        


        // Get balance sum to display balance table
        public ActionResult GetBalanceSumJson()
        {
            int userID = int.Parse(User.Identity.GetUserId());
            MyContextSharpPc db = new MyContextSharpPc();
            GetHomeData getData = new GetHomeData();

            List<Saldo> balance = getData.Balance(db, userID);
            Dictionary<string, decimal> balanceDict = getData.SumBalanceDict(balance);
            Dictionary<string, string> balanceDictStr = getData.SumBalanceDictFormat(balanceDict);

            return Json(balanceDictStr);

            //return Json(DropDownHelpers.AmountSumByCurrency(null, balanceDict, "balanceSum"));
        }




        [HttpGet] // ADD or EDIT items in row
        public ActionResult AddCategory(int? idCategory)
        {
            Category cat = null;

            using (MyContextSharpPc db = new MyContextSharpPc())
            {
                ViewBag.catTypes = db.CategoryTypes.ToList();
                int userID = int.Parse(User.Identity.GetUserId());

                if (idCategory != null)
                {
                    cat = db.Categories.FirstOrDefault(x => x.IDCategory == idCategory.Value && x.UserID == userID);
                    Session["cat"] = cat;
                }
                else
                {
                    cat = new Category();
                    cat.InUse = true;
                }
            }

            return View(cat);
        }


        [HttpPost] // ADD or EDIT items in row
        public ActionResult AddCategory(Category cat)
        {

            using (MyContextSharpPc db = new MyContextSharpPc())
            {
                if (ModelState.IsValid)
                {
                    // If edit is called -> update the data, otherwise add new category
                    if (Session["cat"] != null)
                    {
                        Category sourceCat = db.Categories.FirstOrDefault(x => x.IDCategory == cat.IDCategory);
                        sourceCat.CategoryTypeID = cat.CategoryTypeID;
                        sourceCat.CategoryName = cat.CategoryName;
                        sourceCat.UserID = cat.UserID;
                        sourceCat.InUse = cat.InUse;

                        Session["cat"] = null;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        cat.EntryDate = DateTime.Now.Date;
                        db.Categories.Add(cat);
                        db.SaveChanges();
                    }
                }
                ViewBag.catTypes = db.CategoryTypes.ToList();
            }

            return View();
        }




        [HttpGet] // ADD new income or expense GET
        public ActionResult AddAmount(int? idIncomeExpense)
        {
            // Amount = Income or expense
            Amount amount = null;

            using (MyContextSharpPc db = new MyContextSharpPc())
            {
                ViewBag.category = db.Categories.Include("CategoryType").ToList();
                int userID = int.Parse(User.Identity.GetUserId());

                if (idIncomeExpense != null)
                {
                    amount = db.Amounts.FirstOrDefault(x => x.IDAmount == idIncomeExpense.Value && x.UserID == userID);
                    amount.AmountValue = Math.Abs(amount.AmountValue);
                    Session["amount"] = amount; // In post we check if not null => means we are in EDIT mode
                }
                else
                {
                    amount = new Amount();
                    amount.EntryDate = DateTime.Now.Date;
                    amount.InUse = true;
                }
            }
            return View(amount);
        }



        [HttpPost] // ADD new income or expense POST
        public ActionResult AddAmount(Amount amount)
        {

            using (MyContextSharpPc db = new MyContextSharpPc())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        Category cat = db.Categories.Include("CategoryType").SingleOrDefault(x => x.IDCategory == amount.CategoryID);
                        String catType = cat.CategoryType.Name;

                        //If expense, then multiply with -1 so sum balance gets easier to calculate

                        // Ovo ćemo ubuduće uzimati iz sessiona u MyBase controlleru
                        if (catType.ToLower().Equals("trošak") || catType.ToLower().Equals("expense"))
                        {
                            if (amount.AmountValue > 0.0M)
                                amount.AmountValue *= -1;
                        }
                        //If income, ensure value is positive
                        else
                            amount.AmountValue = Math.Abs(amount.AmountValue);

                        // If edit is called -> update the data, otherwise add new category
                        if (Session["amount"] != null)
                        {
                            Amount sourceAmount = db.Amounts.Where(x => x.IDAmount == amount.IDAmount).FirstOrDefault<Amount>();
                            sourceAmount.CategoryID = amount.CategoryID;
                            sourceAmount.AmountValue = amount.AmountValue;
                            sourceAmount.UserID = amount.UserID;
                            sourceAmount.InUse = amount.InUse;
                            sourceAmount.CurrencyID = amount.CurrencyID;
                            sourceAmount.Description = amount.Description;
                            //sourceAmount.Category = amount.Category;
                            //sourceAmount.Currency = amount.Currency;

                            db.SaveChanges();
                            Session["amount"] = null;
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            db.Amounts.Add(amount);
                            db.SaveChanges();
                        }
                    }
                    ViewBag.category = db.Categories.ToList();
                }

                catch (Exception ex)
                {
                    //return View(amount);
                    ViewBag.Error = ex.Message;
                    return View("Error");
                }
            }

            amount = new Amount();
            amount.EntryDate = DateTime.Now.Date;
            amount.InUse = true;
            // Clear fields if true (used to add new Amount after other)
            ViewBag.clear = 1;

            return View(amount);
        }


        // Just for testing purposes
        public ActionResult SaveDataAjax(int categoryID, decimal amountValue, bool inUse, int currencyID,
                                        string descr, int idAmount, DateTime entryDate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MyContextSharpPc db = new MyContextSharpPc();
                    Amount amount = new Amount();

                    if (idAmount > 0)
                        amount = db.Amounts.FirstOrDefault(x => x.IDAmount == idAmount);
                    else
                        db.Amounts.Add(amount);

                    // If expense, multiply by -1 so value is negative (easier data manipulation later)
                    if (categoryID == 2 && amountValue > 0)
                        amountValue *= -1;

                    amount.AmountValue = amountValue;
                    amount.CategoryID = categoryID;
                    amount.CurrencyID = currencyID;
                    amount.Description = descr;
                    amount.EntryDate = entryDate;
                    amount.InUse = inUse;
                    amount.UserID = int.Parse(User.Identity.GetUserId());

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return Json(ex.Message);
                }
            }

            return Json("");
        }


        //catch (DbUpdateException ex)
        //{ System.Diagnostics.Debug.WriteLine(ex.InnerException); }
        //catch (System.Data.Entity.Validation.DbEntityValidationException ex)
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
    }
}