using Data.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EmDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
#if DEBUG
                options.EnableSensitiveDataLogging();
#endif
            }
            );

            services.AddScoped<Func<EmDbContext>>((provider) => () => provider.GetService<EmDbContext>());

            services.AddRepositories();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

          
            return services;
        }
    }
}
