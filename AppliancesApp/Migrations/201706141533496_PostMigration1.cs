namespace AppliancesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostMigration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appliances", "IsInStock", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appliances", "IsInStock", c => c.Boolean(nullable: false));
        }
    }
}
