using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace goo.Driver.Models
{
    // You can add profile data for the user by adding more properties to your Driver class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class Driver : IdentityUser
    {
    
        public Car Car { get; set; }

        public long CountryCode { get; set; }

        public string Photo { get; set; }

        [Required]
        public string Name { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Driver> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<Driver>
    {
        public ApplicationDbContext()
            : base("DbGooContext", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Driver>()
                .ToTable("Driver", "dbo").Property(p => p.Id).HasColumnName("DriverId");

            modelBuilder.Entity<IdentityRole>().ToTable("DriverRole");
            modelBuilder.Entity<IdentityUserRole>().ToTable("DriverUserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("DriverClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("DriverLogin");
        }
    }
}