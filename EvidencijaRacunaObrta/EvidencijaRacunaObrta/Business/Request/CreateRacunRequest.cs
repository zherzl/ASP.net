using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvidencijaRacunaObrta.Models.ObrtModels;

namespace EvidencijaRacunaObrta.Business.Request
{
    public class CreateRacunRequest : RequestBase
    {
        public int? RacunId { get; set; }
    }

    public class CreateStavkeRequest : RequestBase
    {
        public int? StavkaId { get; set; }
    }

    public class GetTop10StavkeRequest : RequestBase
    {

    }
}