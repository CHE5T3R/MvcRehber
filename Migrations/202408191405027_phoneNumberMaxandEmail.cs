namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phoneNumberMaxandEmail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.rehbers", "phoneNumber", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.rehbers", "phoneNumber", c => c.String());
        }
    }
}
