using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;
using Pseez.DomainClasses.Models.PseezEnt.Pmbok;
using Pseez.ServiceLayer.Interfaces.PseezEnt;

namespace Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok
{
    public interface IProjectDocumentFileService : _IGenericService<ProjectDocumentFile>
    {
        void UploadDocumentFile(string projectName, string projectDocumentName, HttpPostedFileBase file, string username);
        void UploadDocumentFiles(string projectName, string projectDocumentName,IEnumerable<HttpPostedFileBase> files, string username);
        void DeleteDocumentFile(string projectName, string projectDocumentName, string file, string username);

        void DeleteDocumentFileById(int id);
        ProjectDocumentFile DownloadDocumentFile(int id);

        bool Exist(int id);
    }
}
