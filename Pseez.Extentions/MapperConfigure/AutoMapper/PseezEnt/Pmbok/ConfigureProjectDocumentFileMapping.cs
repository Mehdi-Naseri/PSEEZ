using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Pseez.DomainClasses.Models.PseezEnt.Pmbok;
using Pseez.ViewModels.ViewModels.PseezEnt.Pmbok;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.PseezEnt.Pmbok
{
    public class ConfigureProjectDocumentFileMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ProjectDocumentFile, ProjectDocumentFileViewModel>();
            Mapper.CreateMap<ProjectDocumentFileViewModel, ProjectDocumentFile>();

            //Mapper.CreateMap<Project, ProjectViewModel>()
            //    .ForMember(dest => dest.ContactListName,
            //    option => option.MapFrom(src => src.ContactList.Name));
            //Mapper.CreateMap<ProjectViewModel, Project>()
            //    .ForMember(dest => dest.ContactListId,
            //    option => option.Ignore());
        }
    }
}
