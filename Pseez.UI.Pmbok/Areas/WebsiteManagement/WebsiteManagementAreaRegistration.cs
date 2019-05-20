using System.Web.Mvc;

namespace Pseez.UI.Pmbok.Areas.WebsiteManagement
{
    public class WebsiteManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WebsiteManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WebsiteManagement_default",
                "WebsiteManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}