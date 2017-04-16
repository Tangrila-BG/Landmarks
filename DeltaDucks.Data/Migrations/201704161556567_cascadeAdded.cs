namespace DeltaDucks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadeAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "LandmarkId", "dbo.Landmarks");
            DropForeignKey("dbo.Pictures", "LandmarkId", "dbo.Landmarks");
            DropIndex("dbo.Comments", new[] { "LandmarkId" });
            DropIndex("dbo.Pictures", new[] { "LandmarkId" });
            AlterColumn("dbo.Comments", "LandmarkId", c => c.Int(nullable: false));
            AlterColumn("dbo.Pictures", "LandmarkId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "LandmarkId");
            CreateIndex("dbo.Pictures", "LandmarkId");
            AddForeignKey("dbo.Comments", "LandmarkId", "dbo.Landmarks", "LandmarkId", cascadeDelete: true);
            AddForeignKey("dbo.Pictures", "LandmarkId", "dbo.Landmarks", "LandmarkId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "LandmarkId", "dbo.Landmarks");
            DropForeignKey("dbo.Comments", "LandmarkId", "dbo.Landmarks");
            DropIndex("dbo.Pictures", new[] { "LandmarkId" });
            DropIndex("dbo.Comments", new[] { "LandmarkId" });
            AlterColumn("dbo.Pictures", "LandmarkId", c => c.Int());
            AlterColumn("dbo.Comments", "LandmarkId", c => c.Int());
            CreateIndex("dbo.Pictures", "LandmarkId");
            CreateIndex("dbo.Comments", "LandmarkId");
            AddForeignKey("dbo.Pictures", "LandmarkId", "dbo.Landmarks", "LandmarkId");
            AddForeignKey("dbo.Comments", "LandmarkId", "dbo.Landmarks", "LandmarkId");
        }
    }
}
