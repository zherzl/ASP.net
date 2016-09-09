using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using System.Web.SessionState;

namespace eBudgetPro.Helpers
{
    public static class CultureHelper
    {

        // Print all cultures if needed in table format
        public static MvcHtmlString PrintCultures(this HtmlHelper html, string tableClass, string rowClass)
        {
            TagBuilder table = new TagBuilder("table");
            table.MergeAttribute("id", "cultureTable");
            table.MergeAttribute("name", "cultureTable");
            table.MergeAttribute("class", tableClass);

            int i = 1;

            var obj = CulturesDict().OrderBy(p => p.Key);
            foreach (KeyValuePair<string, string> val in obj)
            {
                TagBuilder row = new TagBuilder("tr");
                if (i % 2 == 0)
                {
                    row.MergeAttribute("class", rowClass);
                }
                TagBuilder cellKey = new TagBuilder("td");
                cellKey.InnerHtml = val.Key;

                TagBuilder cellValue = new TagBuilder("td");
                cellValue.InnerHtml = val.Value;

                row.InnerHtml += cellKey;
                row.InnerHtml += cellValue;
                table.InnerHtml += row;
                
                i++;
                //cmbCountry.Items.Add(new ListItem(val.Key, val.Value.ToUpper()));
            }

            return new MvcHtmlString(table.ToString());
        }


        public static Dictionary<string, string> CulturesDict()
        {
            Dictionary<string, string> objDic = new Dictionary<string, string>();

            foreach (CultureInfo ObjCultureInfo in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo objRegionInfo = new RegionInfo(ObjCultureInfo.Name);
                if (!objDic.ContainsValue(objRegionInfo.TwoLetterISORegionName.ToLower()))
                {
                    objDic.Add(objRegionInfo.NativeName, objRegionInfo.TwoLetterISORegionName.ToLower());
                }
            }

            return objDic;
            //var obj = objDic.OrderBy(p => p.Key);
            //foreach (KeyValuePair<string, string> val in obj)
            //{
            //    System.Diagnostics.Debug.WriteLine(val.Key + " " + val.Value); //cmbCountry.Items.Add(new ListItem(val.Key, val.Value.ToUpper()));
            //}
        }
    }
}
