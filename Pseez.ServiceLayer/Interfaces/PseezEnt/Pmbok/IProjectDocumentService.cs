using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pseez.DomainClasses.Models.PseezEnt.Pmbok;
using Pseez.ServiceLayer.Interfaces.PseezEnt;

namespace Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok
{
    public interface IProjectDocumentService : _IGenericService<ProjectDocument>
    {
        bool Exist(string Name);
    }
}
