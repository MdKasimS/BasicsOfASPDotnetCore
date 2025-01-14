using CalculatorASPWebApp.CustomMiddlewares;

var builder = WebApplication.CreateBuilder(args);

//provides instance using DI
builder.Services.AddTransient<MyMiddleware>();

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

//Middleware 3 - "Custom Middleware"
//app.UseMiddleware<MyMiddleware>();
//Implemented extension to custom middleware so IntelliSense access it as method
app.MyMiddleware();


//Middleware 4
app.UseWhen(context => context.Request.Query.ContainsKey("IsAuthorized")
    && context.Request.Query["IsAuthorized"]=="true"
, app =>
{
    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("Begin: Middleware_4\n");
        await next(context);
        await context.Response.WriteAsync("End  : Middleware_4\n");

    });
} );

//Middleware 5
//Its a Treminal middleware aks ShortCircuiting middleware
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Begin: Middleware_5\n");
    await context.Response.WriteAsync("End  : Middleware_5\n");
});


app.Run();