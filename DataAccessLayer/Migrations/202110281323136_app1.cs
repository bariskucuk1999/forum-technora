namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class app1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logins", "Password", c => c.String(maxLength: 16));
            DropColumn("dbo.Users", "UserImage");
            DropColumn("dbo.Logins", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logins", "UserName", c => c.String(maxLength: 16));
            AddColumn("dbo.Users", "UserImage", c => c.String(maxLength: 100));
            AlterColumn("dbo.Logins", "Password", c => c.String(maxLength: 20));
        }
    }
}
