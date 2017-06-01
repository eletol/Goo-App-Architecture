namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DriverStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TripStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.ActionTypes");
        }
        
        public override void Down()
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
            
            DropTable("dbo.TripStatus");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.DriverStatus");
            DropTable("dbo.CarTypes");
        }
    }
}
