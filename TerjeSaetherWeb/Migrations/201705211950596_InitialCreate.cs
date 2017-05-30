namespace TerjeSaetherWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        BlogPostId = c.Guid(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BlogPostId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Releases",
                c => new
                    {
                        ReleaseId = c.Guid(nullable: false),
                        Title = c.String(),
                        Releasedate = c.DateTime(nullable: false),
                        CoverImage = c.Binary(),
                    })
                .PrimaryKey(t => t.ReleaseId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongId = c.Guid(nullable: false),
                        Title = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        AudioUrl = c.String(),
                        Release_ReleaseId = c.Guid(),
                    })
                .PrimaryKey(t => t.SongId)
                .ForeignKey("dbo.Releases", t => t.Release_ReleaseId)
                .Index(t => t.Release_ReleaseId);
            
            CreateTable(
                "dbo.SongToReleases",
                c => new
                    {
                        SongToReleaseId = c.Int(nullable: false, identity: true),
                        SongId = c.Int(nullable: false),
                        ReleaseId = c.Int(nullable: false),
                        Release_ReleaseId = c.Guid(),
                        Song_SongId = c.Guid(),
                    })
                .PrimaryKey(t => t.SongToReleaseId)
                .ForeignKey("dbo.Releases", t => t.Release_ReleaseId)
                .ForeignKey("dbo.Songs", t => t.Song_SongId)
                .Index(t => t.Release_ReleaseId)
                .Index(t => t.Song_SongId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Songs", "Release_ReleaseId", "dbo.Releases");
            DropForeignKey("dbo.SongToReleases", "Song_SongId", "dbo.Songs");
            DropForeignKey("dbo.SongToReleases", "Release_ReleaseId", "dbo.Releases");
            DropForeignKey("dbo.BlogPosts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SongToReleases", new[] { "Song_SongId" });
            DropIndex("dbo.SongToReleases", new[] { "Release_ReleaseId" });
            DropIndex("dbo.Songs", new[] { "Release_ReleaseId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.BlogPosts", new[] { "User_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SongToReleases");
            DropTable("dbo.Songs");
            DropTable("dbo.Releases");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.BlogPosts");
        }
    }
}
