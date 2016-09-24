namespace ObrisiME_MVC_EF_PovezaneTablice_Ajax.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class AdvModel : DbContext
	{
		public AdvModel()
			: base("name=AdvModel")
		{
		}

		public virtual DbSet<Drzava> Drzavas { get; set; }
		public virtual DbSet<Grad> Grads { get; set; }
		public virtual DbSet<Kupac> Kupacs { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Drzava>()
				.HasMany(e => e.Grads)
				.WithOptional(e => e.Drzava)
				.HasForeignKey(e => e.DrzavaID);

			modelBuilder.Entity<Grad>()
				.HasMany(e => e.Kupacs)
				.WithOptional(e => e.Grad)
				.HasForeignKey(e => e.GradID);
		}
	}
}
