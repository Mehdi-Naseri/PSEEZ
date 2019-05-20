using System.Web.Mvc;

namespace Pseez.UI.Common.Areas.ContactList
{
    public class ContactListAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "ContactList"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ContactList_default",
                "ContactList/{controller}/{action}/{id}",
                new {action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}