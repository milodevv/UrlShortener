namespace UrlShortener.Services.API.Middlewares
{
    public class HandlingRequests
    {
        private readonly RequestDelegate _next;

        public HandlingRequests(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"NUEVA PETICION HACIA LA RUTA: {context.Request.Path}, CON CUERPO: {context.Request.Body.ToString()}");
            await _next(context);
            Console.WriteLine($"RESPUESTA DE LA PETICION HACIA LA RUTA: {context.Request.Path}, CON CODIGO DE ESTADO: {context.Response.StatusCode}");
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
