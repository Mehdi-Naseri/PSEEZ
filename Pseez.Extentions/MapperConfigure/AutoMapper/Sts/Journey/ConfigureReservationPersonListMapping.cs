using AutoMapper;
using Pseez.DomainClasses.Models.Sts.Journey;
using Pseez.ViewModels.ViewModels.Sts.Journey;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Journey
{
    public class ConfigureReservationPersonListMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ReservationPersonList, ReservationPersonListViewModel>();
            Mapper.CreateMap<ReservationPersonListViewModel, ReservationPersonList>();
        }
    }
}