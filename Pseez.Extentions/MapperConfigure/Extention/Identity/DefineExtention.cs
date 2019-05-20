using System.Collections.Generic;
using AutoMapper;

using IdentityViewModels = Identity.ViewModels.ViewModels;
using IdentityViewModelsEn = Identity.ViewModels.ViewModelsEn;


namespace Pseez.Extentions.MapperConfigure.Extention.Identity
{
    public static partial class DefineExtention
    {
        #region Contact
        public static IdentityViewModelsEn.UserRoleViewModel MapFaToEn(this IdentityViewModels.UserRoleViewModel entity)
        {
            return Mapper.Map<IdentityViewModels.UserRoleViewModel, IdentityViewModelsEn.UserRoleViewModel>(entity);
        }

        public static IdentityViewModels.UserRoleViewModel MapEnToFa(this IdentityViewModelsEn.UserRoleViewModel entity)
        {
            return Mapper.Map<IdentityViewModelsEn.UserRoleViewModel, IdentityViewModels.UserRoleViewModel>(entity);
        }

        public static IEnumerable<IdentityViewModelsEn.UserRoleViewModel> MapFaToEn(this IEnumerable<IdentityViewModels.UserRoleViewModel> entity)
        {
            return Mapper.Map<IEnumerable<IdentityViewModels.UserRoleViewModel>, IEnumerable<IdentityViewModelsEn.UserRoleViewModel>>(entity);
        }

        public static IEnumerable<IdentityViewModels.UserRoleViewModel> MapEnToFa(this IEnumerable<IdentityViewModelsEn.UserRoleViewModel> entity)
        {
            return Mapper.Map<IEnumerable<IdentityViewModelsEn.UserRoleViewModel>, IEnumerable<IdentityViewModels.UserRoleViewModel>>(entity);
        }
        #endregion
    }
}