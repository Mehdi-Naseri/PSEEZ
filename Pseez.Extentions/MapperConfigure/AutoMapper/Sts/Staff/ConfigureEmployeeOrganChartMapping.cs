﻿using AutoMapper;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ViewModels.ViewModels.Sts.Staff;

namespace Pseez.Extentions.MapperConfigure.AutoMapper.Sts.Staff
{
    public class ConfigureEmployeeOrganChartMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<EmployeeOrganChart, EmployeeOrganChartViewModel>();
            Mapper.CreateMap<EmployeeOrganChartViewModel, EmployeeOrganChart>();
        }
    }
}