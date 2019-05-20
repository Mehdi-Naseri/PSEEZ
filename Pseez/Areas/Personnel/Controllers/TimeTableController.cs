using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//using Pseez.DataLayer.DataContext;
using Pseez.DataLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.Sts.Journey;
//using Pseez.DomainClasses.Models.Sts;
using Pseez.Model.ViewModels.Sts.Journey;
using Pseez.Model.MapperConfigure.Extention.Sts;

namespace Pseez.Areas.Personnel.Controllers
{
    public class TimeTableController : Controller
    {
        private ITimeTableService _timeTableService;
        private IUnitOfWorkSts _uow;

        public TimeTableController(IUnitOfWorkSts uow, ITimeTableService timeTableService)
        {
            _timeTableService = timeTableService;
            _uow = uow;
        }
        //
        // GET: /Personnel/TimeTable/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read(string Year, string Month)
        {
            //string stringDateFilter = Year.ToString() + "/" + Month.ToString("D2");
            string stringDateFilter = Year + "/" + Month;
            //StsContext db = new StsContext();
            //db.Configuration.ProxyCreationEnabled = false;
            //var a = db.TimeTables.Where(r => r.Date.StartsWith(stringDateFilter));
            var a = _timeTableService.GetAllinMonth(stringDateFilter).MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}