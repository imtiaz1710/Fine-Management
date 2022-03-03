using FineManagement.Core.Entities;
using FineManagement.Core.Repositories.Base;
using FineManagement.Infrastructure.Constants;
using FineManagement.Infrastructure.Data;
using FineManagement.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FineManagement.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection LoadInfrastructureDependencies(this IServiceCollection service)
        {
            service.AddScoped<IRepository<User, int>, Repository<User, int>>();
            service.AddScoped<IRepository<Team, int>, Repository<Team, int>>();
            service.AddScoped<IRepository<UserTeam, int>, Repository<UserTeam, int>>();
            service.AddScoped<IRepository<Fine, int>, Repository<Fine, int>>();
            service.AddScoped<IRepository<Transaction, int>, Repository<Transaction, int>>();

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
