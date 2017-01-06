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
            
        }

        public string PdvInfo { get; set; }
        public string CijenaSlovima { get; set; }
        public string UplataInfo { get; set; }


        public int ObrtId { get; set; }
        public Obrt Obrt { get; set; }
        public string UplataInfoSRacunom { get { return string.Format(UplataInfo, Obrt.ZiroRacun); } }
        public bool IsDefaultTemplate { get; set; }
    }
}