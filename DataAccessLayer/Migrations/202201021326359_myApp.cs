namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myApp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Comments", new[] { "CategoryID" });
            DropColumn("dbo.Comments", "CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "CategoryID");
            AddForeignKey("dbo.Comments", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
        }
    }
}
