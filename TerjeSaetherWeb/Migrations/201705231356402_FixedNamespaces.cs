namespace TerjeSaetherWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedNamespaces : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Guid(nullable: false),
                        ImageUrl = c.String(),
                        Filename = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        Data = c.Binary(),
                        Song_SongId = c.Guid(),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Songs", t => t.Song_SongId)
                .Index(t => t.Song_SongId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "Song_SongId", "dbo.Songs");
            DropIndex("dbo.Images", new[] { "Song_SongId" });
            DropTable("dbo.Images");
        }
    }
}
