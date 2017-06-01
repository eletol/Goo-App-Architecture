namespace goo.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AdminUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AdminRole", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Admin", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminId = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.AdminId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AdminClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admin", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AdminLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Admin", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdminUserRole", "UserId", "dbo.Admin");
            DropForeignKey("dbo.AdminLogin", "UserId", "dbo.Admin");
            DropForeignKey("dbo.AdminClaim", "UserId", "dbo.Admin");
            DropForeignKey("dbo.AdminUserRole", "RoleId", "dbo.AdminRole");
            DropIndex("dbo.AdminLogin", new[] { "UserId" });
            DropIndex("dbo.AdminClaim", new[] { "UserId" });
            DropIndex("dbo.Admin", "UserNameIndex");
            DropIndex("dbo.AdminUserRole", new[] { "RoleId" });
            DropIndex("dbo.AdminUserRole", new[] { "UserId" });
            DropIndex("dbo.AdminRole", "RoleNameIndex");
            DropTable("dbo.AdminLogin");
            DropTable("dbo.AdminClaim");
            DropTable("dbo.Admin");
            DropTable("dbo.AdminUserRole");
            DropTable("dbo.AdminRole");
        }
    }
}
