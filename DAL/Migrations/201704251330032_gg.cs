namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DriverDevices",
                c => new
                    {
                        DeviceId = c.String(nullable: false, maxLength: 128),
                        DriverId = c.String(maxLength: 128),
                        OSType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DeviceId)
                .ForeignKey("dbo.Driver", t => t.DriverId)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.PassengerDevices",
                c => new
                    {
                        DeviceId = c.String(nullable: false, maxLength: 128),
                        PassengerId = c.String(maxLength: 128),
                        OSType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DeviceId)
                .ForeignKey("dbo.Passenger", t => t.PassengerId)
                .Index(t => t.PassengerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PassengerDevices", "PassengerId", "dbo.Passenger");
            DropForeignKey("dbo.DriverDevices", "DriverId", "dbo.Driver");
            DropIndex("dbo.PassengerDevices", new[] { "PassengerId" });
            DropIndex("dbo.DriverDevices", new[] { "DriverId" });
            DropTable("dbo.PassengerDevices");
            DropTable("dbo.DriverDevices");
        }
    }
}
