using AutoMapper;
using Pseez.DomainClasses.Models.Sts.Basic;
using Pseez.ViewModels.ViewModels.Sts.Basic;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Basic
{
    public class ConfigureGenderMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Gender, GenderViewModel>();
            Mapper.CreateMap<GenderViewModel, Gender>();
        }
    }
}