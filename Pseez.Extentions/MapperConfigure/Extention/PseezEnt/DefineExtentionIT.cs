using System.Collections.Generic;
using AutoMapper;
using Pseez.DomainClasses.Models.PseezEnt.IT;
using Pseez.ViewModels.ViewModels.PseezEnt.IT;

namespace Pseez.Extentions.MapperConfigure.Extention.PseezEnt
{
    public static partial class DefineExtention
    {
        #region DataCenter

        #region Server

        public static ServerViewModel MapModelToViewModel(this Server entity)
        {
            return Mapper.Map<Server, ServerViewModel>(entity);
        }

        public static Server MapViewModelToModel(this ServerViewModel entity)
        {
            return Mapper.Map<ServerViewModel, Server>(entity);
        }

        public static IEnumerable<ServerViewModel> MapModelToViewModel(this IEnumerable<Server> entity)
        {
            return Mapper.Map<IEnumerable<Server>, IEnumerable<ServerViewModel>>(entity);
        }

        public static IEnumerable<Server> MapViewModelToModel(this IEnumerable<ServerViewModel> entity)
        {
            return Mapper.Map<IEnumerable<ServerViewModel>, IEnumerable<Server>>(entity);
        }

        #endregion

        #region Backup

        public static BackupViewModel MapModelToViewModel(this Backup entity)
        {
            return Mapper.Map<Backup, BackupViewModel>(entity);
        }

        public static Backup MapViewModelToModel(this BackupViewModel entity)
        {
            return Mapper.Map<BackupViewModel, Backup>(entity);
        }

        public static IEnumerable<BackupViewModel> MapModelToViewModel(this IEnumerable<Backup> entity)
        {
            return Mapper.Map<IEnumerable<Backup>, IEnumerable<BackupViewModel>>(entity);
        }

        public static IEnumerable<Backup> MapViewModelToModel(this IEnumerable<BackupViewModel> entity)
        {
            return Mapper.Map<IEnumerable<BackupViewModel>, IEnumerable<Backup>>(entity);
        }

        #endregion

        #endregion
    }
}