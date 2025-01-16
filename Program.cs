var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoint =>
{
    endpoint.MapGet("/books/{id:int}", async (context1) =>
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

    endpoint.MapGet("/books/{authorName:alpha:length(5,15)}/{bookId:int}", async (context2) =>
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

    endpoint.MapGet("/quarterly-results/{year:int:min(1999)}/{month:regex(^(mar|jun|sep|dec)$)}", async (context1) =>
    {
        int year = Convert.ToInt32(context1.Request.RouteValues["year"]);
        string month = (context1.Request.RouteValues["month"].ToString());
        await context1.Response.WriteAsync($"Quarteyly Resulst For {year}-{month}");
    });

    endpoint.MapGet("/daily-results/{date:regex(^(19|21)$)}", async (context1) =>
    {
        int year = Convert.ToInt32(context1.Request.RouteValues["year"]);
        string month = (context1.Request.RouteValues["month"].ToString());
        await context1.Response.WriteAsync($"Quarteyly Resulst For {year}-{month}");
    });
});
app.Run(async (HttpContext context3) =>
{
    await context3.Response.WriteAsync($"Welcome to my ASP.NETCore app.{context3.Request.Path}");
});
app.Run();
