using System.Collections.Generic;
using AutoMapper;
using Pseez.DomainClasses.Models.PseezEnt.Pmbok;
using Pseez.ViewModels.ViewModels.PseezEnt.Pmbok;

namespace Pseez.Extentions.MapperConfigure.Extention.PseezEnt
{
    public static partial class DefineExtention
    {
        #region Project
        public static ProjectViewModel MapModelToViewModel(this Project entity)
        {
            return Mapper.Map<Project, ProjectViewModel>(entity);
        }
        public static Project MapViewModelToModel(this ProjectViewModel entity)
        {
            return Mapper.Map<ProjectViewModel, Project>(entity);
        }
        public static IEnumerable<ProjectViewModel> MapModelToViewModel(this IEnumerable<Project> entity)
        {
            return Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(entity);
        }
        public static IEnumerable<Project> MapViewModelToModel(this IEnumerable<ProjectViewModel> entity)
        {
            return Mapper.Map<IEnumerable<ProjectViewModel>, IEnumerable<Project>>(entity);
        }
        #endregion

        #region ProjectDocumentValue
        public static ProjectDocumentValueViewModel MapModelToViewModel(this ProjectDocumentValue entity)
        {
            return Mapper.Map<ProjectDocumentValue, ProjectDocumentValueViewModel>(entity);
        }
        public static ProjectDocumentValue MapViewModelToModel(this ProjectDocumentValueViewModel entity)
        {
            return Mapper.Map<ProjectDocumentValueViewModel, ProjectDocumentValue>(entity);
        }
        public static IEnumerable<ProjectDocumentValueViewModel> MapModelToViewModel(this IEnumerable<ProjectDocumentValue> entity)
        {
            return Mapper.Map<IEnumerable<ProjectDocumentValue>, IEnumerable<ProjectDocumentValueViewModel>>(entity);
        }
        public static IEnumerable<ProjectDocumentValue> MapViewModelToModel(this IEnumerable<ProjectDocumentValueViewModel> entity)
        {
            return Mapper.Map<IEnumerable<ProjectDocumentValueViewModel>, IEnumerable<ProjectDocumentValue>>(entity);
        }
        #endregion

        #region ProjectDocumentFile
        public static ProjectDocumentFileViewModel MapModelToViewModel(this ProjectDocumentFile entity)
        {
            return Mapper.Map<ProjectDocumentFile, ProjectDocumentFileViewModel>(entity);
        }
        public static ProjectDocumentFile MapViewModelToModel(this ProjectDocumentFileViewModel entity)
        {
            return Mapper.Map<ProjectDocumentFileViewModel, ProjectDocumentFile>(entity);
        }
        public static IEnumerable<ProjectDocumentFileViewModel> MapModelToViewModel(this IEnumerable<ProjectDocumentFile> entity)
        {
            return Mapper.Map<IEnumerable<ProjectDocumentFile>, IEnumerable<ProjectDocumentFileViewModel>>(entity);
        }
        public static IEnumerable<ProjectDocumentFile> MapViewModelToModel(this IEnumerable<ProjectDocumentFileViewModel> entity)
        {
            return Mapper.Map<IEnumerable<ProjectDocumentFileViewModel>, IEnumerable<ProjectDocumentFile>>(entity);
        }
        #endregion

        #region ProjectDocumentFileDeleted
        public static ProjectDocumentFileDeletedViewModel MapModelToViewModel(this ProjectDocumentFileDeleted entity)
        {
            return Mapper.Map<ProjectDocumentFileDeleted, ProjectDocumentFileDeletedViewModel>(entity);
        }
        public static ProjectDocumentFileDeleted MapViewModelToModel(this ProjectDocumentFileDeletedViewModel entity)
        {
            return Mapper.Map<ProjectDocumentFileDeletedViewModel, ProjectDocumentFileDeleted>(entity);
        }
        public static IEnumerable<ProjectDocumentFileDeletedViewModel> MapModelToViewModel(this IEnumerable<ProjectDocumentFileDeleted> entity)
        {
            return Mapper.Map<IEnumerable<ProjectDocumentFileDeleted>, IEnumerable<ProjectDocumentFileDeletedViewModel>>(entity);
        }
        public static IEnumerable<ProjectDocumentFileDeleted> MapViewModelToModel(this IEnumerable<ProjectDocumentFileDeletedViewModel> entity)
        {
            return Mapper.Map<IEnumerable<ProjectDocumentFileDeletedViewModel>, IEnumerable<ProjectDocumentFileDeleted>>(entity);
        }
        #endregion
    }
}