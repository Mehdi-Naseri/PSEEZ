using AutoMapper;
using Pseez.DomainClasses.Models.PseezEnt.Common;
using Pseez.ViewModels.ViewModels.PseezEnt.Common;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.PseezEnt.Common
{
    public class ConfigureContactMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Contact, ContactViewModel>();
            Mapper.CreateMap<ContactViewModel, Contact>();
        }
    }
}