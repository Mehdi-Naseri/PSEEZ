using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.ServiceLayer.EFServices.Sts.Staff
{
    public class EfReligionService : _EfGenericService<Religion>, IReligionService
    {
        public EfReligionService(IUnitOfWorkSts uow)
            : base(uow)
        {
        }
    }
}