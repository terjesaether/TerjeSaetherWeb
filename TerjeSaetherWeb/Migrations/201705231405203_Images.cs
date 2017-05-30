namespace TerjeSaetherWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Images : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "Song_SongId", "dbo.Songs");
            DropIndex("dbo.Images", new[] { "Song_SongId" });
            AddColumn("dbo.Songs", "Image_ImageId", c => c.Guid());
            CreateIndex("dbo.Songs", "Image_ImageId");
            AddForeignKey("dbo.Songs", "Image_ImageId", "dbo.Images", "ImageId");
            DropColumn("dbo.Images", "Song_SongId");
            DropColumn("dbo.Songs", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "Image", c => c.Binary());
            AddColumn("dbo.Images", "Song_SongId", c => c.Guid());
            DropForeignKey("dbo.Songs", "Image_ImageId", "dbo.Images");
            DropIndex("dbo.Songs", new[] { "Image_ImageId" });
            DropColumn("dbo.Songs", "Image_ImageId");
            CreateIndex("dbo.Images", "Song_SongId");
            AddForeignKey("dbo.Images", "Song_SongId", "dbo.Songs", "SongId");
        }
    }
}
