using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomMiddleware>();  // here I have registered my custom middleware as a Transient service
var app = builder.Build();                          // once the builder object will Build then we can create the Middlewares

app.MapGet("/", () => "Hello !");

app.Use(async (HttpContext context, RequestDelegate requestDelegate) =>
{
    await context.Response.WriteAsync("This is just another middleware");
    await requestDelegate(context);         // this context will be received by the subsequent middleware as an argument
    // this request delegate method is important for the middleware chaining
});

app.UseMiddleware<CustomMiddleware>();             // here I am actually calling that Custom middleware

app.Run(async (HttpContext context) =>
{
    // context.Response.StatusCode = 200;
    context.Request.Headers.ContentType = "text/plain";
    if (context.Request.Method == "Get")
    {
        if (context.Request.Query.ContainsKey("id"))
        {
            string id = context.Request.Query["id"];
        }
    }
    await context.Response.WriteAsync("Hello, I have set the status code to 204");
});

app.Run();      // This Run Middleware is also called the TERMINATING Middleware

// if we want to set the Reverse proxy server then we can setup that in LaunchSetting.json file. There are 2 profiles in that, first one is for the Kestrel server
// which is the by default server provided and another server we can configure according to our requirement

// Middleware is a component which assembles into the application pipeline to handle the request and response 
// we have some of the middlewares present :- app.Map, app.Run , app.Use