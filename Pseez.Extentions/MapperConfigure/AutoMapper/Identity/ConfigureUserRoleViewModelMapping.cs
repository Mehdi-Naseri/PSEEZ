using AutoMapper;

using Identity.ViewModels;
using IdentityViewModels = Identity.ViewModels.ViewModels;
using IdentityViewModelsEn = Identity.ViewModels.ViewModelsEn;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.Identity
{
    public class ConfigureUserRoleViewModelMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<IdentityViewModels.UserRoleViewModel, IdentityViewModelsEn.UserRoleViewModel>();
            Mapper.CreateMap<IdentityViewModelsEn.UserRoleViewModel, IdentityViewModels.UserRoleViewModel>();
        }
    }
}