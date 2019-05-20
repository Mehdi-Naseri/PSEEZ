using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.Common;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Common;

namespace Pseez.ServiceLayer.EFServices.PseezEnt.Common
{
    public class EfContactGroupService : _EfGenericService<ContactGroup>, IContactGroupService
    {
        public EfContactGroupService(IUnitOfWorkPseezEnt uow)
            : base(uow)
        {
        }
    }
}