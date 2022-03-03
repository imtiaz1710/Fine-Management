using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FineManagement.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection LoadApplicationDependencies(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            service.AddMediatR(Assembly.GetExecutingAssembly());

            return service;
        }
    }
}
