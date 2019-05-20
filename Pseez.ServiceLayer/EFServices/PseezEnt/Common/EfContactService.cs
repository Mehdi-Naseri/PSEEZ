using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.Common;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Common;

namespace Pseez.ServiceLayer.EFServices.PseezEnt.Common
{
    public class EfContactService : _EfGenericService<Contact>, IContactService
    {
        public EfContactService(IUnitOfWorkPseezEnt uow)
            : base(uow)
        {
        }
    }
}