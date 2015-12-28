namespace API.Core.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class widgetPropertyAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Widgets", "Manufacturer", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Widgets", "Manufacturer");
        }
    }
}
