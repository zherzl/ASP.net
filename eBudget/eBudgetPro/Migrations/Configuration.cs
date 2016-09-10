namespace eBudgetPro.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eBudgetPro.Models.MyContextSharpPc>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(eBudgetPro.Models.MyContextSharpPc context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.CategoryTypes.AddOrUpdate(
                x => x.Name,
                new eBudgetPro.Models.CategoryType { Name = "Prihod" },
                new eBudgetPro.Models.CategoryType { Name = "Trošak" }
                );
            context.SaveChanges();
            int catIncomeID = context.CategoryTypes.FirstOrDefault(x => x.Name.Equals("Prihod")).IDCatType;
            int catExpenseID = context.CategoryTypes.FirstOrDefault(x => x.Name.Equals("Trošak")).IDCatType;

            // Inserting category by comparing two fields (Name and user id) -> this is done at registration time
            //context.Categories.AddOrUpdate(
            //    x => new { x.CategoryName, x.UserID },
            //    new eBudgetPro.Models.Category { CategoryName = "Plaća", CategoryTypeID = catIncomeID, EntryDate = DateTime.Now.Date, InUse = true, UserID = 1 }
            //    );

            context.Currencies.AddOrUpdate(
                    x => x.CountryCode,
                    new eBudgetPro.Models.Currency { Country = "Hrvatska", CountryCode = "007", CurrencyLabel = "kn" },
                    new eBudgetPro.Models.Currency { Country = "Češka", CountryCode = "203", CurrencyLabel = "Kč" },
                    new eBudgetPro.Models.Currency { Country = "Danska", CountryCode = "208", CurrencyLabel = "kr" },
                    new eBudgetPro.Models.Currency { Country = "Mađarska", CountryCode = "348", CurrencyLabel = "Ft" },
                    new eBudgetPro.Models.Currency { Country = "Japan", CountryCode = "392", CurrencyLabel = "¥" },
                    new eBudgetPro.Models.Currency { Country = "Norveška", CountryCode = "578", CurrencyLabel = "kr" },
                    new eBudgetPro.Models.Currency { Country = "Švedska", CountryCode = "752", CurrencyLabel = "kr" },
                    new eBudgetPro.Models.Currency { Country = "Švicarska", CountryCode = "756", CurrencyLabel = "CHF" },
                    new eBudgetPro.Models.Currency { Country = "Vel. Britanija", CountryCode = "826", CurrencyLabel = "GBP" },
                    new eBudgetPro.Models.Currency { Country = "SAD", CountryCode = "840", CurrencyLabel = "$" },
                    new eBudgetPro.Models.Currency { Country = "EMU", CountryCode = "978", CurrencyLabel = "€" }
                );
        }
    }
}
