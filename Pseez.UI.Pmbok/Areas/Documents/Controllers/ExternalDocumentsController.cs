using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pseez.ServiceLayer.Interfaces;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models;
using Pseez.ViewModels.ViewModels;

using Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok;

namespace Pseez.UI.Pmbok.Areas.Documents.Controllers
{
    public class ExternalDocumentsController : ProjectDocumentsController
    {
        public ExternalDocumentsController(IUnitOfWorkPseezEnt uow,
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