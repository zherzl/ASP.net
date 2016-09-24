namespace WCFTest.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AdvModelDva : DbContext
    {
        public AdvModelDva()
            : base("name=AdvModelDva")
        {
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Configuration.ValidateOnSaveEnabled = true;
        }

        protected override void Dispose(bool disposing)
        {
            Configuration.LazyLoadingEnabled = false;
            base.Dispose(disposing);
        }

        public virtual DbSet<Drzava> Drzave { get; set; }
        public virtual DbSet<Grad> Gradovi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzava>()
                .HasMany(e => e.Gradovi)
                .WithOptional(e => e.Drzava)
                .HasForeignKey(e => e.DrzavaID);
        }
    }
}
