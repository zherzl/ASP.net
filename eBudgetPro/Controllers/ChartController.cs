using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using eBudgetPro.Models;

namespace eBudgetPro.Controllers
{

    public class ChartController : MyBaseController
    {

        // Method returns data for main chart on index pages
        public ActionResult GetAmountsJson(string myCurrency)
        {
            GetHomeData getData = new GetHomeData();
            int userID = int.Parse(User.Identity.GetUserId());

            ICollection<Amount> amnt;
            Dictionary<string, HomeChartData> chartDict = new Dictionary<string, HomeChartData>();

            // Get table with amounts and included category + currency (0 means no category filter)
            amnt = getData.AmountList(new MyContextSharpPc(), userID, 0);
            amnt = amnt.OrderBy(x => x.EntryDate).ToList();
            
            // Inserting values ONLY for passed currency
            foreach (var item in amnt)
            {
                string key = String.Format("{0}-{1:00}", item.EntryDate.Year, item.EntryDate.Month); //item.EntryDate.Date.ToString();

                HomeChartData data = new HomeChartData();
                if (!item.Currency.CurrencyLabel.ToLower().Equals(myCurrency))
                    continue;

                     if (chartDict.ContainsKey(key) && item.AmountValue < 0.0M)     { chartDict[key].Expense += item.AmountValue; } // + to expense
                else if (chartDict.ContainsKey(key) && item.AmountValue > 0.0M)     { chartDict[key].Income += item.AmountValue; }  // + to income
                else if (!chartDict.ContainsKey(key) && item.AmountValue < 0.0M)    { chartDict.Add(key, NewExpense(item)); }       // Add new expense
                else if (!chartDict.ContainsKey(key) && item.AmountValue > 0.0M)    { chartDict.Add(key, NewIncome(item)); }        // Add new income
                else { }// No else needed
                         
                // Summing data for 3rd series on chart
                chartDict[key].Balance += item.AmountValue;
            }

            // Cumulative balance for 4th series (easier to sum after balance is calculated)
            CumulativeSum(chartDict);

            return Json(chartDict, JsonRequestBehavior.AllowGet);
        }

        private void CumulativeSum(Dictionary<string, HomeChartData> chartDict)
        {
            // For cumulative sum
            // First round adds only first balance to cumul. sum
            string prevKey = chartDict.Keys.First();

            foreach (var key in chartDict.Keys)
            {
                // Sum current balance and previous cumul. balance
                chartDict[key].BalanceCum = (chartDict[prevKey].BalanceCum + chartDict[key].Balance);

                // Remember previous key for next round
                prevKey = key;
            }
        }


        // Juset extractions for method above
        private HomeChartData NewExpense(Amount item)
        {
            return new HomeChartData { Currency = item.Currency.CurrencyLabel, DateOfAmount = DateFormat(item.EntryDate.Date), Expense = item.AmountValue };
        }
        private HomeChartData NewIncome(Amount item)
        {
            return new HomeChartData { Currency = item.Currency.CurrencyLabel, DateOfAmount = DateFormat(item.EntryDate.Date), Income = item.AmountValue };
        }



        private string DateFormat(DateTime date)
        {
            return String.Format("{0:dd/MM/yyyy}", date);
        }



        public ActionResult GetNewData()
        {
            GetHomeData getData = new GetHomeData();
            int userID = int.Parse(User.Identity.GetUserId());

            return Json(null, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ChartStatistics()
        {
            return View();
        }

    
    
    
    }


    
}