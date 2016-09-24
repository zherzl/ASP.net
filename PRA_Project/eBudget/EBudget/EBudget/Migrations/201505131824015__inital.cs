namespace EBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class __inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        DatumVrijeme = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Valuta",
                c => new
                    {
                        IDValuta = c.Int(nullable: false, identity: true),
                        Zemlja = c.String(),
                        Oznaka = c.String(),
                        Tecaj = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DatumVrijeme = c.DateTime(nullable: false),
                        Aktivno = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDValuta)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.InicijalnaValuta",
                c => new
                    {
                        IDInicijalnaValuta = c.Int(nullable: false, identity: true),
                        Zemlja = c.String(),
                        Oznaka = c.String(),
                    })
                .PrimaryKey(t => t.IDInicijalnaValuta);
            
            CreateTable(
                "dbo.Kategorija",
                c => new
                    {
                        IDKategorija = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Aktivno = c.Boolean(nullable: false),
                        DatumVrijeme = c.DateTime(nullable: false),
                        TipKategorijaID = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDKategorija)
                .ForeignKey("dbo.TipKategorija", t => t.TipKategorijaID)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.TipKategorijaID)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TipKategorija",
                c => new
                    {
                        IDTipKategorija = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.IDTipKategorija);
            
            CreateTable(
                "dbo.InicijalniPodaci",
                c => new
                    {
                        IDInicijalniPodaci = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        TipKategorijaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDInicijalniPodaci)
                .ForeignKey("dbo.TipKategorija", t => t.TipKategorijaID)
                .Index(t => t.TipKategorijaID);
            
            CreateTable(
                "dbo.PrihodTrosak",
                c => new
                    {
                        IDPrihodTrosak = c.Int(nullable: false, identity: true),
                        Iznos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DatumVrijeme = c.DateTime(nullable: false),
                        Aktivno = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                        KategorijaID = c.Int(nullable: false),
                        ValutaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDPrihodTrosak)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .ForeignKey("dbo.Kategorija", t => t.KategorijaID)
                .ForeignKey("dbo.Valuta", t => t.ValutaID)
                .Index(t => t.UserId)
                .Index(t => t.KategorijaID)
                .Index(t => t.ValutaID);
            
            CreateTable(
                "dbo.Opis",
                c => new
                    {
                        IDOpis = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        PrihodTrosakID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDOpis)
                .ForeignKey("dbo.PrihodTrosak", t => t.PrihodTrosakID)
                .Index(t => t.PrihodTrosakID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Opis", new[] { "PrihodTrosakID" });
            DropIndex("dbo.PrihodTrosak", new[] { "ValutaID" });
            DropIndex("dbo.PrihodTrosak", new[] { "KategorijaID" });
            DropIndex("dbo.PrihodTrosak", new[] { "UserId" });
            DropIndex("dbo.InicijalniPodaci", new[] { "TipKategorijaID" });
            DropIndex("dbo.Kategorija", new[] { "UserId" });
            DropIndex("dbo.Kategorija", new[] { "TipKategorijaID" });
            DropIndex("dbo.Valuta", new[] { "UserId" });
            DropForeignKey("dbo.Opis", "PrihodTrosakID", "dbo.PrihodTrosak");
            DropForeignKey("dbo.PrihodTrosak", "ValutaID", "dbo.Valuta");
            DropForeignKey("dbo.PrihodTrosak", "KategorijaID", "dbo.Kategorija");
            DropForeignKey("dbo.PrihodTrosak", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.InicijalniPodaci", "TipKategorijaID", "dbo.TipKategorija");
            DropForeignKey("dbo.Kategorija", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Kategorija", "TipKategorijaID", "dbo.TipKategorija");
            DropForeignKey("dbo.Valuta", "UserId", "dbo.UserProfile");
            DropTable("dbo.Opis");
            DropTable("dbo.PrihodTrosak");
            DropTable("dbo.InicijalniPodaci");
            DropTable("dbo.TipKategorija");
            DropTable("dbo.Kategorija");
            DropTable("dbo.InicijalnaValuta");
            DropTable("dbo.Valuta");
            DropTable("dbo.UserProfile");
        }
    }
}
