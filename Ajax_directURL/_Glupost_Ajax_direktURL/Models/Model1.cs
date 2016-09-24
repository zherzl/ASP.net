namespace _Glupost_Ajax_direktURL.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Drzava> Drzavas { get; set; }
        public virtual DbSet<Grad> Grads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzava>()
                .HasMany(e => e.Grads)
                .WithOptional(e => e.Drzava)
                .HasForeignKey(e => e.DrzavaID);
        }
    }
}
