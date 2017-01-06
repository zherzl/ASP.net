using EvidencijaRacunaObrta.Models.ObrtModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvidencijaRacunaObrta.Business.Response
{
    public class CreateRacunResponse : ResponseBase
    {
        public CreateRacunResponse()
        {
            Templatei = new List<FooterTemplate>();
            Klijenti = new List<Klijent>();
        }
        public Racun Racun { get; set; }
        public int DefaultTemplateId { get; set; }
        public int DefaultKlijentId { get; set; }
        public List<FooterTemplate> Templatei { get; set; }
        public List<Klijent> Klijenti { get; set; }
        public List<string> opis_ { get; set; }
        public List<double> cijena_ { get; set; }
        public List<int> kol_ { get; set; }
        public List<string> jed_ { get; set; }
    }


    public class CreateStavkeResponse : ResponseBase
    {
        public Stavka Stavka { get; set; }
    }

    public class GetTop10StavkeResponse : ResponseBase
    {
        public GetTop10StavkeResponse()
        {
            Stavke = new List<Stavka>();
        }
        public List<Stavka> Stavke { get; set; }
    }
}