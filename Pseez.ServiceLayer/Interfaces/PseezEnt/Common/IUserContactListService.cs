using Pseez.DomainClasses.Models.PseezEnt.Common;

namespace Pseez.ServiceLayer.Interfaces.PseezEnt.Common
{
    public interface IUserContactListService : _IGenericService<UserContactList>
    {
        bool Exist(string UserId, int ContactListId);
    }
}