using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.ServiceLayer.EFServices.Sts.Staff
{
    public class EfFamilialTypeService : _EfGenericService<FamilialType>, IFamilialTypeService
    {
        public EfFamilialTypeService(IUnitOfWorkSts uow)
            : base(uow)
        {
        }
    }
}