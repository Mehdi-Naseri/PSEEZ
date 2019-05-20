using System.Web.Mvc;

namespace Pseez.UI.Pmbok.Areas.ProjectCommunicationsManagement
{
    public class ProjectCommunicationsManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ProjectCommunicationsManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ProjectCommunicationsManagement_default",
                "ProjectCommunicationsManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}