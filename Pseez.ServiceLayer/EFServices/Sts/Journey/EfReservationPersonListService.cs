using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Journey;
using Pseez.ServiceLayer.Interfaces.Sts.Journey;

namespace Pseez.ServiceLayer.EFServices.Sts.Journey
{
    public class EfReservationPersonListService : _EfGenericService<ReservationPersonList>,
        IReservationPersonListService
    {
        public EfReservationPersonListService(IUnitOfWorkSts uow)
            : base(uow)
        {
        }
    }
}