using System.Web.Mvc;

namespace Pseez.UI.Pmbok.Areas.ProjectScopeManagement
{
    public class ProjectScopeManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ProjectScopeManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ProjectScopeManagement_default",
                "ProjectScopeManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}