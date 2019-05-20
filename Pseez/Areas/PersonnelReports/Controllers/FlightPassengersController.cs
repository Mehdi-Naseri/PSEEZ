using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pseez.DataAccesLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.PseezEnt.PersonnelReports;
using Pseez.Model.ViewModels.PseezEnt.PersonnelReports;

namespace Pseez.Areas.PersonnelReports.Controllers
{
    public class FlightPassengersController : Controller
    {
        private IFlightPassengersService _flightPassengersService;
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