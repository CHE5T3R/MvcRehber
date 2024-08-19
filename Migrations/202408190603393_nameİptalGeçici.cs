namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameİptalGeçici : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.rehbers", "userId", "dbo.users");
            DropIndex("dbo.rehbers", new[] { "userId" });
            DropColumn("dbo.rehbers", "userId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.rehbers", "userId", c => c.Int(nullable: false));
            CreateIndex("dbo.rehbers", "userId");
            AddForeignKey("dbo.rehbers", "userId", "dbo.users", "Id", cascadeDelete: true);
        }
    }
}
