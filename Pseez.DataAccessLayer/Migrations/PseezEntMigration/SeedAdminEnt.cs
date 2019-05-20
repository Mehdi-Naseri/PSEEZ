using System.Linq;
using Identity.Models.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pseez.DataAccessLayer.DataContext;
//جهت فعال سازی و دسترسی به بخش اکانت
//using Pseez.VisitRegistration.DomainClasses.Models.Identity;

//جهت ارتباط با پایگاه داده

namespace Pseez.DataAccessLayer.Migrations.PseezEntMigration
{
    internal class SeedAdminEnt
    {
        private readonly PseezEntDbContext _pseezEntDbContext = new PseezEntDbContext();

        public void CreateAdminEnterpriseUserAndRole()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_pseezEntDbContext));
            //Create User "Admin" if it is not existed.
            if (userManager.FindByName("AdminEnt") == null)
            {
                var user = new ApplicationUser {UserName = "AdminEnt" /*, Email = "Admin@Pseez.ir"*/};
                userManager.Create(user, "Pass#1");
                //userManager.Create(user, "Visit-Pseez#1");
            }
            //Create Role "Admin" if it is not existed.
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_pseezEntDbContext));
            if (roleManager.FindByName("AdminEnt") == null)
            {
                var identityRole = new IdentityRole("AdminEnt");
                roleManager.Create(identityRole);
            }
            //Add Admin user to Admin Role
            var identityUserId = _pseezEntDbContext.Users.First(x => x.UserName == "AdminEnt").Id;
            userManager.AddToRole(identityUserId, "AdminEnt");
        }

    }
}