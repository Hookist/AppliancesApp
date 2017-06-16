namespace AppliancesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostMigration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApplianceRestrictions", "IsHidden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplianceRestrictions", "IsHidden", c => c.Boolean());
        }
    }
}
