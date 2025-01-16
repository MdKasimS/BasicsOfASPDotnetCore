var builder = WebApplication.CreateBuilder(args);
//Creates instance of our Web Application
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoint =>
{
    endpoint.MapGet("/products/id/{id?}", async (context) =>
    {
        var id = context.Request.RouteValues["id"];

        if (id != null)
        {
            id = Convert.ToInt32(id);
            await context.Response.WriteAsync($"This is product id = {id}");

        }
        else
        {
            await context.Response.WriteAsync($"You are in Products Page.");
        }
    });

    endpoint.MapGet("/books/{authorName='kasim'}/{bookId=100}", async (context) =>
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
