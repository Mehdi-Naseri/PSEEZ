using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pseez.ViewModels.ViewModels.PseezEnt.Pmbok;

namespace Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok
{
    public interface IProjectDocumentValueFilesService 
    {
        ProjectDocumentLatestValueFilesViewModel GetLatestValueFiles(string projectName);
    }
}
