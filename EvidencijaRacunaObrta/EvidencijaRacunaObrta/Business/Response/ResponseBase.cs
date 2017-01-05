using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvidencijaRacunaObrta.Business.Response
{
    public class ResponseBase
    {
        public bool Success { get; set; } = true;
        public string Error { get; set; }
    }
}