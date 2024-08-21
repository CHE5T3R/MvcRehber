namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class password2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "passwordControl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.users", "passwordControl");
        }
    }
}
