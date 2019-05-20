using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok;
using Pseez.UI.Pmbok.Controllers;

namespace Pseez.UI.Pmbok.Areas.ProjectIntegrationManagement.Controllers
{
    public class DirectandManageProjectWorkController : ProjectProcessesBaseController
    {
        public DirectandManageProjectWorkController(IUnitOfWorkPseezEnt uow,
IProjectDocumentValueService projectDocumentValueService,
IProjectDocumentFileService projectDocumentFileService,
IProjectDocumentValueFilesService projectDocumentValueFileService)
            :base(uow, projectDocumentValueService,projectDocumentFileService,
                 projectDocumentValueFileService)
        {
        }
    }
}