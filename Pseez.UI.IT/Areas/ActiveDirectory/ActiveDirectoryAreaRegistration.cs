using System.Web.Mvc;

namespace Pseez.UI.IT.Areas.ActiveDirectory
{
    public class ActiveDirectoryAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "ActiveDirectory"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ActiveDirectory_default",
                "ActiveDirectory/{controller}/{action}/{id}",
                new {action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}