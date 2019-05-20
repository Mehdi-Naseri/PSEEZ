using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.IT;
using Pseez.ServiceLayer.Interfaces.PseezEnt.IT;

namespace Pseez.ServiceLayer.EFServices.PseezEnt.IT
{
    public class EfBackupService : _EfGenericService<Backup>, IBackupService
    {
        public EfBackupService(IUnitOfWorkPseezEnt uow)
            : base(uow)
        {
        }
    }
}