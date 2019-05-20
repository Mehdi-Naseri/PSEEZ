using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.Pmbok;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok;

namespace Pseez.ServiceLayer.EFServices.PseezEnt.Pmbok
{
    public class EfProjectDocumentService : _EfGenericService<ProjectDocument>, IProjectDocumentService
    {
        public EfProjectDocumentService(IUnitOfWorkPseezEnt uow)
            : base(uow)
        {

        }

        public bool Exist(string name)
        {
            return _tEntities.Any(r => r.DocumentName == name);
        }
    }
}
