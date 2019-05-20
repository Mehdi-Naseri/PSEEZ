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
    internal class SeedCmms
    {
        private readonly PseezEntDbContext _pseezEntDbContext = new PseezEntDbContext();

        public void AddRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_pseezEntDbContext));
            string[] roleNames = {"AdminCmms"};
            foreach (var roleName in roleNames)
            {
                if (roleManager.FindByName(roleName) == null)
                {
                    var identityRole = new IdentityRole(roleName);
                    roleManager.Create(identityRole);
                }
            }


            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_pseezEntDbContext));
            //Create User "Admin" if it is not existed.
            if (userManager.FindByName("AdminCmms") == null)
            {
                var user = new ApplicationUser { UserName = "AdminCmms" /*, Email = "Admin@Pseez.ir"*/};
                userManager.Create(user, "AdminCmms");
                //userManager.Create(user, "Visit-Pseez#1");
            }
            //Add Admin user to Admin Role
            var identityUserId = _pseezEntDbContext.Users.First(x => x.UserName == "AdminCmms").Id;
            userManager.AddToRole(identityUserId, "AdminCmms");
        }
    }
}