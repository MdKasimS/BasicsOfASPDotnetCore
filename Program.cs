var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoint =>
{
    endpoint.MapGet("/products/{id}", async (context) =>
    {
        var id = Convert.ToInt32(context.Request.RouteValues["id"]);
        await context.Response.WriteAsJsonAsync($"This is product id = {id}");
    });
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Welcome to my ASP.NETCore app.");
});



app.Run();
