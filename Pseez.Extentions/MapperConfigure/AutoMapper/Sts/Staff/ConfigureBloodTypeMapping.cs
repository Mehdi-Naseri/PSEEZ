using AutoMapper;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ViewModels.ViewModels.Sts.Staff;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Staff
{
    public class ConfigureBloodTypeMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<BloodType, BloodTypeViewModel>();
            Mapper.CreateMap<BloodTypeViewModel, BloodType>();
        }
    }
}