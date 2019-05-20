using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.Extention.Sts;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.UI.HumanResource.Areas.Personnel.Controllers
{
    public class EmployeeOrganChartController : Controller
    {
        private readonly IEmployeeOrganChartService _employeeOrganChart;
        private IUnitOfWorkSts _uow;

        public EmployeeOrganChartController(IUnitOfWorkSts uow, IEmployeeOrganChartService employeeOrganChart)
        {
            _employeeOrganChart = employeeOrganChart;
            _uow = uow;
        }

        //
        // GET: /Personnel/EmployeeOrganChart/
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
            //var a = db.EmployeeOrganCharts.ToArray();
            var a = _employeeOrganChart.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}