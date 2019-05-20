using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Net.NetworkInformation;
using System.Web.Mvc;
using Pseez.ViewModels.ViewModels.PseezEnt.IT;

namespace Pseez.UI.IT.Areas.ActiveDirectory.Controllers
{
    public class ActiveDirectoryUsersController : Controller
    {
        //
        // GET: /DataCenter/ActiveDirectoryUsers/
        public ActionResult Index()
        {
            string DomainName = null, ErrorMessage = null;
            try
            {
                DomainName = IPGlobalProperties.GetIPGlobalProperties().DomainName;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            ErrorMessage += (DomainName == null || DomainName == "")
                ? "دسترسی به سرور اکتیو دایرکتوری امکان پذیر نشد."
                : null;
            ViewBag.ErrorMessage = ErrorMessage;

            ViewBag.DomainName = DomainName;
            ViewBag.Container = "dc=pseez,dc=local";
            return View();
        }

        [HttpGet]
        public ActionResult Read(string DomainName, string Container)
        {
            string error;
            var a = ShowUsers(DomainName, Container, out error);
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<ActiveDirectoryUserViewModel> ShowUsers(string DomainName, string Container,
            out string error)
        {
            IList<ActiveDirectoryUserViewModel> users = new List<ActiveDirectoryUserViewModel>();
            try
            {
                //string stringDomainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;

                //Check password
                //Boolean boolPass;
                //Check groups
                //Boolean boolGroup;
                var intCounter = 0;
                var PrincipalContext1 = new PrincipalContext(ContextType.Domain, DomainName, Container);
                var UserPrincipal1 = new UserPrincipal(PrincipalContext1);
                var search = new PrincipalSearcher(UserPrincipal1);

                foreach (UserPrincipal result in search.FindAll())
                {
                    //Check criteria
                    //boolPass = false;
                    //boolGroup = false;
                    //Check default pass
                    //if (checkBoxPass.IsChecked == true)
                    //{
                    //    if (PrincipalContext1.ValidateCredentials(result.SamAccountName, PasswordBoxPass.Password))
                    //    {
                    //        boolPass = true;
                    //    }
                    //    else
                    //    {
                    //        boolPass = false;
                    //    }
                    //}
                    //else
                    //{
                    //    boolPass = true;
                    //}
                    //boolPass = true;
                    //Check group
                    //if (comboBoxGroups.SelectedIndex >= 0)
                    //{
                    //    PrincipalSearchResult<Principal> PrincipalSearchResults1 = result.GetGroups();
                    //    foreach (Principal PrincipalSearchResult1 in PrincipalSearchResults1)
                    //    {
                    //        if (PrincipalSearchResult1.Name == comboBoxGroups.SelectedValue.ToString())
                    //        {
                    //            boolGroup = true;
                    //            break;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    boolGroup = true;
                    //}
                    //Add user
                    //if (boolPass && boolGroup)
                    {
                        //ActiveDirectoryUserViewModel User1 = new User(result.SamAccountName, result.DisplayName, result.Name, result.GivenName, result.Surname,
                        //   result.Description, result.Enabled, result.LastLogon);
                        //Users1.Add(User1);
                        var User1 = new ActiveDirectoryUserViewModel();
                        User1.SamAccountName = result.SamAccountName;
                        User1.DisplayName = result.DisplayName;
                        User1.Name = result.Name;
                        User1.GivenName = result.GivenName;
                        User1.Surname = result.Surname;
                        User1.Description = result.Description;
                        User1.Enabled = result.Enabled;
                        User1.LastLogon = result.LastLogon.HasValue
                            ? ((DateTime) result.LastLogon).ToString("yyyy/MM/dd HH:mm:ss")
                            : null;
                        intCounter++;
                        users.Add(User1);
                    }
                }
                search.Dispose();
                error = null;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return users;
        }
    }
}