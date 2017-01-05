
namespace DAL_EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ModelLibrary.Entities;
        
    public partial class FootballContext : DbContext
    {
        public FootballContext()
            : base("name=FootballContext")
        {
            Database.SetInitializer<FootballContext>(new DropCreateDatabaseAlways<FootballContext>()); //new CreateDatabaseIfNotExists<FootballContext>());
        }

        public virtual DbSet<Teams> TeamsModel { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
