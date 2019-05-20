using AutoMapper;
using Pseez.DomainClasses.Models.Sts.Basic;
using Pseez.ViewModels.ViewModels.Sts.Basic;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Basic
{
    public class ConfigureCityMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<City, CityViewModel>();
            Mapper.CreateMap<CityViewModel, City>();
        }
    }
}