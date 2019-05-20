using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pseez.DomainClasses.Models.PseezEnt.Pmbok;
using Pseez.ViewModels.ViewModels.PseezEnt.Pmbok;

namespace Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok
{
    public interface IProjectDocumentValueService : _IGenericService<ProjectDocumentValue>
    {
        bool Exist(string projectName, string projectDocumentName, string newProjectDocumentValue);

        void AddValue(string projectName, string projectDocumentName, string newProjectDocumentValue,string userName);

        ProjectDocumentLatestValueViewModel GetLatestValues(string projectName);

        IEnumerable<ProjectDocumentValue> GetChangedValues(string projectName, string projectDocumentName);
    }
}
