namespace API.Core.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WidgetFeature : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Widgets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Description = c.String(nullable: false, maxLength: 500),
                        ModifiedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Widgets");
        }
    }
}
