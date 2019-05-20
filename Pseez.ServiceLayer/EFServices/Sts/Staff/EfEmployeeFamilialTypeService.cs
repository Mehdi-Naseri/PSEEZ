using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.ServiceLayer.EFServices.Sts.Staff
{
    public class EfEmployeeFamilialTypeService : _EfGenericService<EmployeeFamilialType>, IEmployeeFamilialTypeService
    {
        public EfEmployeeFamilialTypeService(IUnitOfWorkSts uow)
            : base(uow)
        {
        }
    }
}