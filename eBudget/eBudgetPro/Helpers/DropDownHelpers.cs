using eBudgetPro.Extensions;
using eBudgetPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBudgetPro.Helpers
{
    public static class DropDownHelpers
    {
        public static MvcHtmlString DropDownCategoryType(this HtmlHelper html, int selectedId, string className)
        {
            List<CategoryType> catTypes;
            using (MyContextSharpPc db = new MyContextSharpPc())
                catTypes = db.CategoryTypes.ToList();

            TagBuilder select = new TagBuilder("select");
            select.MergeAttribute("id", "CategoryTypeID");
            select.MergeAttribute("name", "CategoryTypeID");
            select.MergeAttribute("class", className);
            
            foreach (var item in catTypes)
            {
                TagBuilder opt = new TagBuilder("option");
                opt.MergeAttribute("value", item.IDCatType.ToString());
                opt.SetInnerText(item.Name);

                if (item.IDCatType == selectedId)
                    opt.MergeAttribute("selected", "true");

                select.InnerHtml += opt;
            }


            return new MvcHtmlString(select.ToString());
        }

        

        public static MvcHtmlString DropDownCategory(this HtmlHelper html, int selectedId, string className)
        {
            List<Category> categories;
            using (MyContextSharpPc db = new MyContextSharpPc())

            categories = db.Categories.Include("CategoryType").OrderBy(x => x.CategoryTypeID).OrderBy(x => x.CategoryName).ToList();

            TagBuilder select = new TagBuilder("select");
            select.MergeAttribute("id", "CategoryID");
            select.MergeAttribute("name", "CategoryID");
            select.MergeAttribute("class", className);

            TagBuilder optGroupIncome = new TagBuilder("optgroup");
            optGroupIncome.MergeAttribute("label", ResourcesFolder.Resource.TabNameIncomeList);

            TagBuilder optGroupExpense = new TagBuilder("optgroup");
            optGroupExpense.MergeAttribute("label", ResourcesFolder.Resource.TabNameExpenseList);

            ItemType iType = EnumClass.GetItemType("prihod");

            foreach (var item in categories)
            {
                TagBuilder opt = new TagBuilder("option");
                opt.MergeAttribute("value", item.IDCategory.ToString());
                opt.SetInnerText(item.CategoryName); // + "   (" + item.CategoryType.Name + ")");

                if (item.IDCategory == selectedId)
                    opt.MergeAttribute("selected", "true");

                ItemType iTypeCurrItem = EnumClass.GetItemType(item.CategoryType.Name);

                //select.InnerHtml += opt;
                // If current item type is income, add to optgroup income, otherwise to expense optgroup
                if (iType.Equals(iTypeCurrItem))
                    optGroupIncome.InnerHtml += opt;
                else
                    optGroupExpense.InnerHtml += opt;
            }

            select.InnerHtml += optGroupIncome;
            select.InnerHtml += optGroupExpense;

            return new MvcHtmlString(select.ToString());
        }



        public static MvcHtmlString DropDownCurrency(this HtmlHelper html, int selectedId, string className)
        {
            List<Currency> currencyList;
            using (MyContextSharpPc db = new MyContextSharpPc())
                currencyList = db.Currencies.ToList();

            TagBuilder select = new TagBuilder("select");
            select.MergeAttribute("id", "CurrencyID");
            select.MergeAttribute("name", "CurrencyID");
            select.MergeAttribute("class", className);

            foreach (var item in currencyList)
            {
                TagBuilder opt = new TagBuilder("option");
                opt.MergeAttribute("value", item.IDCurrency.ToString());
                opt.SetInnerText(item.CurrencyLabel);

                if (item.IDCurrency == selectedId)
                {
                    opt.MergeAttribute("selected", "true");
                }
                
                select.InnerHtml += opt;
            }

            return new MvcHtmlString(select.ToString());
        }



        public static MvcHtmlString AmountSumByCurrency(this HtmlHelper html, Dictionary<string, decimal> amounts, string tableID, string caption)
        {
            TagBuilder table = new TagBuilder("table table-condensed");
            table.MergeAttribute("id", tableID);
            table.MergeAttribute("name", tableID);
            table.MergeAttribute("class", "table");

            TagBuilder captionTag = new TagBuilder("caption");
            captionTag.SetInnerText(caption);
            table.InnerHtml += captionTag;

            TagBuilder tr = new TagBuilder("tr");
            TagBuilder th = new TagBuilder("th");
            th.SetInnerText("Suma po valuti");
            tr.InnerHtml += th;

            foreach (var item in amounts)
            {
                tr = new TagBuilder("tr");

                TagBuilder tdValue1 = new TagBuilder("td");

                tdValue1.SetInnerText(string.Format("{0:N}", item.Value) + " " + item.Key);

                tr.InnerHtml += tdValue1;
                table.InnerHtml += tr;
            }

            return new MvcHtmlString(table.ToString());
        }


    }
}