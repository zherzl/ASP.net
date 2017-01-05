using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaRacunaObrta.Models.ObrtModels
{
    [Table("ObrtKlijent")]
    public class ObrtKlijent : ModelBase<int>
    {
        public ObrtKlijent()
        {
            Racuni = new List<ObrtRacun>();
        }
        [StringLength(50)]
        public string NazivKlijenta { get; set; }
        [StringLength(70)]
        public string Ulica { get; set; }
        [StringLength(10)]
        public string KucniBroj { get; set; }
        [StringLength(10)]
        public string PostanskiBroj { get; set; }
        [StringLength(50)]
        public string Grad { get; set; }
        [StringLength(11, MinimumLength = 11, ErrorMessage = "OIB mora imati 11 znakova")]
        public string OIB { get; set; }
        public List<ObrtRacun> Racuni { get; set; }
        
        public ObrtDetalj ObrtDetalj { get; set; }
    }
}