using AutoMapper;
using Pseez.DomainClasses.Models.Sts.Journey;
using Pseez.ViewModels.ViewModels.Sts.Journey;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Journey
{
    public class ConfigureTimeTableMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<TimeTable, TimeTableViewModel>();
            Mapper.CreateMap<TimeTableViewModel, TimeTable>();
        }
    }
}