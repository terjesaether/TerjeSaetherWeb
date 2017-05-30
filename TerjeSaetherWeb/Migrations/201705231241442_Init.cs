namespace TerjeSaetherWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuyLinks",
                c => new
                    {
                        BuyLinkId = c.Guid(nullable: false),
                        BuyLinkTitle = c.String(),
                        BuyLinkUrl = c.String(),
                        Song_SongId = c.Guid(),
                    })
                .PrimaryKey(t => t.BuyLinkId)
                .ForeignKey("dbo.Songs", t => t.Song_SongId)
                .Index(t => t.Song_SongId);
            
            AddColumn("dbo.Songs", "Comment", c => c.String());
            AddColumn("dbo.Songs", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuyLinks", "Song_SongId", "dbo.Songs");
            DropIndex("dbo.BuyLinks", new[] { "Song_SongId" });
            DropColumn("dbo.Songs", "Image");
            DropColumn("dbo.Songs", "Comment");
            DropTable("dbo.BuyLinks");
        }
    }
}
