var builder = WebApplication.CreateBuilder(args);
//Creates instance of our Web Application
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoint =>
{
    endpoint.MapGet("/products/id/{id=100}", async (context) =>
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

    endpoint.MapGet("/books/{authorName='kasim'}/{bookId?}", async (context) =>
    {
        var Author = context.Request.RouteValues["authorName"].ToString();
        var BookId = context.Request.RouteValues["bookId"];
        if (BookId != null)
        {
            BookId = Convert.ToInt32(BookId);
            await context.Response.WriteAsync($"Book Details\n Id: {BookId} \n Author Name :{Author}\n");

        }
        else
        {
            await context.Response.WriteAsync($"Displaying All Books By {Author}:-");
        }
    });
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Welcome to my ASP.NETCore app.");
});

app.Run();
