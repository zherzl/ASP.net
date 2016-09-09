using eBudgetPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace eBudgetPro.Controllers
{
    public class GetHomeData : MyBaseController// Inherit from controller only to get access to user id or Json
    {

        // Method called on page load bla
        public Dictionary<string, decimal> SumBalanceDict(List<Saldo> balanceList)
        {
            Dictionary<string, decimal> dict = new Dictionary<string, decimal>();

            foreach (var item in balanceList)
            {
                string key = item.Currency;
                bool keyExists = dict.ContainsKey(key);

                if (keyExists)
                    dict[key] += item.Sum;
                else
                    dict.Add(key, item.Sum);
            }

            return dict;
        }

        // Same data as above, but formatted for Ajax call
        public Dictionary<string, string> SumBalanceDictFormat(Dictionary<string, decimal> balanceDictDecimal)
        {

            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (var item in balanceDictDecimal)
            {
                bool keyExists = dict.ContainsKey(item.Key);

                if (keyExists)
                    dict[item.Key] += item.Value;
                else
                    dict.Add(item.Key, string.Format("{0:N}", item.Value));
            }

            return dict;
        }
        

        // Method called on page load
        public Dictionary<string, decimal> SumAmountsByCurrency(IEnumerable<Amount> amnts)
        {
            Dictionary<string, decimal> amntSum = new Dictionary<string, decimal>();

            foreach (var item in amnts)
            {
                string key = item.Currency.CurrencyLabel;
                bool keyExist = amntSum.ContainsKey(key);

                if (keyExist)
                    amntSum[key] += item.AmountValue;
                else
                    amntSum.Add(key, item.AmountValue);

            }

            return amntSum;
        }


        // Formatting values to culture for Ajax call
        public Dictionary<string, string> SumAmountsByCurrencyFormat(ICollection<Amount> amnts)
        {
            Dictionary<string, string> amntSumStr = new Dictionary<string, string>();
            Dictionary<string, decimal> amntSumDec = SumAmountsByCurrency(amnts);

            foreach (var item in amntSumDec)
                amntSumStr.Add(item.Key, string.Format("{0:N}", item.Value));
           
            return amntSumStr;
        }

       
        public ICollection<Amount> AmountList(MyContextSharpPc db, int userId, int amounType)
        {
            ICollection<Amount> amntsCollection = db.Amounts
                                            .Include("Category")
                                            .Include("Currency")
                                            .Include("Category.CategoryType")
                                            .OrderByDescending(x => x.EntryDate).ThenByDescending(x => x.IDAmount)
                                            .Where(x => x.UserID == userId && x.InUse == true).ToList();
            if (amounType > 0)
                amntsCollection = amntsCollection.Where(x => x.Category.CategoryTypeID == amounType).ToList();
            
            return amntsCollection;
        }

        



        public List<Saldo> Balance(MyContextSharpPc db, int userID)
        {
            // Radimo sumu i grupiranje po godini, mjesecu, valuti i korisniku
            var amntsSaldo = db.Amounts.Where(x => x.UserID == userID)
                                        .GroupBy(x => new { x.EntryDate.Year, x.EntryDate.Month, x.UserID, x.Currency })
                                        .Select(x =>
                                                new
                                                {
                                                    valuta = x.Key.Currency.CurrencyLabel,
                                                    godina = x.Key.Year,
                                                    mjesec = x.Key.Month,
                                                    suma = x.Sum(y => y.AmountValue),
                                                    zbroj = x.Count()
                                                }).ToList();


            List<Saldo> balance = new List<Saldo>();

            foreach (var item in amntsSaldo)
            {
                string mj = string.Format("{0:00}", item.mjesec, item.valuta);
                //System.Diagnostics.Debug.WriteLine(string.Format("{0}-{1} {2}", item.godina, mj, item.suma));
                Saldo s = new Saldo();
                s.Month = mj;
                s.Year = item.godina;
                s.Sum = item.suma;
                s.Currency = item.valuta;

                balance.Add(s);
            }

            return balance;
        }




        
    }



}