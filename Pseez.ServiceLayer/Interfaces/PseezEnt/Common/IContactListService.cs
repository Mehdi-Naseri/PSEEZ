using Pseez.DomainClasses.Models.PseezEnt.Common;

namespace Pseez.ServiceLayer.Interfaces.PseezEnt.Common
{
    public interface IContactListService : _IGenericService<ContactList>
    {
        bool Exist(string Name);
    }
}