using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EvidencijaRacunaObrta.Models.ObrtModels
{

    public class EvidencijaContext : DbContext
    {
        public EvidencijaContext() : base("name=EvidencijaConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            Database.SetInitializer<EvidencijaContext>(new CreateDatabaseIfNotExists<EvidencijaContext>());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Klijent> Klijenti { get; set; }
        public virtual DbSet<Obrt> Obrti { get; set; }
        public virtual DbSet<FooterTemplate> FooteriRacuna { get; set; }
        public virtual DbSet<Racun> Racuni { get; set; }
        public virtual DbSet<Stavka> Stavke { get; set; }
    }
}