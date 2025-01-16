var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "staticFiles"
});
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", () => "This is my first ASP.NET Core empty web app");

app.Run();
