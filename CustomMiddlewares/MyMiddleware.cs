
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace CalculatorASPWebApp.CustomMiddlewares
{
    public class MyMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //Before Logic
            await context.Response.WriteAsync("Begin: Custom Middleware Started....\n");
            await next(context);

            //After Logic
            await context.Response.WriteAsync("End  : Custom Middleware Ended....\n");

        }
    }

    public static class MyMiddlewareExtension
    { 
        public static IApplicationBuilder MyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddleware>();
        }
    }

}

