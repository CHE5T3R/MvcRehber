namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class password2nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.users", "passwordControl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.users", "passwordControl", c => c.String());
        }
    }
}
