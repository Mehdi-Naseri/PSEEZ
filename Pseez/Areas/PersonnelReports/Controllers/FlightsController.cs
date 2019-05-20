using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pseez.DataLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.PseezEnt.PersonnelReports;
using Pseez.Model.ViewModels.PseezEnt.PersonnelReports;

namespace Pseez.Areas.PersonnelReports.Controllers
{
    public class FlightsController : Controller
    {
        private IFlightsService _flightListService;
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