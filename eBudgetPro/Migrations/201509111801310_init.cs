namespace eBudgetPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Amount",
                c => new
                    {
                        IDAmount = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        AmountValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryID = c.Int(nullable: false),
                        CurrencyID = c.Int(nullable: false),
                        Description = c.String(),
                        InUse = c.Boolean(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDAmount)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .ForeignKey("dbo.Currency", t => t.CurrencyID)
                .Index(t => t.CategoryID)
                .Index(t => t.CurrencyID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        IDCategory = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        CategoryTypeID = c.Int(nullable: false),
                        CategoryName = c.String(nullable: false, maxLength: 70),
                        InUse = c.Boolean(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDCategory)
                .ForeignKey("dbo.CategoryType", t => t.CategoryTypeID)
                .Index(t => t.CategoryTypeID);
            
            CreateTable(
                "dbo.CategoryType",
                c => new
                    {
                        IDCatType = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.IDCatType);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        IDCurrency = c.Int(nullable: false, identity: true),
                        CurrencyLabel = c.String(),
                        Country = c.String(),
                        CountryCode = c.String(),
                    })
                .PrimaryKey(t => t.IDCurrency);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Amount", "CurrencyID", "dbo.Currency");
            DropForeignKey("dbo.Category", "CategoryTypeID", "dbo.CategoryType");
            DropForeignKey("dbo.Amount", "CategoryID", "dbo.Category");
            DropIndex("dbo.Category", new[] { "CategoryTypeID" });
            DropIndex("dbo.Amount", new[] { "CurrencyID" });
            DropIndex("dbo.Amount", new[] { "CategoryID" });
            DropTable("dbo.Currency");
            DropTable("dbo.CategoryType");
            DropTable("dbo.Category");
            DropTable("dbo.Amount");
        }
    }
}
