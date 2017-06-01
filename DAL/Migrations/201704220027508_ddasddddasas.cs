namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ddasddddasas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionTypes",
                c => new
                    {
                        ActionTypeId = c.Int(nullable: false, identity: true),
                        ActionName = c.String(),
                        ActionDescription = c.String(),
                    })
                .PrimaryKey(t => t.ActionTypeId);
            
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
                .PrimaryKey(t => t.AdminId);
            
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
            
            CreateTable(
                "dbo.AdminRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DriverClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Driver", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Driver",
                c => new
                    {
                        DriverId = c.String(nullable: false, maxLength: 128),
                        PhoneNumber = c.String(maxLength: 8000, unicode: false),
                        Email = c.String(maxLength: 256),
                        CountryCode = c.Long(nullable: false),
                        Photo = c.String(),
                        Name = c.String(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.DriverId)
                .Index(t => t.PhoneNumber, unique: true);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Model = c.String(nullable: false),
                        Color = c.String(nullable: false),
                        Brand = c.String(nullable: false),
                        Licence = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Driver", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.DriverLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Driver", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DriverRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PassengerClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Passenger", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Passenger",
                c => new
                    {
                        PassengerId = c.String(nullable: false, maxLength: 128),
                        PhoneNumber = c.String(maxLength: 8000, unicode: false),
                        Email = c.String(maxLength: 256),
                        CountryCode = c.Long(nullable: false),
                        Photo = c.String(),
                        Name = c.String(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.PassengerId)
                .Index(t => t.PhoneNumber, unique: true);
            
            CreateTable(
                "dbo.PassengerLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Passenger", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PassengerRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdminUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Admin", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AdminRole", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.DriverUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Driver", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.DriverRole", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.PassengerUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Passenger", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.PassengerRole", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PassengerUserRole", "RoleId", "dbo.PassengerRole");
            DropForeignKey("dbo.PassengerUserRole", "UserId", "dbo.Passenger");
            DropForeignKey("dbo.PassengerLogin", "UserId", "dbo.Passenger");
            DropForeignKey("dbo.PassengerClaim", "UserId", "dbo.Passenger");
            DropForeignKey("dbo.DriverUserRole", "RoleId", "dbo.DriverRole");
            DropForeignKey("dbo.DriverUserRole", "UserId", "dbo.Driver");
            DropForeignKey("dbo.DriverLogin", "UserId", "dbo.Driver");
            DropForeignKey("dbo.DriverClaim", "UserId", "dbo.Driver");
            DropForeignKey("dbo.Cars", "Id", "dbo.Driver");
            DropForeignKey("dbo.AdminUserRole", "RoleId", "dbo.AdminRole");
            DropForeignKey("dbo.AdminUserRole", "UserId", "dbo.Admin");
            DropForeignKey("dbo.AdminLogin", "UserId", "dbo.Admin");
            DropForeignKey("dbo.AdminClaim", "UserId", "dbo.Admin");
            DropIndex("dbo.PassengerUserRole", new[] { "RoleId" });
            DropIndex("dbo.PassengerUserRole", new[] { "UserId" });
            DropIndex("dbo.DriverUserRole", new[] { "RoleId" });
            DropIndex("dbo.DriverUserRole", new[] { "UserId" });
            DropIndex("dbo.AdminUserRole", new[] { "RoleId" });
            DropIndex("dbo.AdminUserRole", new[] { "UserId" });
            DropIndex("dbo.PassengerLogin", new[] { "UserId" });
            DropIndex("dbo.Passenger", new[] { "PhoneNumber" });
            DropIndex("dbo.PassengerClaim", new[] { "UserId" });
            DropIndex("dbo.DriverLogin", new[] { "UserId" });
            DropIndex("dbo.Cars", new[] { "Id" });
            DropIndex("dbo.Driver", new[] { "PhoneNumber" });
            DropIndex("dbo.DriverClaim", new[] { "UserId" });
            DropIndex("dbo.AdminLogin", new[] { "UserId" });
            DropIndex("dbo.AdminClaim", new[] { "UserId" });
            DropTable("dbo.PassengerUserRole");
            DropTable("dbo.DriverUserRole");
            DropTable("dbo.AdminUserRole");
            DropTable("dbo.PassengerRole");
            DropTable("dbo.PassengerLogin");
            DropTable("dbo.Passenger");
            DropTable("dbo.PassengerClaim");
            DropTable("dbo.DriverRole");
            DropTable("dbo.DriverLogin");
            DropTable("dbo.Cars");
            DropTable("dbo.Driver");
            DropTable("dbo.DriverClaim");
            DropTable("dbo.AdminRole");
            DropTable("dbo.AdminLogin");
            DropTable("dbo.Admin");
            DropTable("dbo.AdminClaim");
            DropTable("dbo.ActionTypes");
        }
    }
}
