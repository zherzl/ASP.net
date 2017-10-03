namespace EvidencijaRacunaObrta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ObrtDetalj",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NazivObrta = c.String(maxLength: 50),
                        ObrtOpis = c.String(maxLength: 500),
                        Vlasnik = c.String(maxLength: 100),
                        Ulica = c.String(maxLength: 70),
                        KucniBroj = c.String(maxLength: 10),
                        PostanskiBroj = c.String(maxLength: 10),
                        Grad = c.String(maxLength: 50),
                        OIB = c.String(maxLength: 11),
                        ZiroRacun = c.String(maxLength: 21),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ObrtRacun",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrojRacuna = c.String(),
                        FiskalniBrojRacuna = c.String(),
                        Mjesto = c.String(),
                        DatumVrijeme = c.DateTime(nullable: false),
                        OznakaOperatera = c.String(),
                        ValutaPlacanja = c.Int(nullable: false),
                        JedinicaPlacanja = c.String(),
                        NacinPlacanja = c.String(),
                        ObrtDetaljId = c.Int(nullable: false),
                        ObrtKlijentId = c.Int(nullable: false),
                        ObrtFooterId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ObrtDetalj", t => t.ObrtDetaljId, cascadeDelete: true)
                .ForeignKey("dbo.RacunFooter", t => t.ObrtFooterId, cascadeDelete: true)
                .ForeignKey("dbo.ObrtKlijent", t => t.ObrtKlijentId, cascadeDelete: true)
                .Index(t => t.ObrtDetaljId)
                .Index(t => t.ObrtKlijentId)
                .Index(t => t.ObrtFooterId);
            
            CreateTable(
                "dbo.RacunFooter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PdvInfo = c.String(),
                        CijenaSlovima = c.String(),
                        UplataInfo = c.String(),
                        UserId = c.Int(nullable: false),
                        ObrtDetalj_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ObrtDetalj", t => t.ObrtDetalj_Id)
                .Index(t => t.ObrtDetalj_Id);
            
            CreateTable(
                "dbo.ObrtKlijent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NazivKlijenta = c.String(maxLength: 50),
                        Ulica = c.String(maxLength: 70),
                        KucniBroj = c.String(maxLength: 10),
                        PostanskiBroj = c.String(maxLength: 10),
                        Grad = c.String(maxLength: 50),
                        OIB = c.String(maxLength: 11),
                        UserId = c.Int(nullable: false),
                        ObrtDetalj_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ObrtDetalj", t => t.ObrtDetalj_Id)
                .Index(t => t.ObrtDetalj_Id);
            
            CreateTable(
                "dbo.ObrtStavka",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RacunId = c.Int(nullable: false),
                        UslugaOpis = c.String(),
                        Cijena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Kolicina = c.Int(nullable: false),
                        Jedinica = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ObrtRacun", t => t.RacunId, cascadeDelete: true)
                .Index(t => t.RacunId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ObrtStavka", "RacunId", "dbo.ObrtRacun");
            DropForeignKey("dbo.ObrtRacun", "ObrtKlijentId", "dbo.ObrtKlijent");
            DropForeignKey("dbo.ObrtKlijent", "ObrtDetalj_Id", "dbo.ObrtDetalj");
            DropForeignKey("dbo.ObrtRacun", "ObrtFooterId", "dbo.RacunFooter");
            DropForeignKey("dbo.RacunFooter", "ObrtDetalj_Id", "dbo.ObrtDetalj");
            DropForeignKey("dbo.ObrtRacun", "ObrtDetaljId", "dbo.ObrtDetalj");
            DropIndex("dbo.ObrtStavka", new[] { "RacunId" });
            DropIndex("dbo.ObrtKlijent", new[] { "ObrtDetalj_Id" });
            DropIndex("dbo.RacunFooter", new[] { "ObrtDetalj_Id" });
            DropIndex("dbo.ObrtRacun", new[] { "ObrtFooterId" });
            DropIndex("dbo.ObrtRacun", new[] { "ObrtKlijentId" });
            DropIndex("dbo.ObrtRacun", new[] { "ObrtDetaljId" });
            DropTable("dbo.ObrtStavka");
            DropTable("dbo.ObrtKlijent");
            DropTable("dbo.RacunFooter");
            DropTable("dbo.ObrtRacun");
            DropTable("dbo.ObrtDetalj");
        }
    }
}
