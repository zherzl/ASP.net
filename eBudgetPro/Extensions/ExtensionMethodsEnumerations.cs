using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eBudgetPro.Extensions
{

    public enum ItemType
    {
        Income,
        Expense,
        Category
    }



    public static class EnumClass
    {
        // For easier handling (then using strings)
        public static ItemType GetItemType(string itemType)
        {
            switch (itemType)
            {
                case "Income":
                    return ItemType.Income;
                case "Prihod":
                    return ItemType.Income;
                case "Expense":
                    return ItemType.Expense;
                case "Trošak":
                    return ItemType.Expense;
                case "Category":
                    return ItemType.Category;
                default:
                    return new ItemType();
            }
        }
    }
}