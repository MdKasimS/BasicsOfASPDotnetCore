var builder = WebApplication.CreateBuilder(args);

//Creates an instance of our web application.
var app = builder.Build();

//Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Welcome from ASP.NET Core App!\n");
    await context.Response.WriteAsync("Begin: Middleware_1\n");

    //RequestDelegate next is the next() of middleware
    await next(context);

    await context.Response.WriteAsync("End  : Middleware_1\n");

});

//Middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Begin: Middleware_2\n");

    //RequestDelegate next is the next() of middleware
    await next(context);

    await context.Response.WriteAsync("End  : Middleware_2\n");
});

//Middleware 3
//Its a Treminal middleware aks ShortCircuiting middleware
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Begin: Middleware_3\n");
    await context.Response.WriteAsync("End  : Middleware_3\n");
});


app.Run();