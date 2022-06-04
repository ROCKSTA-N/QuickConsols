using Application.Interfaces;
using Application.Mappers;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddAutoMapperProfiles();

            return services;
        }

        private static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            var automapperAssemblies = new Assembly[]
            {
                typeof(Mapper).Assembly
            };
            services.AddAutoMapper(automapperAssemblies);

            return services;
        }
    }
}
