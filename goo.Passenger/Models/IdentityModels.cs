using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace goo.Passenger.Models
{
    // You can add profile data for the user by adding more properties to your Passenger class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class Passenger : IdentityUser
    {
      
        public override string PhoneNumber
        {
            get { return base.PhoneNumber; }
            set { base.PhoneNumber = value; }
        }
        [Required]
        public string Name { get; set; }
        public long CountryCode { get; set; }
        public string Photo { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Passenger> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<Passenger>
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
            modelBuilder.Entity<Passenger>()
                .ToTable("Passenger", "dbo").Property(p => p.Id).HasColumnName("PassengerId");

            modelBuilder.Entity<IdentityRole>().ToTable("PassengerRole");
            modelBuilder.Entity<IdentityUserRole>().ToTable("PassengerUserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("PassengerClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("PassengerLogin");
        }
    }
}