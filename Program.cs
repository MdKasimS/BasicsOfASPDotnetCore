var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Creates an instance of our web application.
var app = builder.Build();

//Its a Treminal middleware aks ShortCircuiting middleware
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello World");

});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello World 2");
});
