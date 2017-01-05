using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaRacunaObrta.Models.ObrtModels
{
    [Table("ObrtRacun")]
    public class ObrtRacun : ModelBase<int>
    {
        public ObrtRacun()
        {
            Stavke = new List<ObrtStavka>();
        }
        public string BrojRacuna { get; set; }
        public string FiskalniBrojRacuna { get; set; }
        public string Mjesto { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public string OznakaOperatera { get; set; }
        public int ValutaPlacanja { get; set; }
        public string JedinicaPlacanja { get; set; } = "dana";
        public string NacinPlacanja { get; set; } = "Transakcijski račun";
        public int ObrtDetaljId { get; set; }
        [ForeignKey("ObrtDetaljId")]
        public ObrtDetalj ObrtDetalj { get; set; }
        public int ObrtKlijentId { get; set; }
        public ObrtKlijent ObrtKlijent { get; set; }

        public List<ObrtStavka> Stavke { get; set; }
        public decimal IznosRacuna { get { return Stavke.Select(x => x.UkupnoCijena).Sum(); } }

        public int ObrtFooterId { get; set; }
        public RacunFooter ObrtFooter { get; set; }
    }
}