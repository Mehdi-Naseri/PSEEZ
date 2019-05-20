using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Pseez.DomainClasses.Models.PseezEnt.Pmbok;

namespace Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok
{
    public interface IProjectService : _IGenericService<Project>
    {
        bool Exist(string name);
    }
}
