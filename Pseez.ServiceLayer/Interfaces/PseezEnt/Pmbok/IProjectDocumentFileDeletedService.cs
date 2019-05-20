using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;
using Pseez.DomainClasses.Models.PseezEnt.Pmbok;

namespace Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok
{
    public interface IProjectDocumentFileDeletedService
    {
        IEnumerable<ProjectDocumentFileDeleted> GetDeletedFiles(string projectName, string projectDocumentName);

        ProjectDocumentFileDeleted DownloadDocumentFile(int id);
    }
}
