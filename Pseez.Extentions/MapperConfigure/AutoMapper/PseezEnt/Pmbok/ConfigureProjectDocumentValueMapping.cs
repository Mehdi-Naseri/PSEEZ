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
    public class ConfigureProjectDocumentValueMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ProjectDocumentValue, ProjectDocumentValueViewModel>();
                //.ForMember(dest => dest.ProjectName, option => option.MapFrom(src => src.Project.Name))
                //.ForMember(dest => dest.ProjectDocumentName, option => option.MapFrom(src => src.ProjectDocument.DocumentName));
            Mapper.CreateMap<ProjectDocumentValueViewModel, ProjectDocumentValue>();
                //.ForMember(dest => dest.ProjectId, option => option.Ignore())
                //.ForMember(dest => dest.ProjectDocumentId, option => option.Ignore());
            //.ForMember(dest => dest.ProjectDocumentId, option => option.Ignore());


            //Mapper.CreateMap<Project, ProjectViewModel>()
            //    .ForMember(dest => dest.ContactListName,
            //    option => option.MapFrom(src => src.ContactList.Name));
            //Mapper.CreateMap<ProjectViewModel, Project>()
            //    .ForMember(dest => dest.ContactListId,
            //    option => option.Ignore());
        }
    }
}
