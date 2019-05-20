using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Basic;
using Pseez.ServiceLayer.Interfaces.Sts.Basic;

namespace Pseez.ServiceLayer.EFServices.Sts.Basic
{
    public class EfPersonService : _EfGenericService<Person>, IPersonService
    {
        public EfPersonService(IUnitOfWorkSts uow)
            : base(uow)
        {
        }
    }
}