using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.ServiceLayer.EFServices.Sts.Staff
{
    public class EfEmployeeService : _EfGenericService<Employee>, IEmployeeService
    {
        public EfEmployeeService(IUnitOfWorkSts uow)
            : base(uow)
        {
        }
    }
}