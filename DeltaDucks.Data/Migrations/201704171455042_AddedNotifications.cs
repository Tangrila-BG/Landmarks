namespace DeltaDucks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNotifications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsersNotifications",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        NotificationId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.NotificationId })
                .ForeignKey("dbo.Notifications", t => t.NotificationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.NotificationId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        LandmarkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Landmarks", t => t.LandmarkId, cascadeDelete: true)
                .Index(t => t.LandmarkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersNotifications", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersNotifications", "NotificationId", "dbo.Notifications");
            DropForeignKey("dbo.Notifications", "LandmarkId", "dbo.Landmarks");
            DropIndex("dbo.Notifications", new[] { "LandmarkId" });
            DropIndex("dbo.UsersNotifications", new[] { "NotificationId" });
            DropIndex("dbo.UsersNotifications", new[] { "UserId" });
            DropTable("dbo.Notifications");
            DropTable("dbo.UsersNotifications");
        }
    }
}
