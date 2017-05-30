namespace TerjeSaetherWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLink : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BuyLinks", newName: "Links");
            DropPrimaryKey("dbo.Links");
            CreateTable(
                "dbo.PostTypes",
                c => new
                    {
                        PostTypeid = c.Guid(nullable: false),
                        PostTypeName = c.String(),
                    })
                .PrimaryKey(t => t.PostTypeid);
            
            AddColumn("dbo.BlogPosts", "PostType_PostTypeid", c => c.Guid());
            AddColumn("dbo.Links", "Id", c => c.Guid(nullable: false));
            AddColumn("dbo.Links", "LinkTitle", c => c.String());
            AddColumn("dbo.Links", "LinkUrl", c => c.String());
            AlterColumn("dbo.BlogPosts", "Title", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Links", "Id");
            CreateIndex("dbo.BlogPosts", "PostType_PostTypeid");
            AddForeignKey("dbo.BlogPosts", "PostType_PostTypeid", "dbo.PostTypes", "PostTypeid");
            DropColumn("dbo.Links", "BuyLinkId");
            DropColumn("dbo.Links", "BuyLinkTitle");
            DropColumn("dbo.Links", "BuyLinkUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Links", "BuyLinkUrl", c => c.String());
            AddColumn("dbo.Links", "BuyLinkTitle", c => c.String());
            AddColumn("dbo.Links", "BuyLinkId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.BlogPosts", "PostType_PostTypeid", "dbo.PostTypes");
            DropIndex("dbo.BlogPosts", new[] { "PostType_PostTypeid" });
            DropPrimaryKey("dbo.Links");
            AlterColumn("dbo.BlogPosts", "Title", c => c.String());
            DropColumn("dbo.Links", "LinkUrl");
            DropColumn("dbo.Links", "LinkTitle");
            DropColumn("dbo.Links", "Id");
            DropColumn("dbo.BlogPosts", "PostType_PostTypeid");
            DropTable("dbo.PostTypes");
            AddPrimaryKey("dbo.Links", "BuyLinkId");
            RenameTable(name: "dbo.Links", newName: "BuyLinks");
        }
    }
}
