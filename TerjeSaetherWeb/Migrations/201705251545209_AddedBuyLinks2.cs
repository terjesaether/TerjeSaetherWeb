namespace TerjeSaetherWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBuyLinks2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FrontPageBoxes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        WebsiteLink_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Links", t => t.WebsiteLink_Id)
                .Index(t => t.WebsiteLink_Id);
            
            AddColumn("dbo.Links", "FrontPageBox_Id", c => c.Guid());
            AddColumn("dbo.Links", "FrontPageBox_Id1", c => c.Guid());
            CreateIndex("dbo.Links", "FrontPageBox_Id");
            CreateIndex("dbo.Links", "FrontPageBox_Id1");
            AddForeignKey("dbo.Links", "FrontPageBox_Id", "dbo.FrontPageBoxes", "Id");
            AddForeignKey("dbo.Links", "FrontPageBox_Id1", "dbo.FrontPageBoxes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FrontPageBoxes", "WebsiteLink_Id", "dbo.Links");
            DropForeignKey("dbo.Links", "FrontPageBox_Id1", "dbo.FrontPageBoxes");
            DropForeignKey("dbo.Links", "FrontPageBox_Id", "dbo.FrontPageBoxes");
            DropIndex("dbo.Links", new[] { "FrontPageBox_Id1" });
            DropIndex("dbo.Links", new[] { "FrontPageBox_Id" });
            DropIndex("dbo.FrontPageBoxes", new[] { "WebsiteLink_Id" });
            DropColumn("dbo.Links", "FrontPageBox_Id1");
            DropColumn("dbo.Links", "FrontPageBox_Id");
            DropTable("dbo.FrontPageBoxes");
        }
    }
}
