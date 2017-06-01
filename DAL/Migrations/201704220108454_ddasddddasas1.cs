namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ddasddddasas1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Driver", new[] { "PhoneNumber" });
            DropIndex("dbo.Passenger", new[] { "PhoneNumber" });
            AlterColumn("dbo.Driver", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Passenger", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Passenger", "PhoneNumber", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Driver", "PhoneNumber", c => c.String(maxLength: 8000, unicode: false));
            CreateIndex("dbo.Passenger", "PhoneNumber", unique: true);
            CreateIndex("dbo.Driver", "PhoneNumber", unique: true);
        }
    }
}
