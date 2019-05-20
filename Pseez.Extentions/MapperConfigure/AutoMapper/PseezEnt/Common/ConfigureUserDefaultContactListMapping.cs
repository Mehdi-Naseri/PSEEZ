using AutoMapper;
using Pseez.DomainClasses.Models.PseezEnt.Common;
using Pseez.ViewModels.ViewModels.PseezEnt.Common;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.PseezEnt.Common
{
    public class ConfigureUserDefaultContactListMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<UserDefaultContactList, UserDefaultContactListViewModel>();
            Mapper.CreateMap<UserDefaultContactListViewModel, UserDefaultContactList>();
        }
    }
}