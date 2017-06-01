using DAL.DBContext;
using DAL.Models;

namespace DAL.DBContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbGooContext : DbContext, IDbContext
    {
        public DbGooContext()
            : base("name=DbGooContext")
        {
            this.Configuration.LazyLoadingEnabled = false;

        }

        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<TripStatus> TripStatuses { get; set; }
        public virtual DbSet<DriverStatus> DriverStatuses { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AdminClaim> AdminClaims { get; set; }
        public virtual DbSet<AdminLogin> AdminLogins { get; set; }
        public virtual DbSet<AdminRole> AdminRoles { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriverClaim> DriverClaims { get; set; }
        public virtual DbSet<DriverLogin> DriverLogins { get; set; }
        public virtual DbSet<DriverRole> DriverRoles { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<PassengerClaim> PassengerClaims { get; set; }
        public virtual DbSet<PassengerLogin> PassengerLogins { get; set; }
        public virtual DbSet<PassengerRole> PassengerRoles { get; set; }
        public virtual DbSet<PassengerDevice> PassengerDevices { get; set; }
        public virtual DbSet<DriverDevice> DriverDevices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasMany(e => e.AdminClaims)
                .WithRequired(e => e.Admin)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Admin>()
                .HasMany(e => e.AdminLogins)
                .WithRequired(e => e.Admin)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Admin>()
                .HasMany(e => e.AdminRoles)
                .WithMany(e => e.Admins)
                .Map(m => m.ToTable("AdminUserRole").MapLeftKey("UserId").MapRightKey("RoleId"));

            modelBuilder.Entity<Driver>()
                .HasMany(e => e.DriverClaims)
                .WithRequired(e => e.Driver)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Driver>()
                .HasMany(e => e.DriverLogins)
                .WithRequired(e => e.Driver)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Driver>()
                .HasMany(e => e.DriverRoles)
                .WithMany(e => e.Drivers)
                .Map(m => m.ToTable("DriverUserRole").MapLeftKey("UserId").MapRightKey("RoleId"));

            modelBuilder.Entity<Passenger>()
                .HasMany(e => e.PassengerClaims)
                .WithRequired(e => e.Passenger)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Passenger>()
                .HasMany(e => e.PassengerLogins)
                .WithRequired(e => e.Passenger)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Passenger>()
                .HasMany(e => e.PassengerRoles)
                .WithMany(e => e.Passengers)
                .Map(m => m.ToTable("PassengerUserRole").MapLeftKey("UserId").MapRightKey("RoleId"));
        }
    }
}
