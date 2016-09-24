namespace EBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bla : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.InicijalniPodaci", "TipKategorijaID");
            CreateIndex("dbo.Kategorija", "TipKategorijaID");
            CreateIndex("dbo.Kategorija", "UserId");
            CreateIndex("dbo.Opis", "PrihodTrosakID");
            CreateIndex("dbo.PrihodTrosak", "UserId");
            CreateIndex("dbo.PrihodTrosak", "KategorijaID");
            CreateIndex("dbo.PrihodTrosak", "ValutaID");
            CreateIndex("dbo.Valuta", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Valuta", new[] { "UserId" });
            DropIndex("dbo.PrihodTrosak", new[] { "ValutaID" });
            DropIndex("dbo.PrihodTrosak", new[] { "KategorijaID" });
            DropIndex("dbo.PrihodTrosak", new[] { "UserId" });
            DropIndex("dbo.Opis", new[] { "PrihodTrosakID" });
            DropIndex("dbo.Kategorija", new[] { "UserId" });
            DropIndex("dbo.Kategorija", new[] { "TipKategorijaID" });
            DropIndex("dbo.InicijalniPodaci", new[] { "TipKategorijaID" });
        }
    }
}
