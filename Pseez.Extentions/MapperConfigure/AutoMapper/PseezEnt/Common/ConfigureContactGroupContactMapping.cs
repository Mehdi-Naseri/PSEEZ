using AutoMapper;
using Pseez.DomainClasses.Models.PseezEnt.Common;
using Pseez.ViewModels.ViewModels.PseezEnt.Common;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.PseezEnt.Common
{
    public class ConfigureContactGroupMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ContactGroup, ContactGroupViewModel>()
                .ForMember(dest => dest.ContactListName,
                    option => option.MapFrom(src => src.ContactList.Name));
            Mapper.CreateMap<ContactGroupViewModel, ContactGroup>()
                .ForMember(dest => dest.ContactListId,
                    option => option.Ignore());
        }
    }
}