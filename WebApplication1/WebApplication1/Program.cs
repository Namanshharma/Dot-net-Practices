using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomMiddleware>();  // here I have registered my custom middleware as a Transient service
var app = builder.Build();                          // once the builder object will Build then we can create the Middlewares

app.UseRouting();
app.UseEndpoints(x =>
{
    x.Map("/", async (HttpContext context) => { await context.Response.WriteAsync("This is home endpoint"); });
    // here we can add our endpoints
    x.Map("map", async (HttpContext context) => { await context.Response.WriteAsync("Hey, you just use Map method"); });
    x.MapGet("mapGet", async (HttpContext context) => { await context.Response.WriteAsync("Hey, you just use MapGet method"); });
});

// app.MapGet("/", () => "Hello !");

// app.Use(async (HttpContext context, RequestDelegate requestDelegate) =>
// {
//     await context.Response.WriteAsync("This is just another middleware");
//     await requestDelegate(context);         // this context will be received by the subsequent middleware as an argument
//     // this request delegate method is important for the middleware chaining
// });

// app.UseMiddleware<CustomMiddleware>();             // here I am actually calling that Custom middleware
// sometimes writing this UseMiddleware method and call our CustomMiddleware sometimes becomes lengthy process. So, it's resolution is that we can create THE EXTENSION METHOD.
// app.UseCustomMiddlewareExtensionMethod();           // <<--- by using this extension method there is no need to use [ app.UseMiddleware<CustomMiddleware>(); ]

// app.Run(async (HttpContext context) =>
// {
//     // context.Response.StatusCode = 200;
//     context.Request.Headers.ContentType = "text/plain";
//     if (context.Request.Method == "Get")
//     {
//         if (context.Request.Query.ContainsKey("id"))
//         {
//             string id = context.Request.Query["id"];
//         }
//     }
//     await context.Response.WriteAsync("Hello, I have set the status code to 204");
// });

app.Run();      // This Run Middleware is also called the TERMINATING Middleware

// if we want to set the Reverse proxy server then we can setup that in LaunchSetting.json file. There are 2 profiles in that, first one is for the Kestrel server
// which is the by default server provided and another server we can configure according to our requirement

// Middleware is a component which assembles into the application pipeline to handle the request and response 
// we have some of the middlewares present :- app.Map, app.Run ( shortcircuiting or terminating middleware ), app.Use , app.UseWhen ( runs conditionally)

// EXTENSION METHODS :- Method and class which includes extension method must be a static class. Also, method also needs to be a static
//                   :- Extension method is a method which is injected into an object dynamically 

// Right order of Middlewares
// :- app.UseExceptionHandler("/Error"); 
// :- app.UseHsts();                            <<----- HTTP strict transport security
// :- app.UseHttpsRedirection();
// :- app.UseStaticFiles();
// :- app.UseRouting();
// :- app.UseCors();
// :- app.UseAuthentication();
// :- app.UseAuthorization();
// :- app.UseSession();
// :- app.UseMapControllers();
// here we can add our custom middlewares
// :- app.Run();                                <<---- Terminating middleware

// Next step is Routing :- There are 2 middlewares are need to use 
// ==> app.UseRouting   <<---- When is method executes then appropriate endpoint will be selected. Becoz at the time of compilation all of the endpoints are compiled and stored in 
//                             the source code. And then based on the incoming request appropriate endpoint will be selected when this method executes. Now, once the appropriate endpoint is 
//                             selected then it will execute once the UseEnpoint method will call.
// ==> app.UseEndpoints(x => { here you can add your endpoints })
// ==> app.GetEndpoint  <<---- It used to get the name of the endpoint. Also, if we use GetEndpoint middleware before UseRouting then we will receive NULL in that case. But if we use
//                             GetEndpoint after useRouting then we will get the appropriate name of that endpoint.