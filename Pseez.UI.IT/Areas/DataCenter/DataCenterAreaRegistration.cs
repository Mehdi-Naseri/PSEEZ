using System.Web.Mvc;

namespace Pseez.UI.IT.Areas.DataCenter
{
    public class DataCenterAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "DataCenter"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DataCenter_default",
                "DataCenter/{controller}/{action}/{id}",
                new {action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}