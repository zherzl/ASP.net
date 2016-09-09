using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace eBudgetPro.Models
{
    public class MyContextSharpPc : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Amount> Amounts { get; set; }

        public MyContextSharpPc()
            : base("csSharpPc")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyContextSharpPc>());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
               .HasMany(e => e.Amounts)
               .WithRequired(e => e.Category)
               .HasForeignKey(e => e.CategoryID)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<CategoryType>()
                .HasMany(e => e.Categories)
                .WithRequired(e => e.CategoryType)
                .HasForeignKey(e => e.CategoryTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.Amounts)
                .WithRequired(e => e.Currency)
                .HasForeignKey(e => e.CurrencyID)
                .WillCascadeOnDelete(false);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}
