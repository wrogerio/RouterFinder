using Microsoft.Extensions.DependencyInjection;
using RouterFinder.Application;
using RouterFinder.Application.Interfaces;
using RouterFinder.Application.Mappings;
using RouterFinder.Domain.Interfaces.Repositories;
using RouterFinder.Domain.Interfaces.Services;
using RouterFinder.Domain.Services;
using RouterFinder.Infra.Context;
using RouterFinder.Infra.Repository;

namespace RouterFinder.IoC
{
    public class NativeInjector
    {
        public static void RegisterApp(IServiceCollection service)
        {
            // Application
            service.AddScoped<IRouteAppService, RouteAppService>();

            // Domain
            service.AddScoped<IRouteService, RouteService>();

            // Infra
            service.AddScoped<IRouteRepository, RouteRepository>();

            // Mappings
            service.AddScoped<RouterFinderContext>();

            // AutoMapper
            service.AddAutoMapper(typeof(MappingProfile));
        }
    }
}