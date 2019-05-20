using System.Web.Mvc;
using Pseez.ServiceLayer.Interfaces.PseezEnt.HumanResource;

namespace Pseez.UI.HumanResource.Areas.PersonnelReports.Controllers
{
    public class FlightsController : Controller
    {
        private readonly IFlightsService _flightListService;

        public FlightsController(IFlightsService flightListService)
        {
            _flightListService = flightListService;
        }

        //
        // GET: /PersonnelReports/Flight/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read(string year, string month)
        {
            var result = _flightListService.GetInMonth(year, month);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}