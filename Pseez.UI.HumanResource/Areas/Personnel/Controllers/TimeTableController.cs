using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.Extention.Sts;
using Pseez.ServiceLayer.Interfaces.Sts.Journey;

namespace Pseez.UI.HumanResource.Areas.Personnel.Controllers
{
    public class TimeTableController : Controller
    {
        private readonly ITimeTableService _timeTableService;
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
            var stringDateFilter = Year + "/" + Month;
            //StsContext db = new StsContext();
            //db.Configuration.ProxyCreationEnabled = false;
            //var a = db.TimeTables.Where(r => r.Date.StartsWith(stringDateFilter));
            var a = _timeTableService.GetAllinMonth(stringDateFilter).MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}