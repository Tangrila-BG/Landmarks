namespace DeltaDucks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumberUniqueConstraint : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Landmarks", "Number", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Landmarks", new[] { "Number" });
        }
    }
}
