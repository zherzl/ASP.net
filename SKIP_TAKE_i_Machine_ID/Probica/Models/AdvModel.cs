namespace Probica.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AdvModel : DbContext
    {
        public AdvModel()
            : base("name=AdvModelContext")
        {
        }

        public virtual DbSet<Drzava> Drzave { get; set; }
        public virtual DbSet<Grad> Gradovi { get; set; }
        public virtual DbSet<Kupac> Kupci { get; set; }
        public virtual DbSet<Racun> Racuni { get; set; }
        public virtual DbSet<Stavka> Stavke { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzava>()
                .HasMany(e => e.Gradovi)
                .WithOptional(e => e.Drzava)
                .HasForeignKey(e => e.DrzavaID);

            modelBuilder.Entity<Grad>()
                .HasMany(e => e.Kupci)
                .WithOptional(e => e.Grad)
                .HasForeignKey(e => e.GradID);

            modelBuilder.Entity<Kupac>()
                .HasMany(e => e.Racuni)
                .WithRequired(e => e.Kupac)
                .HasForeignKey(e => e.KupacID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Racun>()
                .HasMany(e => e.Stavke)
                .WithRequired(e => e.Racun)
                .HasForeignKey(e => e.RacunID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stavka>()
                .Property(e => e.CijenaPoKomadu)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Stavka>()
                .Property(e => e.PopustUPostocima)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Stavka>()
                .Property(e => e.UkupnaCijena)
                .HasPrecision(38, 6);
        }
    }
}
