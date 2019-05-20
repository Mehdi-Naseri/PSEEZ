using System.Web.Mvc;

namespace Pseez.UI.Cmms.Areas.PM
{
    public class PMAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PM";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PM_default",
                "PM/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}