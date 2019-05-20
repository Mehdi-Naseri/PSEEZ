using AutoMapper;
using Pseez.DomainClasses.Models.PseezEnt.Cmms;
using Pseez.ViewModels.ViewModels.PseezEnt.Cmms;


namespace Pseez.Extentions.MapperConfigure.AutoMapper.PseezEnt.Cmms
{
    public class ConfigureRepairRequestMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<RepairRequest, RepairRequestViewModel>();
            Mapper.CreateMap<RepairRequestViewModel, RepairRequest>();
        }
    }
}