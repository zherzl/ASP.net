using Probica.Models.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Probica.Controllers
{
    public class BaseController : Controller
    {
        public MachineDataResponse MachineDataInfo
        {
            get
            {
                MachineDataResponse mdata = new MachineDataResponse();

                if (Session["MachineData"] != null)
                    mdata = Session["MachineData"] as MachineDataResponse;
                else
                {
                    Session["MachineData"] = mdata = MachineData.GetMachineDataResponse();
                    //Session["MachineData"] = mdata;
                } 

                return mdata;
            }
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
    }
}