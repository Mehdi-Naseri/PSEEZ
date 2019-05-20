using AutoMapper;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ViewModels.ViewModels.Sts.Staff;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Staff
{
    public class ConfigureEmployeeAcademicalResumeMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<EmployeeAcademicalResume, EmployeeAcademicalResumeViewModel>();
            Mapper.CreateMap<EmployeeAcademicalResumeViewModel, EmployeeAcademicalResume>();
        }
    }
}