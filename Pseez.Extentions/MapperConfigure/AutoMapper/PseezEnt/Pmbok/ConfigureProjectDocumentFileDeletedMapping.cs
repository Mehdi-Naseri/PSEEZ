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
    public class ConfigureProjectDocumentFileDeletedMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ProjectDocumentFileDeleted, ProjectDocumentFileDeletedViewModel>();
            Mapper.CreateMap<ProjectDocumentFileDeletedViewModel, ProjectDocumentFileDeleted>();

            //Mapper.CreateMap<ProjectDocumentFileDeleted, ProjectDocumentFileDeletedViewModel>()
            //    .ForMember(dest => dest.ProjectName, option => option.MapFrom(src => src.Project.Name))
            //    .ForMember(dest => dest.ProjectDocumentName, option => option.MapFrom(src => src.ProjectDocument.DocumentName));

            //Mapper.CreateMap<ProjectDocumentFileDeletedViewModel, ProjectDocumentFileDeleted>()
            //    .ForMember(dest => dest.ProjectId, option => option.MapFrom(src => src.ProjectName))
            //    .ForMember(dest => dest.ProjectDocumentId, option => option.MapFrom(src => src.ProjectDocumentName));
                //.ForMember(dest => dest.ProjectDocumentId, option => option.Ignore());
        }
    }
}
