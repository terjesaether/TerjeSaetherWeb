namespace TerjeSaetherWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Releases", "Comment", c => c.String());
            AddColumn("dbo.Releases", "ShowOnFrontpage", c => c.Boolean(nullable: false));
            AddColumn("dbo.Songs", "ShowOnFrontpage", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "ShowOnFrontpage");
            DropColumn("dbo.Releases", "ShowOnFrontpage");
            DropColumn("dbo.Releases", "Comment");
        }
    }
}
