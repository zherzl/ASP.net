using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaRacunaObrta.Models.ObrtModels
{
    [Table("RacunFooter")]
    public class RacunFooter : ModelBase<int>
    {
        public RacunFooter()
        {
            Racuni = new List<ObrtRacun>();
        }

        public string PdvInfo { get; set; }
        public string CijenaSlovima { get; set; }
        public string UplataInfo { get; set; }
        public List<ObrtRacun> Racuni { get; set; }
        
        public ObrtDetalj ObrtDetalj { get; set; }
        public string UplataInfoSRacunom { get { return string.Format(UplataInfo, ObrtDetalj.ZiroRacun); } }
    }
}