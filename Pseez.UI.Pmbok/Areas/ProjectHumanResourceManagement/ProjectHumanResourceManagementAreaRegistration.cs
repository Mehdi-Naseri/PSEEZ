using System.Web.Mvc;

namespace Pseez.UI.Pmbok.Areas.ProjectHumanResourceManagement
{
    public class ProjectHumanResourceManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ProjectHumanResourceManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ProjectHumanResourceManagement_default",
                "ProjectHumanResourceManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}