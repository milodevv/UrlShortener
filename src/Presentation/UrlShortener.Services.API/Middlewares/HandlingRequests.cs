namespace UrlShortener.Services.API.Middlewares
{
    public class HandlingRequests
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HandlingRequests> _logger;

        public HandlingRequests(RequestDelegate next, ILogger<HandlingRequests> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Nueva peticion hacia el metodo: {context.Request.Method}, con cuerpo: {context.Request.Body.ToString()}");
            await _next(context);
            _logger.LogInformation($"Respuesta de la peticion hacia la ruta: {context.Request.Path}, con codigo de estado: {context.Response.StatusCode}");
        }
    }

    public static class HandlingRequestsExtensions
    {
        public static IApplicationBuilder UseHandlingRequests(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HandlingRequests>();
        }
    }
}
