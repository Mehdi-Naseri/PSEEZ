using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.Extention.Sts;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.UI.HumanResource.Areas.Personnel.Controllers
{
    public class BloodTypeController : Controller
    {
        private readonly IBloodTypeService _bloodTypeService;
        private readonly IUnitOfWorkSts _uow;

        public BloodTypeController(IUnitOfWorkSts uow, IBloodTypeService bloodTypeService)
        {
            _bloodTypeService = bloodTypeService;
            _uow = uow;
        }

        // GET: /Personnel/BloodType/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            //StsContext db = new StsContext();
            //db.Configuration.ProxyCreationEnabled = false;
            //var a = db.BloodTypes.ToArray();
            var r = _bloodTypeService.GetAll().MapModelToViewModel();
            return Json(r, JsonRequestBehavior.AllowGet);
        }
    }
}