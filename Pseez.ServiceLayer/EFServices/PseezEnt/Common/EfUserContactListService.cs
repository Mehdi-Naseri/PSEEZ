using System.Linq;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.Common;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Common;

namespace Pseez.ServiceLayer.EFServices.PseezEnt.Common
{
    public class EfUserContactListService : _EfGenericService<UserContactList>, IUserContactListService
    {
        public EfUserContactListService(IUnitOfWorkPseezEnt uow)
            : base(uow)
        {
        }

        public bool Exist(string userId, int contactListId)
        {
            return _tEntities.Any(r => r.UserId == userId && r.ContactListId == contactListId);
        }
    }
}