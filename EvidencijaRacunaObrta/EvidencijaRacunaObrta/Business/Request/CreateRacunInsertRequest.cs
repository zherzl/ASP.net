using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvidencijaRacunaObrta.Models.ObrtModels;

namespace EvidencijaRacunaObrta.Business.Request
{
    public class CreateRacunInsertRequest : RequestBase
    {
        public int DefaultTemplateId { get; set; }
        public int DefaultKlijentId { get; set; }
        public Racun Racun { get; set; }
    }
}