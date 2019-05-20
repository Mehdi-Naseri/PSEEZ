using AutoMapper;
using Pseez.DomainClasses.Models.PseezEnt.Common;
using Pseez.ViewModels.ViewModels.PseezEnt.Common;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.PseezEnt.Common
{
    public class ConfigureContactListMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ContactList, ContactListViewModel>();
            //.ForMember(dest => dest.CreatedBy,
            //opts => opts.MapFrom(src => src.ApplicationUser.  UserId));
            Mapper.CreateMap<ContactListViewModel, ContactList>();
        }
    }
}