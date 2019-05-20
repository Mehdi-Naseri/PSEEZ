using AutoMapper;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ViewModels.ViewModels.Sts.Staff;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Staff
{
    public class ConfigureEmployeeFamilialTypeMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<EmployeeFamilialType, EmployeeFamilialTypeViewModel>();
            Mapper.CreateMap<EmployeeFamilialTypeViewModel, EmployeeFamilialType>();
        }
    }
}