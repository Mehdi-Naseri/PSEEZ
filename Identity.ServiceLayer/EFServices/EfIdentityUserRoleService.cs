using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Models.Models;
using Identity.ServiceLayer.Interfaces;
using Identity.ViewModels.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pseez.DataAccessLayer.DataContext;

namespace Identity.ServiceLayer.EFServices
{
    public class EfIdentityUserRoleService : IIdentityUserRoleService
    {
        private readonly PseezEntDbContext _dbContext = new PseezEntDbContext();


        public IEnumerable<UserRoleViewModel> GetAllUsersRoles()
        {
            var userRoleViewModels = new List<UserRoleViewModel>();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_dbContext));
            var applicationUsers = userManager.Users.ToList();
            foreach (var applicationUser in applicationUsers)
            {
                foreach (var roleName in userManager.GetRoles(applicationUser.Id))
                {
                    var userRoleViewModel = new UserRoleViewModel();
                    userRoleViewModel.UserName = applicationUser.UserName;
                    userRoleViewModel.RoleName = roleName;
                    userRoleViewModels.Add(userRoleViewModel);
                }
            }
            return userRoleViewModels;
        }

        public async Task<IdentityResult> AddUserRole(string userName, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_dbContext));
            var userId = userManager.FindByNameAsync(userName).Result.Id;
            var result = await userManager.AddToRoleAsync(userId, roleName);
            return result;
        }

        public async Task<IdentityResult> DeleteUserRole(string userName, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_dbContext));
            var userId = userManager.FindByNameAsync(userName).Result.Id;
            var result = await userManager.RemoveFromRoleAsync(userId, roleName);
            return result;
        }

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}