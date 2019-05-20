using System.Web.Mvc;

namespace Pseez.UI.Pmbok.Areas.ProjectProcurementManagement
{
    public class ProjectProcurementManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ProjectProcurementManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ProjectProcurementManagement_default",
                "ProjectProcurementManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}