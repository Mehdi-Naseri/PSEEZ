using System.Collections.Generic;
using System.Linq;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Journey;
using Pseez.ServiceLayer.Interfaces.Sts.Journey;

namespace Pseez.ServiceLayer.EFServices.Sts.Journey
{
    public class EfTimeTableService : _EfGenericService<TimeTable>, ITimeTableService
    {
        //protected IDbSet<TimeTable> _timeTable;
        public EfTimeTableService(IUnitOfWorkSts uow)
            : base(uow)
        {
        }

        public IList<TimeTable> GetAllinMonth(string stringDateFilter)
        {
            return _tEntities.Where(r => r.Date.StartsWith(stringDateFilter)).ToList();
            //var a = db.TimeTables.Where(r => r.Date.StartsWith(stringDateFilter));
        }
    }
}