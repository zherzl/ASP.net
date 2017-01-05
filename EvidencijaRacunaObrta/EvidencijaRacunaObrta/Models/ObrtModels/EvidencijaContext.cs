using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvidencijaRacunaObrta.Models.ObrtModels
{

    public class EvidencijaContext : DbContext
    {
        public EvidencijaContext() : base("name=EvidencijaConnection")
        {
        }
        public virtual DbSet<ObrtKlijent> Klijenti { get; set; }
        public virtual DbSet<ObrtDetalj> DetaljiObrta { get; set; }
        public virtual DbSet<RacunFooter> FooteriRacuna { get; set; }
        public virtual DbSet<ObrtRacun> Racuni { get; set; }
        public virtual DbSet<ObrtStavka> Stavke { get; set; }
    }
}