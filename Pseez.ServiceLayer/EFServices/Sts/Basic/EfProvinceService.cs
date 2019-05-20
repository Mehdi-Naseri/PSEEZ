using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Basic;
using Pseez.ServiceLayer.Interfaces.Sts.Basic;

namespace Pseez.ServiceLayer.EFServices.Sts.Basic
{
    public class EfProvinceService : _EfGenericService<Province>, IProvinceService
    {
        public EfProvinceService(IUnitOfWorkSts uow)
            : base(uow)
        {
        }
    }
}