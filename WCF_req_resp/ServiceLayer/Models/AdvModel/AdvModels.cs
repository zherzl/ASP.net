namespace ServiceLayer.Models.AdvModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Runtime.Serialization;

    public partial class AdvModels : DbContext
    {
        public AdvModels()
            : base("name=AdvModels")
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.ValidateOnSaveEnabled = true;
        }


        public virtual DbSet<Drzava> Drzave { get; set; }
        public virtual DbSet<Grad> Gradovi { get; set; }
        //public virtual DbSet<Kupac> Kupci { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzava>()
                .HasMany(e => e.Gradovi)
                .WithOptional(e => e.Drzava)
                .HasForeignKey(e => e.DrzavaID);

            //modelBuilder.Entity<Grad>()
            //    .HasMany(e => e.Kupci)
            //    .WithOptional(e => e.Grad)
            //    .HasForeignKey(e => e.GradID);
        }
    }
}
