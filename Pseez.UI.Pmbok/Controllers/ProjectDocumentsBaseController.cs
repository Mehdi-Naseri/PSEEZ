using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok;
using Pseez.ViewModels.ViewModels.PseezEnt.Pmbok;
using Pseez.Extentions.MapperConfigure.Extention.PseezEnt;

namespace Pseez.UI.Pmbok.Controllers
{
    public class ProjectDocumentsBaseController : ProjectProcessesBaseController
    {
        //IProjectDocumentFileDeletedService _projectDocumentFileDeletedService;
        public ProjectDocumentsBaseController(IUnitOfWorkPseezEnt uow,
              IProjectDocumentValueService projectDocumentValueService,
              IProjectDocumentFileService projectDocumentFileService,
              IProjectDocumentValueFilesService projectDocumentValueFileService,
              IProjectDocumentFileDeletedService projectDocumentFileDeletedServic
              )

            : base(uow, projectDocumentValueService, projectDocumentFileService,
                 projectDocumentValueFileService, projectDocumentFileDeletedServic)
        {
        }

        //public PartialViewResult GetChangedValues(string projectName, string projectDocumentName)
        //{
        //    IEnumerable<ProjectDocumentValueViewModel> model = _projectDocumentValueService.GetChangedValues(projectName, projectDocumentName).MapModelToViewModel();
        //    return PartialView("_ChangedValues", model);
        //}

        public ActionResult GetChangedValues(string projectName, string projectDocumentName)
        {
           IEnumerable<ProjectDocumentValueViewModel> model = _projectDocumentValueService.GetChangedValues(projectName, projectDocumentName).MapModelToViewModel();
            return PartialView("~/Areas/Documents/Views/Shared/_ChangedValues.cshtml", model);
        }

        public PartialViewResult GetDeletedFiles(string projectName, string projectDocumentName)
        {
            IEnumerable<ProjectDocumentFileDeletedViewModel> model = _projectDocumentFileDeletedService.GetDeletedFiles(projectName, projectDocumentName).MapModelToViewModel();
            return PartialView("~/Areas/Documents/Views/Shared/_DeletedFiles.cshtml", model);
        }

        public FileContentResult DownloadDocumentFileDeleted(int id)
        {
            ProjectDocumentFileDeletedViewModel projectDocumentFileDeletedViewModel = _projectDocumentFileDeletedService.DownloadDocumentFile(id).MapModelToViewModel();
            byte[] fileData = projectDocumentFileDeletedViewModel.File;
            string fileName = projectDocumentFileDeletedViewModel.FileName;
            return File(fileData, "Text", fileName);
        }
    }
}