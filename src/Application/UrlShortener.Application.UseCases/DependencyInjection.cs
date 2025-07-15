using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UrlShortener.Application.UseCases.Mappings;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.UseCases
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(typeof(MappingsProfile).Assembly);
                cfg.AddMaps(typeof(ShortenedUrl).Assembly);
            });

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
