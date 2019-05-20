using System.Collections.Generic;
using AutoMapper;
using Pseez.DomainClasses.Models.PseezEnt.VisitRegistration;
using Pseez.ViewModels.ViewModels.PseezEnt.VisitRegistration;

namespace Pseez.Extentions.MapperConfigure.Extention.PseezEnt
{
    public static partial class DefineExtention
    {
        #region Server

        public static RegistrationViewModel MapModelToViewModel(this Registration entity)
        {
            return Mapper.Map<Registration, RegistrationViewModel>(entity);
        }

        public static Registration MapViewModelToModel(this RegistrationViewModel entity)
        {
            return Mapper.Map<RegistrationViewModel, Registration>(entity);
        }

        public static IEnumerable<RegistrationViewModel> MapModelToViewModel(this IEnumerable<Registration> entity)
        {
            return Mapper.Map<IEnumerable<Registration>, IEnumerable<RegistrationViewModel>>(entity);
        }

        public static IEnumerable<Registration> MapViewModelToModel(this IEnumerable<RegistrationViewModel> entity)
        {
            return Mapper.Map<IEnumerable<RegistrationViewModel>, IEnumerable<Registration>>(entity);
        }

        #endregion
    }
}