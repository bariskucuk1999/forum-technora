namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class app1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "NickName", c => c.String(maxLength: 16));
            DropColumn("dbo.Posts", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "UserName", c => c.String(maxLength: 20));
            DropColumn("dbo.Posts", "NickName");
        }
    }
}
