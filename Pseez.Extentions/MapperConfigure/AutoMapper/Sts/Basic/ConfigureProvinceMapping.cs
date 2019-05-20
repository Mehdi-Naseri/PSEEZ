using AutoMapper;
using Pseez.DomainClasses.Models.Sts.Basic;
using Pseez.ViewModels.ViewModels.Sts.Basic;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Basic
{
    public class ConfigureProvinceMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Province, ProvinceViewModel>();
            Mapper.CreateMap<ProvinceViewModel, Province>();
        }
    }
}