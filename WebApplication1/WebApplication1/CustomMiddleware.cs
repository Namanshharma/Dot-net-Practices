
namespace WebApplication1
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("\n Hi, this is my custom middleware starts   \n");
            await next(context);
            await context.Response.WriteAsync("\n Hi, this is my custom middleware ends     \n");
        }
    }
}