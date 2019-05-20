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
    public class EfProjectService : _EfGenericService<Project>, IProjectService
    {
        public EfProjectService(IUnitOfWorkPseezEnt uow)
            : base(uow)
        {

        }

        public bool Exist(string name)
        {
            return _tEntities.Any(r => r.Name == name);
        }
    }
}
