var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*
 * ASP.NET Core is crucial for setting up routing in your web application.
 * UseRouting adds the routing middleware to the application's request pipeline. 
 * This middleware is responsible for matching incoming HTTP requests
 * to the endpoints defined in your application.
 * When a request is received, the routing middleware checks 
 * the request's path and method against the route templates defined in your app. 
 * Once a matching endpoint is found, the routing middleware prepares the endpoint 
 * to be executed later in the pipeline.
 * 
 */
app.UseRouting();

app.UseEndpoints(endpoint =>
{
    //Define routes

    endpoint.Map("/Home", async (context) =>
    {
        await context.Response.WriteAsync($"You are in Home Page.");
    });

    endpoint.MapGet("/Product", async (context) =>
    {
        await context.Response.WriteAsync($"You are in Products Page. GET");
    });

    endpoint.MapPost("/Product", async (context) =>
    {
        await context.Response.WriteAsync($"You are in Products Page. POST");
    });

    endpoint.MapPost("/Contact", async (context) =>
    {
        await context.Response.WriteAsync($"You are in Contact Page.");
    });

});

app.Run(async (HttpContext context) => { 
    await context.Response.WriteAsync(
        $"The page you are looking for is not found.");
});
app.Run();


