using System.Linq;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.Cmms;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Cmms;


namespace Pseez.ServiceLayer.EFServices.PseezEnt.Cmms
{
    public class EfRepairRequestService : _EfGenericService<RepairRequest>, IRepairRequestService
    {
        public EfRepairRequestService(IUnitOfWorkPseezEnt uow)
            : base(uow)
        {
        }

        //void AddRequestUser(RequestUserViewModel requestUserViewModel)
        //{
        //    RepairRequest
        //    _tEntities.Add();
        //}
    }
}