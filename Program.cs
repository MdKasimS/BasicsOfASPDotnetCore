
/*
 * is used in ASP.NET Core to set up and configure your web application. This is a convenience class provided by ASP.NET Core to configure and create applications.
 * it simplifies and streamlines the process of setting up your ASP.NET Core application. 
 * Instead of manually configuring all the different components needed for your app to work, 
 * WebApplicationBuilder wraps all those steps into a more user-friendly package.
 * 
 * A] Aggregates Configuration: It brings together configuration settings (like app settings and environment variables) under one unified interface.
 * B] Registers Services: It streamlines the addition of essential services (like DI, logging, and routing) to your app.
 * C] Builds the App: It simplifies the creation of the WebApplication object, which is essential to actually running your application.
 */
var builder = WebApplication.CreateBuilder(args);

/*
 * The builder object allows you to configure services (like dependency injection, logging, etc.) 
 * and middleware (like request handling, routing, etc.) for your web app.
 */
var app = builder.Build();


/*
 * The app.MapGet("/") method in ASP.NET Core sets up a route that listens for GET requests to the root URL ("/"). 
 * When a GET request is made to this route, it triggers a callback function
 *  that returns the string "This is my first ASP.NET Core empty web app."
 *  
 *  This can also receive HttpContext object parameter.
 */
app.MapGet("/", (HttpContext context) =>
{
    //string path = context.Request.Path;
    //string method = context.Request.Method;
    //int status = context.Response.StatusCode;

    var UserAgent = "";
    if (context.Request.Headers.ContainsKey("User-Agent"))
    {
        //All keys are going to be string in headers
        UserAgent = context.Request.Headers["User-Agent"];
    }

    context.Response.StatusCode = 200;
    return $"user Agent : {UserAgent}";
});

app.Run();
