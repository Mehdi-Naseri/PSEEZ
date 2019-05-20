using AutoMapper;
using Pseez.Extentions.MapperConfigure.AutoMapper.Identity;
using Pseez.Extentions.MapperConfigure.AutoMapper.PseezEnt.Common;
using Pseez.Extentions.MapperConfigure.AutoMapper.PseezEnt.IT;
using Pseez.Extentions.MapperConfigure.AutoMapper.PseezEnt.VisitRegistration;
using Pseez.Extentions.MapperConfigure.AutoMapper.PseezEnt.Pmbok;
using Pseez.Extentions.MapperConfigure.AutoMapper.PseezEnt.Cmms;
using Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Basic;
using Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Journey;
using Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Staff;

namespace Pseez.Extentions.MapperConfigure.AutoMapper
{
    public class ConfigureMapping
    {
        public static void Configure()
        {
            // PseezEnt

            //Common
            //Contact
            Mapper.Configuration.AddProfile(new ConfigureContactGroupMapping());
            Mapper.Configuration.AddProfile(new ConfigureContactListMapping());
            Mapper.Configuration.AddProfile(new ConfigureContactMapping());
            Mapper.Configuration.AddProfile(new ConfigureUserContactListMapping());
            Mapper.Configuration.AddProfile(new ConfigureUserDefaultContactListMapping());

            //IT
            Mapper.Configuration.AddProfile(new ConfigureServerMapping());
            Mapper.Configuration.AddProfile(new ConfigureBackupMapping());

            //VisitRegistration
            Mapper.Configuration.AddProfile(new ConfigureRegistrationMapping());

            //Pmbok
            Mapper.Configuration.AddProfile(new ConfigureProjectDocumentFileDeletedMapping());
            Mapper.Configuration.AddProfile(new ConfigureProjectDocumentFileMapping());
            Mapper.Configuration.AddProfile(new ConfigureProjectDocumentValueMapping());
            Mapper.Configuration.AddProfile(new ConfigureProjectMapping());

            //Cmms
            Mapper.Configuration.AddProfile(new ConfigureRepairRequestMapping());
            Mapper.Configuration.AddProfile(new ConfigureRequestUserMapping());
            Mapper.Configuration.AddProfile(new ConfigureRequestPlanningMapping());
            Mapper.Configuration.AddProfile(new ConfigureRequestTechnitionMapping());



            ////////////////////////////////////
            ////        Identity          /////
            ////////////////////////////////////
            Mapper.Configuration.AddProfile(new ConfigureUserRoleViewModelMapping());



            ////////////////////////////////////
            ////          Sts              /////
            ////////////////////////////////////
            // Sts.Basic
            Mapper.Configuration.AddProfile(new ConfigureCityMapping());
            Mapper.Configuration.AddProfile(new ConfigureGenderMapping());
            Mapper.Configuration.AddProfile(new ConfigurePersonMapping());
            Mapper.Configuration.AddProfile(new ConfigureProvinceMapping());
            // Sts.Journey
            Mapper.Configuration.AddProfile(new ConfigureProviderMapping());
            Mapper.Configuration.AddProfile(new ConfigureReservationPersonListMapping());
            Mapper.Configuration.AddProfile(new ConfigureTimeTableMapping());
            // Sts.Staff
            Mapper.Configuration.AddProfile(new ConfigureBloodTypeMapping());
            Mapper.Configuration.AddProfile(new ConfigureDegreeStateMapping());
            Mapper.Configuration.AddProfile(new ConfigureEmployeeAcademicalResumeMapping());
            Mapper.Configuration.AddProfile(new ConfigureEmployeeFamilialTypeMapping());
            Mapper.Configuration.AddProfile(new ConfigureEmployeeMapping());
            Mapper.Configuration.AddProfile(new ConfigureEmployeeOrganChartMapping());
            Mapper.Configuration.AddProfile(new ConfigureFamilialTypeMapping());
            Mapper.Configuration.AddProfile(new ConfigureOrganChartMapping());
            Mapper.Configuration.AddProfile(new ConfigureReligionMapping());
            Mapper.Configuration.AddProfile(new ConfigureUnitMapping());
        }
    }
}