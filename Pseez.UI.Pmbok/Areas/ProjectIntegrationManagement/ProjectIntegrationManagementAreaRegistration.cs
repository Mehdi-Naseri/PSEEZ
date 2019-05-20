using System.Web.Mvc;

namespace Pseez.UI.Pmbok.Areas.ProjectIntegrationManagement
{
    public class ProjectIntegrationManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ProjectIntegrationManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ProjectIntegrationManagement_default",
                "ProjectIntegrationManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}