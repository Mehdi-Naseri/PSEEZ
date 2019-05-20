﻿using AutoMapper;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ViewModels.ViewModels.Sts.Staff;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Staff
{
    public class ConfigureDegreeStateMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<DegreeState, DegreeStateViewModel>();
            Mapper.CreateMap<DegreeStateViewModel, DegreeState>();
        }
    }
}