using AutoMapper;
using SEG.Azure.Entities;
using SEG.Azure.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEG.Azure.Web
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            ConfigureEntityViewModelMapping();
        }

        private static void ConfigureEntityViewModelMapping()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Employee, EmployeeViewModel>();
            });
        }
    }
}