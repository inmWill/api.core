namespace API.Core.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedAppUserEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "SecondaryEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "SecondaryEmail");
        }
    }
}
