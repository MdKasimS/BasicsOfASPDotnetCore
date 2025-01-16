var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<HomeController>();
builder.Services.AddControllers();

//Creates instance of our Web Application
var app = builder.Build();

app.MapControllers();

//app.MapGet("/", () => "This is my first ASP.NET Core empty web app");
app.Run();

#region 

/*This line when un commented for attribute basd routing using controllers
 * doesn't allow other routes to match
 */

/*  app.Run(async (HttpContext context) =>
*   {
*       await context.Response.WriteAsync("The page you are looking not found.");
*   });
*/

#endregion

