using UrlShortener.Persistence.Configurations;

namespace UrlShortener.Services.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.Configure<ShortLinkSettings>(configuration.GetSection("ShortLinkSettings"));
            services.AddOptions<ShortLinkSettings>()
                .Bind(configuration.GetSection("ShortLinkSettings"))
                .Validate(s => s.Length > 0 && !string.IsNullOrWhiteSpace(s.Alphabet), "ShortLinkSettings inválido");
            services.AddMemoryCache();
            return services;
        }
    }
}
