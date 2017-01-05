using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaRacunaObrta.Models.ObrtModels
{
    [Table("RacunFooter")]
    public class FooterTemplate : ModelBase<int>
    {
        public FooterTemplate()
        {
            Racuni = new List<Racun>();
        }

        public string PdvInfo { get; set; }
        public string CijenaSlovima { get; set; }
        public string UplataInfo { get; set; }
        public List<Racun> Racuni { get; set; }

        public int ObrtId { get; set; }
        public Obrt Obrt { get; set; }
        public string UplataInfoSRacunom { get { return string.Format(UplataInfo, Obrt.ZiroRacun); } }
    }
}