using AutoMapper;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ViewModels.ViewModels.Sts.Staff;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Staff
{
    public class ConfigureFamilialTypeMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<FamilialType, FamilialTypeViewModel>();
            Mapper.CreateMap<FamilialTypeViewModel, FamilialType>();
        }
    }
}