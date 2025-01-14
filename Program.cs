using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;


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
using System.Xml.Linq;

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
//app.MapGet("/", (HttpContext context) =>
//{
//    /*string path = context.Request.Path;
//     * string method = context.Request.Method;
//     * int status = context.Response.StatusCode;
//     */
//    /*var UserAgent = "";
//     *if (context.Request.Headers.ContainsKey("User-Agent"))
//     *{
//     *    //All keys are going to be string in headers
//     *    UserAgent = context.Request.Headers["User-Agent"];
//     *    context.Response.StatusCode = 200;
//     */

//    context.Response.Headers["Content-Type"] = "text/html";
//    context.Response.Headers["MyHeader"] = "Hello World!";
//    return $"<h2>This is text response</h2>";
//});

app.Run(async (HttpContext context)=>
{
    string path = context.Request.Path;
    string method = context.Request.Method;

    //check case sensitivity for Home and home
    //not handling /home/ or say /product/
    if (path=="/" || path=="/Home" || path == "/home")
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("You are in Home Page.");
    }
    else if(path=="/Contact" || path == "/contact")
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("You are in Contact Page.");
    }
    else if (method=="GET" && (path == "/Product" || path == "/product"))
    {
        //You have to set the response before sending the body
        context.Response.StatusCode = 200;

        if(context.Request.Query.ContainsKey("id")
            && context.Request.Query.ContainsKey("name"))
        {
            string id = context.Request.Query["id"];
            string name = context.Request.Query["name"];
            await context.Response.WriteAsync($"You selected with product id={id} and {name}");

            return;
        }
        
        await context.Response.WriteAsync("You are in Product Page.");
    }
    else if (method=="POST" && (path == "/Product" || path == "/product"))
    {
        string id = "";
        string name = "";
        context.Response.StatusCode = 200;

        StreamReader reader = new StreamReader(context.Request.Body);
        string data = await reader.ReadToEndAsync();

        Dictionary<string,StringValues> dict = QueryHelpers.ParseQuery(data);

        if (dict.ContainsKey("id"))
        {
            id = dict["id"];
        }

        if (dict.ContainsKey("name"))
        {
            name = dict["name"];
        }
        await context.Response.WriteAsync($"Request Body Contains: \n id= {id} & name= {name}");

    }
    else
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("The page you are looking for not found.");
    }
});

app.Run();
