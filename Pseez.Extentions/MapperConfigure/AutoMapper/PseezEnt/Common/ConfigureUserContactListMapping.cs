using AutoMapper;
using Pseez.DomainClasses.Models.PseezEnt.Common;
using Pseez.ViewModels.ViewModels.PseezEnt.Common;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.PseezEnt.Common
{
    public class ConfigureUserContactListMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<UserContactList, UserContactListViewModel>()
                .ForMember(dest => dest.ContactListName,
                    opts => opts.MapFrom(src => src.ContactList.Name));
            ;
            Mapper.CreateMap<UserContactListViewModel, UserContactList>();
        }
    }
}