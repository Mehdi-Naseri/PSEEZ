using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.ServiceLayer.EFServices.Sts.Staff
{
    public class EfBloodTypeService : _EfGenericService<BloodType>, IBloodTypeService
    {
        public EfBloodTypeService(IUnitOfWorkSts uow)
            : base(uow)
        {
        }
    }
}