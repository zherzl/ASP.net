using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaRacunaObrta.Models.ObrtModels
{
    [Table("Klijent")]
    public class Klijent : ModelBase<int>
    {
        public Klijent()
        {
            Racuni = new List<Racun>();
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
        public virtual List<Racun> Racuni { get; set; }

        [Required]
        public int ObrtId { get; set; }
        public virtual Obrt Obrt { get; set; }
        public bool IsDefaultKlijent { get; set; }
    }
}