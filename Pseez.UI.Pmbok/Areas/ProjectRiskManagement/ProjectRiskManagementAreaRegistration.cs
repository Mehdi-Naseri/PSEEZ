using System.Web.Mvc;

namespace Pseez.UI.Pmbok.Areas.ProjectRiskManagement
{
    public class ProjectRiskManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ProjectRiskManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ProjectRiskManagement_default",
                "ProjectRiskManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}