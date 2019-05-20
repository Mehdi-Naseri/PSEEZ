using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pseez.DomainClasses.Models.PseezEnt.VisitRegistration;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.ServiceLayer.EFServices.PseezEnt;
using Pseez.ServiceLayer.Interfaces.PseezEnt.VisitRegistration;

namespace Pseez.ServiceLayer.EFServices.PseezEnt.VisitRegistration
{
    public class EfRegistrationService : _EfGenericService<Registration>, IRegistrationService
    {
        public EfRegistrationService(IUnitOfWorkPseezEnt uow)
            : base(uow)
        {

        }

        //public bool Exist(string Name)
        //{
        //    return _tEntities.Any(r => r.Name == Name);
        //}
    }
}
