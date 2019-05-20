using AutoMapper;
using Pseez.DomainClasses.Models.PseezEnt.VisitRegistration;
using Pseez.ViewModels.ViewModels.PseezEnt.VisitRegistration;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.PseezEnt.VisitRegistration
{
    public class ConfigureRegistrationMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Registration, RegistrationViewModel>();
            Mapper.CreateMap<RegistrationViewModel, Registration>();

            //Mapper.CreateMap<Project, ProjectViewModel>()
            //    .ForMember(dest => dest.ContactListName,
            //    option => option.MapFrom(src => src.ContactList.Name));
            //Mapper.CreateMap<ProjectViewModel, Project>()
            //    .ForMember(dest => dest.ContactListId,
            //    option => option.Ignore());
        }
    }
}