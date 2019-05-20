using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.ServiceLayer.EFServices.Sts.Staff
{
    public class EfDegreeStateService : _EfGenericService<DegreeState>, IDegreeStateService
    {
        public EfDegreeStateService(IUnitOfWorkSts uow)
            : base(uow)
        {
        }
    }
}