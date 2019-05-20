using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Identity.ServiceLayer.EFServices;
using System.Web;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.Pmbok;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok;

namespace Pseez.ServiceLayer.EFServices.PseezEnt.Pmbok
{
    public class EfProjectDocumentFileService : _EfGenericService<ProjectDocumentFile>, IProjectDocumentFileService
    {
        protected IUnitOfWorkPseezEnt _uow;
        protected IDbSet<ProjectDocumentFile> _pDbSet;
        protected IDbSet<ProjectDocumentFileDeleted> _pdeletedDbSet;

        public EfProjectDocumentFileService(IUnitOfWorkPseezEnt uow)
            : base(uow)
        {
            _uow = uow;
            _pDbSet = _uow.Set<ProjectDocumentFile>();
            _pdeletedDbSet = _uow.Set<ProjectDocumentFileDeleted>();
        }

        public void UploadDocumentFile(string projectName, string projectDocumentName, HttpPostedFileBase file/*,string fileName*/, string username)
        {
            if (file != null)
            {
                EfProjectDocumentService efProjectDocumentService = new EfProjectDocumentService(_uow);
                EfProjectService efProjectService = new EfProjectService(_uow);
                EfIdentityUserService efIdentityUserService = new EfIdentityUserService();

                int projectDocumentId =
                    efProjectDocumentService.Find(r => r.DocumentName.Replace("  ", string.Empty) == projectDocumentName).Id;
                int projectId = efProjectService.Find(r => r.Name == projectName).Id;

                ProjectDocumentFile projectDocumentFile = new ProjectDocumentFile();
                projectDocumentFile.UploadDateTime = DateTime.Now;
                projectDocumentFile.CreatedBy = efIdentityUserService.FindUserIdByName(username);
                projectDocumentFile.ProjectDocumentId = projectDocumentId;
                projectDocumentFile.ProjectId = projectId;
                projectDocumentFile.FileName = file.FileName;

                byte[] uploadFile = new byte[file.InputStream.Length];
                file.InputStream.Read(uploadFile, 0, uploadFile.Length);
                projectDocumentFile.File = uploadFile;

                _pDbSet.Add(projectDocumentFile);
            }
        }

        public void UploadDocumentFiles(string projectName, string projectDocumentName, IEnumerable<HttpPostedFileBase> files, string username)
        {
            foreach (var file in files)
            {
                UploadDocumentFile(projectName, projectDocumentName, file, username);
            }
        }

        public void DeleteDocumentFile(string projectName, string projectDocumentName, string file, string username)
        {

        }

        public void DeleteDocumentFileById(int id)
        {
            ProjectDocumentFile projectDocumentFile = _pDbSet.Find(id);
            ProjectDocumentFileDeleted projectDocumentFileDeleted = new ProjectDocumentFileDeleted();

            projectDocumentFileDeleted.Id = projectDocumentFile.Id;
            projectDocumentFileDeleted.FileName = projectDocumentFile.FileName;
            projectDocumentFileDeleted.File = projectDocumentFile.File;
            projectDocumentFileDeleted.UploadDateTime = projectDocumentFile.UploadDateTime;
            projectDocumentFileDeleted.DeleteDateTime = DateTime.Now;
            projectDocumentFileDeleted.CreatedBy = projectDocumentFile.CreatedBy;
            projectDocumentFileDeleted.ProjectDocumentId = projectDocumentFile.ProjectDocumentId;
            projectDocumentFileDeleted.ProjectId = projectDocumentFile.ProjectId;
            _pdeletedDbSet.Add(projectDocumentFileDeleted);
            _pDbSet.Remove(_pDbSet.Find(id));
        }

        public ProjectDocumentFile DownloadDocumentFile(int id)
        {
            return _pDbSet.First(r => r.Id == id);
        }

        public bool Exist(int id)
        {
            return (_pDbSet.First(r => r.Id == id) != null) ? true : false;
        }
    }
}
