namespace EBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable_Dattime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PrihodTrosak", "DatumVrijeme", c => c.DateTime(nullable: true));
        }

        public override void Down()
        {
            AlterColumn("dbo.PrihodTrosak", "DatumVrijeme", c => c.DateTime(nullable: false));
        }
    }
}
