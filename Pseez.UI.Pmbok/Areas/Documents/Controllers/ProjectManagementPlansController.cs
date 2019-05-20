using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok;

namespace Pseez.UI.Pmbok.Areas.Documents.Controllers
{
    public class ProjectManagementPlansController : ProjectDocumentsController
    {
        public ProjectManagementPlansController(IUnitOfWorkPseezEnt uow,
            IProjectDocumentValueService projectDocumentValueService,
            IProjectDocumentFileService projectDocumentFileService,
            IProjectDocumentValueFilesService projectDocumentValueFileService,
            IProjectDocumentFileDeletedService projectDocumentFileDeletedServic)
            : base(uow, projectDocumentValueService, projectDocumentFileService,
                 projectDocumentValueFileService, projectDocumentFileDeletedServic)
        {
        }
    }
}