namespace TerjeSaetherWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Songs", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Songs", "Title", c => c.String());
        }
    }
}
