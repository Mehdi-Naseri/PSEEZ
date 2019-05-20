using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok;
using Pseez.ViewModels.ViewModels.PseezEnt.Pmbok;

namespace Pseez.UI.Pmbok.Controllers
{
    public class ProjectProcessesBaseController : Controller
    {
        protected IUnitOfWorkPseezEnt _uow;
        protected IProjectDocumentValueService _projectDocumentValueService;
        protected IProjectDocumentFileService _projectDocumentFileService;
        protected IProjectDocumentValueFilesService _projectDocumentValueFileService;
        protected IProjectDocumentFileDeletedService _projectDocumentFileDeletedService;

        //برای استفاده در Process  ها
        public ProjectProcessesBaseController(IUnitOfWorkPseezEnt uow,
                IProjectDocumentValueService projectDocumentValueService,
                IProjectDocumentFileService projectDocumentFileService,
                IProjectDocumentValueFilesService projectDocumentValueFileService
)
        {
            _uow = uow;
            _projectDocumentValueService = projectDocumentValueService;
            _projectDocumentFileService = projectDocumentFileService;
            _projectDocumentValueFileService = projectDocumentValueFileService;
        }
        //برای استفاده در Project Document
        public ProjectProcessesBaseController(IUnitOfWorkPseezEnt uow,
        IProjectDocumentValueService projectDocumentValueService,
        IProjectDocumentFileService projectDocumentFileService,
        IProjectDocumentValueFilesService projectDocumentValueFileService,
        IProjectDocumentFileDeletedService projectDocumentFileDeletedServic)
        {
            _uow = uow;
            _projectDocumentValueService = projectDocumentValueService;
            _projectDocumentFileService = projectDocumentFileService;
            _projectDocumentValueFileService = projectDocumentValueFileService;
            _projectDocumentFileDeletedService = projectDocumentFileDeletedServic;
        }


        public ActionResult Index()
        {
            if (Request.Cookies["DefaultProjectName"] != null)
            {
                string projectName = Request.Cookies["DefaultProjectName"].Value;
                ProjectDocumentLatestValueFilesViewModel projectDocumentLatestValueFilesViewModel = _projectDocumentValueFileService.GetLatestValueFiles(projectName);
                return View(projectDocumentLatestValueFilesViewModel);
            }
            else
            {
                return View("~/Views/Shared/SelectDefaultProject.cshtml");
            }
        }

        [HttpPost]
        public string SaveDocumentValue(string projectName, string projectDocumentName, string newProjectDocumentValue)
        {
            if (!string.IsNullOrEmpty(newProjectDocumentValue))
            {
                if (!_projectDocumentValueService.Exist(projectName, projectDocumentName, newProjectDocumentValue))
                {
                    _projectDocumentValueService.AddValue(projectName, projectDocumentName, newProjectDocumentValue, User.Identity.Name);
                    _uow.SaveChanges();
                    return "Success";
                }
                else
                {
                    return "Exist";
                }

            }
            else
            {
                return "EmptyValue";
            }
        }

        [HttpPost]
        public string UploadDocumentFile(IEnumerable<HttpPostedFileBase> files, string projectName, string projectDocumentName)
        {
            _projectDocumentFileService.UploadDocumentFiles(projectName, projectDocumentName, files, User.Identity.Name);
            _uow.SaveChanges();
            return "";
        }

        [HttpPost]
        public string DeleteDocumentFile(int? id, string fileNames)
        {
            if (fileNames == null)
            {
                if (id == null)
                {
                    return "";
                }
                else if (_projectDocumentFileService.Exist((int)id))
                {
                    _projectDocumentFileService.DeleteDocumentFileById((int)id);
                    _uow.SaveChanges();
                    return "Success";
                }
                else
                {
                    return "Exist";
                }
            }
            else
                return "error";
        }

        public FileContentResult DownloadDocumentFile(int id)
        {
            byte[] fileData;
            fileData = _projectDocumentFileService.DownloadDocumentFile(id).File;
            string fileName = _projectDocumentFileService.DownloadDocumentFile(id).FileName;
            return File(fileData, "Text", fileName);
        }
    }
}