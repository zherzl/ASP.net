using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaRacunaObrta.Models.ObrtModels
{
    [Table("Racun")]
    public class Racun : ModelBase<int>
    {
        public Racun()
        {
            Stavke = new List<Stavka>();
        }
        public string BrojRacuna { get; set; }
        public string FiskalniBrojRacuna { get; set; }
        public string Mjesto { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public string OznakaOperatera { get; set; }
        public int ValutaPlacanja { get; set; } = 15;
        public string JedinicaPlacanja { get; set; } = "dana";
        public string NacinPlacanja { get; set; } = "Transakcijski račun";
        public string ZiroRacun { get; set; }
        public int ObrtDetaljId { get; set; }
        [ForeignKey("ObrtDetaljId")]
        public Obrt ObrtDetalj { get; set; }
        public int ObrtKlijentId { get; set; }
        public Klijent Klijent { get; set; }

        public List<Stavka> Stavke { get; set; }
        decimal _iznos;
        public decimal IznosRacuna
        {
            get
            {
                _iznos = Stavke.Select(x => x.UkupnoCijena).Sum();
                return _iznos;
            }
            set { _iznos = value; }
        }

        public string FooterPdvInfo { get; set; }
        public string FooterUplataInfo { get; set; }
        public string FooterCijenaSlovima { get; set; }
    }
}