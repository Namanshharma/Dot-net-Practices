var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello !");

app.Use(async (HttpContext context, RequestDelegate requestDelegate) =>
{
    await context.Response.WriteAsync("This is just another middleware");
});

app.Run(async (HttpContext context) =>
{
    context.Response.StatusCode = 200;
    context.Request.Headers.ContentType = "text/plain";
    context.Response.Headers.ContentType = "text/plain";
    context.Response.Headers["My Key"] = "My Value";

    if (context.Request.Method == "Get")
    {
        if (context.Request.Query.ContainsKey("id"))
        {
            string id = context.Request.Query["id"];
        }
    }
    await context.Response.WriteAsync("Hello, I have set the status code to 204");
});

app.Run();

// if we want to set the Reverse proxy server then we can setup that in LaunchSetting.json file. There are 2 profiles in that, first one is for the Kestrel server
// which is the by default server provided and another server we can configure according to our requirement

// we have some of the middlewares present :- Map , Run 