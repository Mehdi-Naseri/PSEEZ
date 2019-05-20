using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok;
using Pseez.UI.Pmbok.Controllers;

namespace Pseez.UI.Pmbok.Areas.Documents.Controllers
{
    public class ProjectDocumentsController : ProjectDocumentsBaseController
    {
        public ProjectDocumentsController(IUnitOfWorkPseezEnt uow,
        IProjectDocumentValueService projectDocumentValueService,
        IProjectDocumentFileService projectDocumentFileService,
        IProjectDocumentValueFilesService projectDocumentValueFileService,
        IProjectDocumentFileDeletedService projectDocumentFileDeletedServic)
            :base(uow, projectDocumentValueService,projectDocumentFileService,
                 projectDocumentValueFileService, projectDocumentFileDeletedServic)
        {
        }
    }
}