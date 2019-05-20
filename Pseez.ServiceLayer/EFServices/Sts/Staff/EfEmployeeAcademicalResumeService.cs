using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.ServiceLayer.EFServices.Sts.Staff
{
    public class EfEmployeeAcademicalResumeService : _EfGenericService<EmployeeAcademicalResume>,
        IEmployeeAcademicalResumeService
    {
        public EfEmployeeAcademicalResumeService(IUnitOfWorkSts uow)
            : base(uow)
        {
        }
    }
}