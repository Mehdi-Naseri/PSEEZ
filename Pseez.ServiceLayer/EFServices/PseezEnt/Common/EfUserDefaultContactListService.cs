using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.Common;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Common;

namespace Pseez.ServiceLayer.EFServices.PseezEnt.Common
{
    public class EfUserDefaultContactListService : _EfGenericService<UserDefaultContactList>,
        IUserDefaultContactListService
    {
        public EfUserDefaultContactListService(IUnitOfWorkPseezEnt uow)
            : base(uow)
        {
        }
    }
}