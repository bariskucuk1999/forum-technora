namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class app01 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Logins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        LoginID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(maxLength: 16),
                    })
                .PrimaryKey(t => t.LoginID);
            
        }
    }
}
