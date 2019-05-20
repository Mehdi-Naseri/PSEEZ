using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.ServiceLayer.EFServices.Sts.Staff
{
    public class EfUnitService : _EfGenericService<Unit>, IUnitService
    {
        public EfUnitService(IUnitOfWorkSts uow)
            : base(uow)
        {
        }
    }
}