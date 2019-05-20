using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.ServiceLayer.EFServices.Sts.Staff
{
    public class EfOrganChartService : _EfGenericService<OrganChart>, IOrganChartService
    {
        public EfOrganChartService(IUnitOfWorkSts uow)
            : base(uow)
        {
        }
    }
}