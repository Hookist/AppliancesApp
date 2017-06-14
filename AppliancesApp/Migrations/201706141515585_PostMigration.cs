namespace AppliancesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplianceRestrictions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsHidden = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Appliances",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 50),
            //            CreateDate = c.DateTime(nullable: false),
            //            Price = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Description = c.String(maxLength: 500),
            //            IsInStock = c.Boolean(nullable: false),
            //            Attachment = c.String(maxLength: 200),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Appliances");
            DropTable("dbo.ApplianceRestrictions");
        }
    }
}
