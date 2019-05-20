using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.Extention.Sts;
using Pseez.ServiceLayer.Interfaces.Sts.Basic;

namespace Pseez.UI.HumanResource.Areas.Personnel.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private IUnitOfWorkSts _uow;

        public PersonController(IUnitOfWorkSts uow, IPersonService personService)
        {
            _personService = personService;
            _uow = uow;
        }

        //
        // GET: /Personnel/Person/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            //StsContext db = new StsContext();
            //db.Configuration.ProxyCreationEnabled = false;
            //var a = db.People.ToArray();
            var a = _personService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}