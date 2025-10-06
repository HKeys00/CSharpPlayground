namespace Middleware
{
    public class MiddlewareClass
    {
        private readonly RequestDelegate _next;
        public MiddlewareClass(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("REQUEST GOES THROUGH HERE");
            await _next(context);
        }
    }

    public static class RequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddlewareClass(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MiddlewareClass>();
        }
    }
}
