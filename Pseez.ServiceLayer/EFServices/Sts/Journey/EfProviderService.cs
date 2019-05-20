using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Journey;
using Pseez.ServiceLayer.Interfaces.Sts.Journey;

namespace Pseez.ServiceLayer.EFServices.Sts.Journey
{
    public class EfProviderService : _EfGenericService<Provider>, IProviderService
    {
        public EfProviderService(IUnitOfWorkSts uow)
            : base(uow)
        {
        }
    }
}