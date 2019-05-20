using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.Extention.Sts;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.UI.HumanResource.Areas.Personnel.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitService _unitService;
        private IUnitOfWorkSts _uow;

        public UnitController(IUnitOfWorkSts uow, IUnitService unitService)
        {
            _unitService = unitService;
            _uow = uow;
        }

        //
        // GET: /Personnel/Unit/
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
            //var a = db.Units.Select(r => new {
            //    Id = r.Id,
            //    Code = r.Code,
            //    Name =r.Name,
            //    Unit_Parent_Id = r.Unit_Parent_Id,
            //    IsManagement = r.IsManagement,
            //    Show = r.Show
            //}).ToArray();
            var r = _unitService.GetAll().MapModelToViewModel();
            return Json(r, JsonRequestBehavior.AllowGet);
        }
    }
}