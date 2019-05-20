using AutoMapper;
using Pseez.DomainClasses.Models.Sts.Journey;
using Pseez.ViewModels.ViewModels.Sts.Journey;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Journey
{
    public class ConfigureProviderMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Provider, ProviderViewModel>();
            Mapper.CreateMap<ProviderViewModel, Provider>();
        }
    }
}