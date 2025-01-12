var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "This is my first ASP.NET Core empty web app");

app.Run();
