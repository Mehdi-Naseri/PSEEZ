using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Basic;
using Pseez.ServiceLayer.Interfaces.Sts.Basic;

namespace Pseez.ServiceLayer.EFServices.Sts.Basic
{
    public class EfGenderService : _EfGenericService<Gender>, IGenderService
    {
        public EfGenderService(IUnitOfWorkSts uow)
            : base(uow)
        {
        }
    }
}