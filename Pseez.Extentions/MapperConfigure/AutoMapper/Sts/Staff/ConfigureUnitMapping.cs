using AutoMapper;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ViewModels.ViewModels.Sts.Staff;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Staff
{
    public class ConfigureUnitMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Unit, UnitViewModel>();
            Mapper.CreateMap<UnitViewModel, Unit>();
        }
    }
}