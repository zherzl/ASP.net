using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvidencijaRacunaObrta.Models.ObrtModels
{
    public class ObrtKlijent : ModelBase<int>
    {
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
        [StringLength(21, MinimumLength = 21, ErrorMessage = "Žiro račun mora imati 21 znak (uključujući HR)")]
    }
}