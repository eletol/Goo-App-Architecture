using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using goo.Passenger.Models;
using SMSIntegration;
using Twilio;

namespace goo.Passenger
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<Models.Passenger>
    {
        public ApplicationUserManager(IUserStore<Models.Passenger> store)
            : base(store)
        {
        }

        public Models.Passenger FindByPhoneNumber(string phone)
        {
            using (ApplicationDbContext db =new ApplicationDbContext())
            {
               return db.Users.FirstOrDefault(s => s.PhoneNumber == phone);
            }
        }
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<Models.Passenger>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<Models.Passenger>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<Models.Passenger>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<Models.Passenger>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.SmsService = new SmsService();
            return manager; 
        }
    }
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            var appRoleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));

            return appRoleManager;
        }
    }
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {

           // SMSIntegration.Twilio.Twilio.SendAsync(message.Destination, message.Body);
            return Task.FromResult(0);

        }
    }
}
