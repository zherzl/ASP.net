using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvidencijaRacunaObrta.Models.ObrtModels;

namespace EvidencijaRacunaObrta.Business.Request
{
    public class CreateRacunRequest : RequestBase
    {
        public ObrtRacun ObrtRacun { get; set; }

    }
}