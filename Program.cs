var builder = WebApplication.CreateBuilder(args);
//Creates instance of our Web Application
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoint =>
{
    endpoint.MapGet("/products/{id}", async (context) =>
    {
        var id = Convert.ToInt32(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"This is product id = {id}");
    });

    endpoint.MapGet("/books/{bookId}/{authorName}", async (context) =>
    {
        var BookId = Convert.ToInt32(context.Request.RouteValues["bookId"]);
        var Author = context.Request.RouteValues["authorName"].ToString();
        await context.Response.WriteAsync($"Book Details\n Id: {BookId} \n Author Name :{Author}\n");
    });
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Welcome to my ASP.NETCore app.");
});

app.Run();
