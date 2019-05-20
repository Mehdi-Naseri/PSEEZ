using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pseez.DomainClasses.Models.PseezEnt.VisitRegistration;
using Pseez.ServiceLayer.Interfaces.PseezEnt;

namespace Pseez.ServiceLayer.Interfaces.PseezEnt.VisitRegistration
{
    public interface IRegistrationService : _IGenericService<Registration>
    {
        //bool Exist(string Name);
    }
}
