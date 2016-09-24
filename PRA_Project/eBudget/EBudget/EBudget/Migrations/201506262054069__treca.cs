namespace EBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class __treca : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PrihodTrosak", "DatumVrijeme", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PrihodTrosak", "DatumVrijeme", c => c.DateTime(nullable: false));
        }
    }
}
