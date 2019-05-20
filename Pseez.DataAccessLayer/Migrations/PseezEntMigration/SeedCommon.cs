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
    internal class SeedCommon
    {
        private readonly PseezEntDbContext _pseezEntDbContext = new PseezEntDbContext();

        public void AddRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_pseezEntDbContext));
            string[] roleNames = {"AdminIdentity", "AdminCommon", "AdminContacts", "UserReadContacts"};
            foreach (var roleName in roleNames)
            {
                if (roleManager.FindByName(roleName) == null)
                {
                    var identityRole = new IdentityRole(roleName);
                    roleManager.Create(identityRole);
                }
            }
        }
    }
}