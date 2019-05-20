using System.Web.Mvc;

namespace Pseez.UI.Pmbok.Areas.ProjectQualityManagement
{
    public class ProjectQualityManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ProjectQualityManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ProjectQualityManagement_default",
                "ProjectQualityManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}