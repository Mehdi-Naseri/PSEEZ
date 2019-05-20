using System.Collections.Generic;
using AutoMapper;
using Pseez.DomainClasses.Models.PseezEnt.Cmms;
using Pseez.DomainClasses.Models.PseezEnt.IT;
using Pseez.ViewModels.ViewModels.PseezEnt.Cmms;
using Pseez.ViewModels.ViewModels.PseezEnt.IT;

namespace Pseez.Extentions.MapperConfigure.Extention.PseezEnt
{
    public static partial class DefineExtention
    {

        #region RequestUser
        public static RepairRequestViewModel MapModelToViewModel(this RepairRequest entity)
        {
            return Mapper.Map<RepairRequest, RepairRequestViewModel>(entity);
        }

        public static RepairRequest MapViewModelToModel(this RepairRequestViewModel entity)
        {
            return Mapper.Map<RepairRequestViewModel, RepairRequest>(entity);
        }

        public static IEnumerable<RepairRequestViewModel> MapModelToViewModel(this IEnumerable<RepairRequest> entity)
        {
            return Mapper.Map<IEnumerable<RepairRequest>, IEnumerable<RepairRequestViewModel>>(entity);
        }

        public static IEnumerable<RepairRequest> MapViewModelToModel(this IEnumerable<RepairRequestViewModel> entity)
        {
            return Mapper.Map<IEnumerable<RepairRequestViewModel>, IEnumerable<RepairRequest>>(entity);
        }

        #endregion


        #region RequestUser
        public static RequestUserViewModel MapModelToViewModelRequestUser(this RepairRequest entity)
        {
            return Mapper.Map<RepairRequest, RequestUserViewModel>(entity);
        }

        public static RepairRequest MapViewModelToModel(this RequestUserViewModel entity)
        {
            return Mapper.Map<RequestUserViewModel, RepairRequest>(entity);
        }

        public static IEnumerable<RequestUserViewModel> MapModelToViewModelRequestUser(this IEnumerable<RepairRequest> entity)
        {
            return Mapper.Map<IEnumerable<RepairRequest>, IEnumerable<RequestUserViewModel>>(entity);
        }

        public static IEnumerable<RepairRequest> MapViewModelToModel(this IEnumerable<RequestUserViewModel> entity)
        {
            return Mapper.Map<IEnumerable<RequestUserViewModel>, IEnumerable<RepairRequest>>(entity);
        }
        #endregion

        #region RequestPlanning
        public static RequestPlanningViewModel MapModelToViewModelRequestPlanning(this RepairRequest entity)
        {
            return Mapper.Map<RepairRequest, RequestPlanningViewModel>(entity);
        }

        public static RepairRequest MapViewModelToModel(this RequestPlanningViewModel entity)
        {
            return Mapper.Map<RequestPlanningViewModel, RepairRequest>(entity);
        }

        public static IEnumerable<RequestPlanningViewModel> MapModelToViewModelRequestPlanning(this IEnumerable<RepairRequest> entity)
        {
            return Mapper.Map<IEnumerable<RepairRequest>, IEnumerable<RequestPlanningViewModel>>(entity);
        }

        public static IEnumerable<RepairRequest> MapViewModelToModel(this IEnumerable<RequestPlanningViewModel> entity)
        {
            return Mapper.Map<IEnumerable<RequestPlanningViewModel>, IEnumerable<RepairRequest>>(entity);
        }
        #endregion

        #region RequestTechnition
        public static RequestTechnitionViewModel MapModelToViewModelRequestTechnition(this RepairRequest entity)
        {
            return Mapper.Map<RepairRequest, RequestTechnitionViewModel>(entity);
        }

        public static RepairRequest MapViewModelToModel(this RequestTechnitionViewModel entity)
        {
            return Mapper.Map<RequestTechnitionViewModel, RepairRequest>(entity);
        }

        public static IEnumerable<RequestTechnitionViewModel> MapModelToViewModelRequestTechnition(this IEnumerable<RepairRequest> entity)
        {
            return Mapper.Map<IEnumerable<RepairRequest>, IEnumerable<RequestTechnitionViewModel>>(entity);
        }

        public static IEnumerable<RepairRequest> MapViewModelToModel(this IEnumerable<RequestTechnitionViewModel> entity)
        {
            return Mapper.Map<IEnumerable<RequestTechnitionViewModel>, IEnumerable<RepairRequest>>(entity);
        }
        #endregion

    }
}