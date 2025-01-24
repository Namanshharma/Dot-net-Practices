var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddTransient<HomeController1>();        // if application will become larger then in that case we will not add controller name one by one but instead of that we will use
builder.Services.AddControllers();                          // this addController extension method and this will automatically picks all of the controllers from application and map here
// builder.Services.AddTransient<CustomMiddleware>();       // here I have registered my custom middleware as a Transient service
var app = builder.Build();                                  // once the builder object will Build then we can create the Middlewares

// app.UseRouting();
// app.UseEndpoints(x =>
// {
//     x.MapControllers();                 // while registering the endpoints we will never register them individually but we will register them by using the extension method
// });
// instead of above 2 methods for controller we can simply call in single statement :- app.MapControllers() which internally take care of both of these extension methods
// app.MapControllers();


// app.UseStaticFiles()                             // by adding this we are informing application that from wwwroot folder we will access some static files

// app.UseRouting();
// app.UseEndpoints(x =>
// {
//     // here we can add our endpoints

//     x.Map("/", async (HttpContext context) => { await context.Response.WriteAsync("This is home endpoint"); });
//     // x.Map("map", async (HttpContext context) => { await context.Response.WriteAsync("Hey, you just use Map method"); });
//     // x.MapGet("mapGet", async (HttpContext context) => { await context.Response.WriteAsync("Hey, you just use MapGet method"); });

//     // here is the exmaple of Route parameter
//     // x.Map("routeParameters/{firstRouteParameter}", async context =>
//     // {
//     //     string routeParameter = context.Request.RouteValues["firstRouteParameter"].ToString();
//     //     await context.Response.WriteAsync($"Here is the first route which is having RouteParameter name :- {routeParameter}");
//     // });
// });

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

app.Run();      // This Run Middleware is also called the TERMINATING Middleware        // if this RUN method is not present then our server will never run

// if we want to set the REVERSE PROXY SERVER then we can setup that in LaunchSetting.json file. There are 2 profiles in that, first one is for the Kestrel server
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
// There is one exmaple of Route parameter as well. Also we can give the DEFAULT ROUTE PARAMETER as well by doing something like :- x.Map("routeParameters/{firstRouteParameter=demo}", context
// Similar to Default route parameter we also have OPTIONAL ROUTE PARAMETER :- x.Map("routeParameters/{firstRouteParameter?}"   <-- In this case, if user doesn't provide any value to the 
//                                                                          route parameter then in that case it would be null
// In this routing, we also have concept of Contraint :- x.Map("routeParameter/{firstRoute:int?}" <<---- by doing this we are confirming that the optional parameter must have int value

// Next step is Controllers :- After creating the controller we need to do 2 things 
//  ---->> We need to register the controller class as a service and for this we can use this :- builder.Services.AddTransient<HomeController1>(); but when our application will become larger
//         then we do not register each controller one by one. So instead of this we wiil use :- builder.Services.AddControllers(); this ADD CONTROLLER EXTENSION METHOD
//  ---->> 2nd we need to enable Routing before use of controllers and then for the use of Controllers we will register them in app.UseEndpoint() extension method. Also in this we will not
//         register each and every endpoint one by one but we will use the MAP CONTROLLER EXTENSION METHOD here which automatically picks as of the endpoints. like here is an example for the 
//         same :- app.UseEndpoints(x => { x.MapControllers(); });
//  ---->> Also in 2nd step by using app.UseRouting and app.UseEndpoint we can directly use APP.MAPCONTROLLER EXTENSION METHOD which internally calls both of the above mentioned methods

// Next step is Model Bindings :- And the information related to the Model binding is present in the HOME CONTROLLER 

// Next step is for Services and Dependency Injection