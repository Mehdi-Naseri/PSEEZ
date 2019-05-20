using AutoMapper;
using Pseez.DomainClasses.Models.PseezEnt.IT;
using Pseez.ViewModels.ViewModels.PseezEnt.IT;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.PseezEnt.IT
{
    public class ConfigureServerMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Server, ServerViewModel>();
            Mapper.CreateMap<ServerViewModel, Server>();
        }
    }
}