using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Net;

namespace WebThief.HtmlParser
{
    public class ParserMain
    {
        public List<LinkItem> ParsedLinks()
        {
            // 1.
            // URL: http://en.wikipedia.org/wiki/Main_Page
            WebClient w = new WebClient();
            string s = w.DownloadString("http://www.24sata.hr/?meta_refresh=true");
            return LinkFinder.Find(s);
        }
        
    }

    public class LinkItem
    {
        public string Href;
        public string Text;
        public string Title { get; set; }
        public override string ToString()
        {
            return Href + "\n\t" + Text;
        }
    }

    public class LinkFinder
    {

        public static List<LinkItem> Find(string file)
        {
            List<LinkItem> list = new List<LinkItem>();

            // 1.
            // Find all matches in file.
            MatchCollection m1 = Regex.Matches(file, @"(<a.*?>.*?</a>)", RegexOptions.Singleline);

            // 2.
            // Loop over each match.
            foreach (Match m in m1)
            {
                string value = m.Groups[1].Value;
                LinkItem i = new LinkItem();

                // 3.
                // Get href attribute.
                Match m2 = Regex.Match(value, @"href=\""(.*?)\""", RegexOptions.Singleline);
                if (m2.Success)
                {
                    i.Href = m2.Groups[1].Value;
                }

                // 4.
                // Remove inner tags from text.
                string t = Regex.Replace(value, @"\s*<.*?>\s*", "", RegexOptions.Singleline);
                i.Text = t;

                // Extract title
                Match mTitle = Regex.Match(value, @"Title=\""(.*?)\""", RegexOptions.Singleline);
                if (mTitle.Success)
                {
                    i.Title = mTitle.Groups[1].Value;
                }


                list.Add(i);
            }
            return list;
        }
    }
}