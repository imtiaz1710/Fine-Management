using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MediatR;
using System.Text;
using System.Threading.Tasks;
using FineManagement.Core.Entities;

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
