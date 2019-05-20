using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Basic;
using Pseez.ServiceLayer.Interfaces.Sts.Basic;

namespace Pseez.ServiceLayer.EFServices.Sts.Basic
{
    public class EfCityService : _EfGenericService<City>, ICityService
    {
        public EfCityService(IUnitOfWorkSts uow)
            : base(uow)
        {
        }
    }
}