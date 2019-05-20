using System.Web.Mvc;
using Pseez.ServiceLayer.Interfaces.PseezEnt.HumanResource;

namespace Pseez.UI.HumanResource.Areas.PersonnelReports.Controllers
{
    public class FlightPassengersController : Controller
    {
        private readonly IFlightPassengersService _flightPassengersService;

        public FlightPassengersController(IFlightPassengersService flightPassengersService)
        {
            _flightPassengersService = flightPassengersService;
        }

        //
        // GET: /PersonnelReports/FlightPassengers/
        //public ActionResult Index()
        //{
        //}

        // GET: /PersonnelReports/FlightPassengers/Show/
        public ActionResult Show(int id)
        {
            ViewBag.TimeTable = id;
            return View();
        }

        [HttpGet]
        public ActionResult Read(int TimeTable)
        {
            var result = _flightPassengersService.GetAllPassengersinFlight(TimeTable);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}