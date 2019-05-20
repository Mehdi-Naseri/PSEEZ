using System.Web.Mvc;

namespace Pseez.UI.Pmbok.Areas.ProjectTimeManagement
{
    public class ProjectTimeManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ProjectTimeManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ProjectTimeManagement_default",
                "ProjectTimeManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}