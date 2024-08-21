namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.rehbers", "name", c => c.String(nullable: false));
            AlterColumn("dbo.rehbers", "phoneNumber", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.users", "userName", c => c.String(nullable: false));
            AlterColumn("dbo.users", "password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.users", "password", c => c.String());
            AlterColumn("dbo.users", "userName", c => c.String());
            AlterColumn("dbo.rehbers", "phoneNumber", c => c.String(maxLength: 10));
            AlterColumn("dbo.rehbers", "name", c => c.String());
        }
    }
}
