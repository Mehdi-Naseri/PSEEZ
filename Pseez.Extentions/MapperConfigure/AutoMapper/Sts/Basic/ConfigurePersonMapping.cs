using AutoMapper;
using Pseez.DomainClasses.Models.Sts.Basic;
using Pseez.ViewModels.ViewModels.Sts.Basic;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Basic
{
    public class ConfigurePersonMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Person, PersonViewModel>();
            Mapper.CreateMap<PersonViewModel, Person>();
        }
    }
}