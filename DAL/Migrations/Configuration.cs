using DAL.Models;
using DAL.DataSeed;

namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DBContext.DbGooContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.DBContext.DbGooContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            DataSeed.DataSeed.Load();

            context.AdminRoles.AddOrUpdate(
              new AdminRole() { Name = "Admin",Id = Guid.NewGuid().ToString()}
            );
            context.DriverRoles.AddOrUpdate(
            new DriverRole() { Name = "Driver", Id = Guid.NewGuid().ToString() }
          );
            context.PassengerRoles.AddOrUpdate(
            new PassengerRole() { Name = "Passenger" ,Id = Guid.NewGuid().ToString() }
          );
        }
    }
}
