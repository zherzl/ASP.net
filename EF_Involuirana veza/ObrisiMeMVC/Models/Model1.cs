namespace ObrisiMeMVC.Models
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

        public virtual DbSet<GlupaTablica> GlupaTablicas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<GlupaTablica>()
                //.HasMany(e => e.GlupaTablica1)
                //.HasOptional
                //.WithOptional(e => e.GlupaTablica2)
                //.HasForeignKey(e => e.IDNadredenog);
        }
    }
}
