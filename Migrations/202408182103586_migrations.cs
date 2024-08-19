namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.rehbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        surname = c.String(),
                        phoneNumber = c.String(nullable: false),
                        email = c.String(),
                        adres = c.String(),
                        sehirId = c.Int(),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.sehirs", t => t.sehirId, cascadeDelete: true)
                .ForeignKey("dbo.users", t => t.userId, cascadeDelete: true)
                .Index(t => t.sehirId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.sehirs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        sehirName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userName = c.String(nullable: false),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.rehbers", "userId", "dbo.users");
            DropForeignKey("dbo.rehbers", "sehirId", "dbo.sehirs");
            DropIndex("dbo.rehbers", new[] { "userId" });
            DropIndex("dbo.rehbers", new[] { "sehirId" });
            DropTable("dbo.users");
            DropTable("dbo.sehirs");
            DropTable("dbo.rehbers");
        }
    }
}
