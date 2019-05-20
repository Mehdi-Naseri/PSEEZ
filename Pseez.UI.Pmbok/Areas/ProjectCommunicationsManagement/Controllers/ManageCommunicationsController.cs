using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok;
using Pseez.UI.Pmbok.Controllers;

namespace Pseez.UI.Pmbok.Areas.ProjectCommunicationsManagement.Controllers
{
    public class ManageCommunicationsController : ProjectProcessesBaseController
    {
        public ManageCommunicationsController(IUnitOfWorkPseezEnt uow,
IProjectDocumentValueService projectDocumentValueService,
IProjectDocumentFileService projectDocumentFileService,
IProjectDocumentValueFilesService projectDocumentValueFileService)
            :base(uow, projectDocumentValueService,projectDocumentFileService,
                 projectDocumentValueFileService)
        {
        }
    }
}