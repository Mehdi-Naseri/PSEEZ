using System.Web.Mvc;

namespace Pseez.UI.Pmbok.Areas.ProjectStakeholderManagement
{
    public class ProjectStakeholderManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ProjectStakeholderManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ProjectStakeholderManagement_default",
                "ProjectStakeholderManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}