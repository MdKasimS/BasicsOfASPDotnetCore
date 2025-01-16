var builder = WebApplication.CreateBuilder(args);
//Creates instance of our Web Application
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoint =>
{
    endpoint.MapGet("/products/id/{id:int}", async (context1) =>
    {
        var id = context1.Request.RouteValues["id"];

        if (id != null)
        {
            id = Convert.ToInt32(id);
            await context1.Response.WriteAsync($"This is product id = {id}");

        }
        else
        {
            await context1.Response.WriteAsync($"You are in Products Page.");
        }
    });

    endpoint.MapGet("/books/{authorName='kasim'}/{bookId?}", async (context2) =>
    {
        var Author = context2.Request.RouteValues["authorName"].ToString();
        var BookId = context2.Request.RouteValues["bookId"];
        if (BookId != null)
        {
            BookId = Convert.ToInt32(BookId);
            await context2.Response.WriteAsync($"Book Details\n Id: {BookId} \n Author Name :{Author}\n");
        }
        else
        {
            await context2.Response.WriteAsync($"Displaying All Books By {Author}:-");
        }
    });
});

app.Run(async (HttpContext context3) =>
{
    await context3.Response.WriteAsync("Welcome to my ASP.NETCore app.");
});

app.Run();
