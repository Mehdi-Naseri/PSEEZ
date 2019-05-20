using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.IT;
using Pseez.ServiceLayer.Interfaces.PseezEnt.IT;

namespace Pseez.ServiceLayer.EFServices.PseezEnt.IT
{
    public class EfServerService : _EfGenericService<Server>, IServerService
    {
        public EfServerService(IUnitOfWorkPseezEnt uow) : base(uow)
        {
        }
    }
}