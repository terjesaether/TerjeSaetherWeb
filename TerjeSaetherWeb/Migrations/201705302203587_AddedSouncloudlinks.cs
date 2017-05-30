namespace TerjeSaetherWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSouncloudlinks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Soundcloudlinks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Url = c.String(),
                        Show = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Soundcloudlinks");
        }
    }
}
