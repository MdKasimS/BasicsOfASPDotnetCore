using CalculatorASPWebApp.Controller;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<HomeController>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "This is my first ASP.NET Core empty web app");

app.Run();
