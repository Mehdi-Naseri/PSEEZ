using AutoMapper;
using Pseez.DomainClasses.Models.PseezEnt.IT;
using Pseez.ViewModels.ViewModels.PseezEnt.IT;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.PseezEnt.IT
{
    public class ConfigureBackupMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Backup, BackupViewModel>();
            Mapper.CreateMap<BackupViewModel, Backup>();
        }
    }
}