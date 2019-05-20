using System.Web.Mvc;

namespace Pseez.UI.Pmbok.Areas.ProjectCostManagement
{
    public class ProjectCostManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ProjectCostManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ProjectCostManagement_default",
                "ProjectCostManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}