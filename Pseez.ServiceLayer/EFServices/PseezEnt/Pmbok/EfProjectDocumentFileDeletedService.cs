using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Pseez.DataAccessLayer.IUnitOfWork;

using System.Web;
using Pseez.DomainClasses.Models.PseezEnt.Pmbok;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok;

namespace Pseez.ServiceLayer.EFServices.PseezEnt.Pmbok
{
    public class EfProjectDocumentFileDeletedService : IProjectDocumentFileDeletedService
    {
        protected IUnitOfWorkPseezEnt _uow;
        protected IDbSet<ProjectDocumentFileDeleted> _pdeletedDbSet;

        public EfProjectDocumentFileDeletedService(IUnitOfWorkPseezEnt uow)
        {
            _uow = uow;
            _pdeletedDbSet = _uow.Set<ProjectDocumentFileDeleted>();
        }

        public IEnumerable<ProjectDocumentFileDeleted> GetDeletedFiles(string projectName, string projectDocumentName)
        {
            return _pdeletedDbSet.Where(a => a.Project.Name == projectName && a.ProjectDocument.DocumentName == projectDocumentName);
        }

        public ProjectDocumentFileDeleted DownloadDocumentFile(int id)
        {
            return _pdeletedDbSet.First(r => r.Id == id);
        }
    }
}
