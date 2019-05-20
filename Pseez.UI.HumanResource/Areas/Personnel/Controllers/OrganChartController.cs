using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.Extention.Sts;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.UI.HumanResource.Areas.Personnel.Controllers
{
    public class OrganChartController : Controller
    {
        private readonly IOrganChartService _organChartService;
        private IUnitOfWorkSts _uow;

        public OrganChartController(IUnitOfWorkSts uow, IOrganChartService organChartService)
        {
            _organChartService = organChartService;
            _uow = uow;
        }

        //
        // GET: /Personnel/OrganChart/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            //StsContext db = new StsContext();
            ////جهت غیر فعال کردن لود فرزندان و در نتیجه جلوگیری از ایجاد حلقه
            //db.Configuration.ProxyCreationEnabled = false;
            //var a = db.OrganCharts.Select(r => new
            //{
            //    Id = r.Id,
            //    Job_Id = r.Job_Id,
            //    Unit_Id = r.Unit_Id,
            //    OrganChart_Parent_Id = r.OrganChart_Parent_Id,
            //    PositionType_Id = r.PositionType_Id,
            //    Date = r.Date,
            //    KeepHistory = r.KeepHistory,
            //    Show = r.Show
            //});
            var a = _organChartService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}