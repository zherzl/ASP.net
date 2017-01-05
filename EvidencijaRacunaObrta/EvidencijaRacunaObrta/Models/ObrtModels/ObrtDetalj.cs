using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaRacunaObrta.Models.ObrtModels
{
    [Table("ObrtDetalj")]
    public class ObrtDetalj : ModelBase<int>
    {
        [StringLength(50)]
        public string NazivObrta { get; set; }
        [StringLength(500)]
        public string ObrtOpis { get; set; }
        [StringLength(100)]
        public string Vlasnik { get; set; }
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
        public string ZiroRacun { get; set; }
    }
}