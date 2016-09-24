using System;
using System.Web.Mvc;

namespace _Glupost_Ajax_direktURL.Controllers
{
    public class MyController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            try
            {
                return base.BeginExecuteCore(callback, state);

            }
            catch (Exception ex)
            {
                ViewBag.greska = ex.Message;
                return base.BeginExecuteCore(callback, state);
            }
        }

        protected override HttpNotFoundResult HttpNotFound(string statusDescription)
        {
            return base.HttpNotFound(statusDescription);
        }
    }
}