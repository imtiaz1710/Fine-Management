using FineManagement.Core.Repositories;
using FineManagement.Core.Repositories.Base;
using FineManagement.Infrastructure.Constants;
using FineManagement.Infrastructure.Data;
using FineManagement.Infrastructure.Repositories;
using FineManagement.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineManagement.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection LoadInfrastructureDependencies(this IServiceCollection service)
        {
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return service;
        }

        public static IServiceCollection AddSql(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<FineManagementDbContext>(optionsBuilder =>
            {
                optionsBuilder
                    .UseSqlServer(configuration.GetConnectionString(ConfigurationConstant.ConnectionStringName),
                        options => options.EnableRetryOnFailure()
                    );
            });

            return service;
        }
    }
}
