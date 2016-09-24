namespace EBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PrihodTrosak", "DatumVrijeme", c => c.DateTime(nullable: true, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PrihodTrosak", "DatumVrijeme", c => c.DateTime(nullable: true));
        }
    }
}
