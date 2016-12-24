namespace Knockout.Repository.EF.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext()
            : base("name=AdventureWorksOBPContext")
        {
        }

        public virtual DbSet<Drzava> Drzave { get; set; }
        public virtual DbSet<Grad> Gradovi { get; set; }
        public virtual DbSet<Kategorija> Kategorije { get; set; }
        public virtual DbSet<Komercijalist> Komercijalisti { get; set; }
        public virtual DbSet<KreditnaKartica> KreditnaKartice { get; set; }
        public virtual DbSet<Kupac> Kupci { get; set; }
        public virtual DbSet<Potkategorija> Potkategorije { get; set; }
        public virtual DbSet<Proizvod> Proizvodi { get; set; }
        public virtual DbSet<Racun> Racuni { get; set; }
        public virtual DbSet<Stavka> Stavke { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Drzava>()
        //        .HasMany(e => e.Grads)
        //        .WithOptional(e => e.Drzava)
        //        .HasForeignKey(e => e.DrzavaID);

        //    modelBuilder.Entity<Grad>()
        //        .HasMany(e => e.Kupacs)
        //        .WithOptional(e => e.Grad)
        //        .HasForeignKey(e => e.GradID);

        //    modelBuilder.Entity<Kategorija>()
        //        .HasMany(e => e.Potkategorijas)
        //        .WithRequired(e => e.Kategorija)
        //        .HasForeignKey(e => e.KategorijaID)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Komercijalist>()
        //        .HasMany(e => e.Racuns)
        //        .WithOptional(e => e.Komercijalist)
        //        .HasForeignKey(e => e.KomercijalistID);

        //    modelBuilder.Entity<KreditnaKartica>()
        //        .HasMany(e => e.Racuns)
        //        .WithOptional(e => e.KreditnaKartica)
        //        .HasForeignKey(e => e.KreditnaKarticaID);

        //    modelBuilder.Entity<Kupac>()
        //        .HasMany(e => e.Racuns)
        //        .WithRequired(e => e.Kupac)
        //        .HasForeignKey(e => e.KupacID)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Potkategorija>()
        //        .HasMany(e => e.Proizvods)
        //        .WithOptional(e => e.Potkategorija)
        //        .HasForeignKey(e => e.PotkategorijaID);

        //    modelBuilder.Entity<Proizvod>()
        //        .Property(e => e.CijenaBezPDV)
        //        .HasPrecision(19, 4);

        //    modelBuilder.Entity<Proizvod>()
        //        .HasMany(e => e.Stavkas)
        //        .WithRequired(e => e.Proizvod)
        //        .HasForeignKey(e => e.ProizvodID)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Racun>()
        //        .HasMany(e => e.Stavkas)
        //        .WithRequired(e => e.Racun)
        //        .HasForeignKey(e => e.RacunID)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Stavka>()
        //        .Property(e => e.CijenaPoKomadu)
        //        .HasPrecision(19, 4);

        //    modelBuilder.Entity<Stavka>()
        //        .Property(e => e.PopustUPostocima)
        //        .HasPrecision(19, 4);

        //    modelBuilder.Entity<Stavka>()
        //        .Property(e => e.UkupnaCijena)
        //        .HasPrecision(38, 6);
        //}
    }
}
