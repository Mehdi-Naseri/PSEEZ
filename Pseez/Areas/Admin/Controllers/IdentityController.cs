using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

using Pseez.DomainClasses.Models.Identity;
using Pseez.DataLayer.DataContext;

namespace Pseez.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IdentityController : Controller
    {
        //
        // GET: /Admin/Admin/
        public ActionResult Index()
        {
            return View();
        }
        #region Users
        public ActionResult AllUsers()
        {
            //IdentityDbContext IdentityDbContext = new IdentityDbContext();
            //List<IdentityUser> AllUsers = IdentityDbContext.Users.ToList();

            IdentityContext IdentityContext = new IdentityContext();
            List<ApplicationUser> AllUsers = IdentityContext.Users.ToList();
            return View(AllUsers);
        }
        // GET: /Admin/CreateUser
        public ActionResult CreateUser()
        {
            RegisterViewModel RegisterViewModel = new RegisterViewModel();
            return PartialView("_CreateUser", RegisterViewModel);
        }
        // POST: /Admin/CreateUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityContext()));
                //جهت فعال کردن امکان ثبت نام فارسی
                userManager.UserValidator = new UserValidator<ApplicationUser>(userManager) { AllowOnlyAlphanumericUserNames = false };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //return RedirectToAction("AllUsers", "Identity");
                    return Json(new { success = true });
                }
                else
                {
                    AddErrors(result);
                }
            }
            // If we got this far, something failed, redisplay form
            return PartialView("_CreateUser", model);
        }
        // GET: /Admin/EditUser/5
        public ActionResult EditUser(string id = null)
        {
            //IdentityDbContext IdentityDbContext1 = new IdentityDbContext();
            //IdentityUser User1 = IdentityDbContext1.Users.First(x => x.Id == id);

            IdentityContext IdentityContext = new IdentityContext();
            ApplicationUser User1 = IdentityContext.Users.First(x => x.Id == id);
            if (User1 == null)
            {
                return HttpNotFound();
            }
            return PartialView("_EditUser", User1);
        }
        // POST: /Admin/EditUser/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(ApplicationUser User1)
        {
            if (ModelState.IsValid)
            {
                UserManager<ApplicationUser> UserManager1 = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityContext()));
                //جهت فعال کردن امکان ثبت نام فارسی
                UserManager1.UserValidator = new UserValidator<ApplicationUser>(UserManager1) { AllowOnlyAlphanumericUserNames = false };
                if ((UserManager1.FindByName(User1.UserName) == null) ||
                    (UserManager1.FindById(User1.Id).UserName == User1.UserName))
                {
                    IdentityContext IdentityContext1 = new IdentityContext();
                    IdentityContext1.Entry(User1).State = System.Data.Entity.EntityState.Modified;
                    IdentityContext1.SaveChanges();
                    //return RedirectToAction("AllUsers");
                    return Json(new { success = true });
                }
                else
                {
                    ModelState.AddModelError("", "نام" + User1.UserName + "قبلا انتخاب شده است.");
                }
            }
            else
            {
                ModelState.AddModelError("", "داده های وارد شده نامعتبراند");
            }
            return PartialView("_EditUser", User1);
        }
        // GET: /Admin/DeleteUser/5
        public ActionResult DeleteUser(string id = null)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            IdentityContext IdentityContext1 = new IdentityContext();
            IdentityUser User1 = IdentityContext1.Users.First(x => x.Id == id);
            if (User1 == null)
            {
                return HttpNotFound();
            }
            else
            {
                return PartialView("_DeleteUser", User1);
            }
        }
        // POST: /Admin/DeleteUser/5
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUserConfirmed(string id = null)
        {
            try
            {
                IdentityContext IdentityContext1 = new IdentityContext();
                ApplicationUser IdentityUser1 = IdentityContext1.Users.First(x => x.Id == id);
                UserManager<ApplicationUser> UserManager1 = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityContext()));
                foreach (string UserRole1 in UserManager1.GetRoles(id))
                {
                    UserManager1.RemoveFromRole(id, UserRole1);
                }
                foreach (System.Security.Claims.Claim UserClaim1 in UserManager1.GetClaims(id))
                {
                    UserManager1.RemoveClaim(id, UserClaim1);
                }
                foreach (UserLoginInfo UserLoginInfo1 in UserManager1.GetLogins(id))
                {
                    UserManager1.RemoveLogin(id, UserLoginInfo1);
                }
                IdentityContext1.Users.Remove(IdentityUser1);
                IdentityContext1.SaveChanges();
                //return RedirectToAction("AllUsers");
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        //private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        //{
        //    // See http://go.microsoft.com/fwlink/?LinkID=177550 for a full list of status codes.
        //    switch (createStatus)
        //    {
        //        case MembershipCreateStatus.DuplicateUserName:
        //            return "User name already exists. Please enter a different user name.";

        //        case MembershipCreateStatus.DuplicateEmail:
        //            return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

        //        case MembershipCreateStatus.InvalidPassword:
        //            return "The password provided is invalid. Please enter a valid password value.";

        //        case MembershipCreateStatus.InvalidEmail:
        //            return "The e-mail address provided is invalid. Please check the value and try again.";

        //        case MembershipCreateStatus.InvalidAnswer:
        //            return "The password retrieval answer provided is invalid. Please check the value and try again.";

        //        case MembershipCreateStatus.InvalidQuestion:
        //            return "The password retrieval question provided is invalid. Please check the value and try again.";

        //        case MembershipCreateStatus.InvalidUserName:
        //            return "The user name provided is invalid. Please check the value and try again.";

        //        case MembershipCreateStatus.ProviderError:
        //            return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

        //        case MembershipCreateStatus.UserRejected:
        //            return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

        //        default:
        //            return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
        //    }
        //}
        #endregion

        #region Roles
        public ActionResult AllRoles()
        {
            IdentityContext IdentityDbContext = new IdentityContext();
            List<IdentityRole> AllRoles = IdentityDbContext.Roles.ToList();
            return View(AllRoles);
        }
        // GET: /Admin/CreateRole
        public ActionResult CreateRole()
        {
            return PartialView("_CreateRole");
        }
        // POST: /Admin/CreateRole
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRole(string RoleName)
        {
            if (ModelState.IsValid)
            {
                RoleManager<IdentityRole> RoleManager1 = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityContext()));
                bool test = RoleManager1.RoleExists(RoleName);
                if (RoleManager1.RoleExists(RoleName))
                {
                    ModelState.AddModelError("", "گروه جدید قبلا ساخته شده است.");
                }
                else
                {
                    // Attempt to register new role
                    IdentityRole IdentityRoleNew = new IdentityRole(RoleName);
                    var result = await RoleManager1.CreateAsync(IdentityRoleNew);
                    if (result.Succeeded)
                    {
                        //return RedirectToAction("AllRoles");
                        return Json(new { success = true });
                        //جهت دو زبانه شدن اضافه شده است
                        //return RedirectToAction("AllRoles", "Admin", new { culture = "en" });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }
            // If we got this far, something failed, redisplay form
            return PartialView("_CreateRole", RoleName);
        }
        // GET: /Admin/EditRole/5
        public ActionResult EditRole(string id = null)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            IdentityContext IdentityDbContext1 = new IdentityContext();
            IdentityRole Role1 = IdentityDbContext1.Roles.First(x => x.Id == id);
            ViewBag.Role = Role1;
            return PartialView("_EditRole", Role1);
        }
        // POST: /Admin/EditRole/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRole(string id, string Name)
        {
            string RoleNameNew = Name;
            if (ModelState.IsValid)
            {
                RoleManager<IdentityRole> RoleManager1 = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityContext()));
                if (!RoleManager1.RoleExists(RoleNameNew))
                {
                    IdentityContext IdentityDbContext1 = new IdentityContext();
                    IdentityRole Role1 = IdentityDbContext1.Roles.First(x => x.Id == id);
                    Role1.Name = RoleNameNew;
                    IdentityDbContext1.Entry(Role1).State = System.Data.Entity.EntityState.Modified;
                    IdentityDbContext1.SaveChanges();
                    //return RedirectToAction("AllRoles");
                    return Json(new { success = true });
                }
                else
                {
                    ModelState.AddModelError("", "گروه جدید قبلا ساخته شده است.");
                }
            }
            else
            {
                ModelState.AddModelError("", "داده های وارد شده معتبر نیستند.");
            }
            return PartialView("_EditRole", RoleNameNew);
        }
        // GET: /Admin/DeleteRole/5
        public ActionResult DeleteRole(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                IdentityContext IdentityDbContext1 = new IdentityContext();
                IdentityRole Role1 = IdentityDbContext1.Roles.First(x => x.Id == id);
                return PartialView("_DeleteRole", Role1);
            }
        }
        // POST: /Admin/DeleteRole/5
        [HttpPost, ActionName("DeleteRole")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleConfirmed(string id)
        {
            try
            {
                IdentityContext IdentityContext1 = new IdentityContext();
                UserManager<ApplicationUser> UserManager1 = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityContext()));
                IdentityUser IdentityUser1 = new IdentityUser();
                var IdentityUsers = IdentityContext1.Users.Where(u => u.Roles.Any(r => r.RoleId == id));
                foreach (IdentityUser user1 in IdentityUsers)
                {
                    UserManager1.RemoveFromRole(user1.Id, id);
                }
                //RoleManager<IdentityRole> RoleManager1 = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
                IdentityRole IdentityRole1 = new IdentityRole();
                IdentityRole1 = IdentityContext1.Roles.Find(id);
                IdentityContext1.Roles.Remove(IdentityRole1);
                IdentityContext1.SaveChanges();
                //return RedirectToAction("AllRoles");
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return PartialView("_DeleteRole", id);
            }
        }
        #endregion Roles

        #region Users in Roles
        public ActionResult AllUsersInRoles()
        {
            IdentityContext IdentityDbContext1 = new IdentityContext();
            UserManager<ApplicationUser> UserManager1 = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityContext()));
            List<IdentityUserRole> IdentityUserRoles = new List<IdentityUserRole>();
            List<ApplicationUser> ApplicationUsers = IdentityDbContext1.Users.ToList();
            foreach (IdentityUser IdentityUser1 in ApplicationUsers)
            {
                foreach (string RoleName in UserManager1.GetRoles(IdentityUser1.Id))
                {
                    IdentityUserRole IdentityUserRole1 = new IdentityUserRole();
                    IdentityUserRole1.UserId = IdentityUser1.Id;
                    IdentityUserRole1.User = IdentityDbContext1.Users.First(r => r.Id == IdentityUser1.Id);
                    IdentityUserRole1.RoleId = IdentityDbContext1.Roles.First(r => r.Name == RoleName).Id;
                    IdentityUserRole1.Role = IdentityDbContext1.Roles.First(r => r.Name == RoleName);
                    IdentityUserRoles.Add(IdentityUserRole1);
                }
            }
            return View(IdentityUserRoles);
        }
        public ActionResult AddUserInRole()
        {
            IdentityContext IdentityDbContext1 = new IdentityContext();
            //ساخت لیستی از نام یوزرها
            List<ApplicationUser> AllUsers = IdentityDbContext1.Users.ToList();
            List<string> AllUserNames = new List<string> { };
            foreach (ApplicationUser IdentityUser1 in AllUsers)
            {
                AllUserNames.Add(IdentityUser1.UserName);
            }
            ViewBag.UserNames = AllUserNames;
            //ساخت لیستی از نام رولها
            List<IdentityRole> AllRoles = IdentityDbContext1.Roles.ToList();
            List<string> AllRoleNames = new List<string> { };
            foreach (IdentityRole IdentityRole1 in AllRoles)
            {
                AllRoleNames.Add(IdentityRole1.Name);
            }
            ViewBag.RoleNames = AllRoleNames;
            return PartialView("_AddUserInRole");
        }
        [HttpPost]
        public ActionResult AddUserInRole(string User1, string Role1)
        {
            try
            {
                IdentityContext IdentityDbContext1 = new IdentityContext();
                string IdentityUserId = IdentityDbContext1.Users.First(x => x.UserName == User1).Id;
                UserManager<ApplicationUser> UserManager1 = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityContext()));
                UserManager1.AddToRole(IdentityUserId, Role1);
                //return RedirectToAction("AllUsersInRoles");
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return PartialView("_AddUserInRole");
            }
        }
        public ActionResult DeleteUserInRole(string UserName, string RoleName)
        {
            ViewBag.RoleName1 = RoleName;
            ViewBag.UserName1 = UserName;
            if (UserName == null || RoleName == null)
            {
                return HttpNotFound();
            }
            else
            {
                return PartialView("_DeleteUserInRole");
            }
        }
        // POST: /Admin/DeleteRole/5
        [HttpPost, ActionName("DeleteUserInRole")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUserInRoleConfirmed(string UserName, string RoleName)
        {
            try
            {
                IdentityContext IdentityDbContext1 = new IdentityContext();
                string UserId = IdentityDbContext1.Users.First(r => r.UserName == UserName).Id;
                UserManager<ApplicationUser> UserManager1 = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityContext()));
                UserManager1.RemoveFromRole(UserId, RoleName);
                //return RedirectToAction("AllUsersInRoles");
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return PartialView("_DeleteUserInRole");
            }
        }
        #endregion

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}