namespace LocalizationTest.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MojModel : DbContext
    {
        public MojModel()
            : base("name=Context")
        {
        }

        public virtual DbSet<Amount> Amounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryType> CategoryTypes { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        }
    }
}
