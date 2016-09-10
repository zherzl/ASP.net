namespace MVC_LoadDataOnMouseScroll.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AdventureWorksModel : DbContext
    {
        public AdventureWorksModel()
            : base("name=AdventureWorksModel")
        {
        }

        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Kupac> Kupac { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzava>()
                .HasMany(e => e.Grad)
                .WithOptional(e => e.Drzava)
                .HasForeignKey(e => e.DrzavaID);

            modelBuilder.Entity<Grad>()
                .HasMany(e => e.Kupac)
                .WithOptional(e => e.Grad)
                .HasForeignKey(e => e.GradID);
        }
    }
}
