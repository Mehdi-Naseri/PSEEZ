using AutoMapper;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ViewModels.ViewModels.Sts.Staff;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Staff
{
    public class ConfigureEmployeeMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Employee, EmployeeViewModel>();
            Mapper.CreateMap<EmployeeViewModel, Employee>();
        }
    }
}