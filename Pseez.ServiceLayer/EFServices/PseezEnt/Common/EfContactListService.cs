using System.Linq;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.Common;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Common;

namespace Pseez.ServiceLayer.EFServices.PseezEnt.Common
{
    public class EfContactListService : _EfGenericService<ContactList>, IContactListService
    {
        public EfContactListService(IUnitOfWorkPseezEnt uow)
            : base(uow)
        {
        }

        public bool Exist(string name)
        {
            return _tEntities.Any(r => r.Name == name);
        }
    }
}