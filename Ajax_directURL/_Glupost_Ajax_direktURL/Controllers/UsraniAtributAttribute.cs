using System;
using System.Web.Mvc;

namespace _Glupost_Ajax_direktURL.Controllers
{
    internal class UsraniAtributAttribute : FilterAttribute, IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Metoda mora biti POST - rawUrl mora biti isti kao path i querystring mora biti prazan (ako je on pun, path i rawUrl se razlikuju)
            string method = filterContext.HttpContext.Request.HttpMethod;
            string queryString = filterContext.HttpContext.Request.QueryString != null ? filterContext.HttpContext.Request.QueryString.ToString() : null;
            string rawUrl = filterContext.HttpContext.Request.RawUrl;
            string path = filterContext.HttpContext.Request.Path;

            if (method != "POST" || rawUrl != path || !string.IsNullOrEmpty(queryString))
            {
                throw new Exception("Pokušavate doći do putanje koja nije dozvoljena");
            }
        }
    }
}