using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.ServiceLayer.EFServices.Sts.Staff
{
    public class EfEmployeeOrganChartService : _EfGenericService<EmployeeOrganChart>, IEmployeeOrganChartService
    {
        public EfEmployeeOrganChartService(IUnitOfWorkSts uow)
            : base(uow)
        {
        }
    }
}