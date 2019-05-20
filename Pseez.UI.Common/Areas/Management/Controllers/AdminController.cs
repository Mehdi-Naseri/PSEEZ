using System.Web.Mvc;

namespace Pseez.UI.Common.Areas.Management.Controllers
{
    [Authorize(Roles = "AdminEnt,AdminIdentity")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/Admin/
        public ActionResult Index()
        {
            return View();
        }
    }
}