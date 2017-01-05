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
        public virtual DbSet<Klijent> Klijenti { get; set; }
        public virtual DbSet<Obrt> Obrti { get; set; }
        public virtual DbSet<FooterTemplate> FooteriRacuna { get; set; }
        public virtual DbSet<Racun> Racuni { get; set; }
        public virtual DbSet<Stavka> Stavke { get; set; }
    }
}