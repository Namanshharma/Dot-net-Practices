// namespace CRUD_DEMO.Filters;
// public class FiltersTheory
// {
// }

// What are filters :- 
// Filters are the code blocks that execute before and after sepcific stages in Filter Pipleline. Filters performs specific tasks such as Authorization, Caching, Exception handling etc
// After the routing middleware, our request enters into the MVC surveyer lines in which it first tries to pick up the appropriate action based on the incoming route.
// Once the Routing middleware picks up the action method then it executes the filter pipeline. Filter pipeline contains different types of filter methods. Some of them executes before
// action method and some of them executes after action method

// Endpoint middleware --> Authroization filter ( OnAuthorization ) --> Resource filter ( OnResourceExecuting ) --> Model binding and Validation 
// --> Action filter ( onActionExecuting ) --> Action method -->  Action Filter ( onActionExecuted ) --> Exception Filter ( OnException ) --> Result Filter ( OnResultExecuting )
// --> IActionResult method --> Result filter ( onResultExecuted ) --> Resource Filter ( onResourceExecuted ) --> 

// So, 3 filters have OnExecuting and OnExecuted Methods :- Resource filter, Action Filter, Result filter 
// Similary, Authorization and Exception filter have only 1 method in it.


// There are different type of Scopes of Filter :- GLOBAL LEVEL FILTER, CLASS LEVEL FILTER, METHOD LEVEL FILTER
// Syntax of Class level and Method level filter is same. When we use the TypeFilter as an attribute for class ( Controller ) then that becomes Class Level filter where as when we use TypeFilter 
// attribute with specific method ( Endpoint, API ) then that becomes Method Level filter

// Global level filter needs to add in the program.cs file while adding the extension method :- AddController(x => x.Filters.Add< Filter Class Name >()) but by using this you can not pass the 
// arguments to the filter. So there is one another way to instantiate the filter in program.cs file

// builder.Service.AddControllers(x => x.Filters.Add( new FilterClassName (ILogger<>,"My Global Key","My Global Value") ))

// IServiceCollection <<---- responsible to store the services but builder.Services.BuildServiceProvider()  <<---- this method is responsible to dispatch the service instances
// Already present in Program.cs file


// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// Async Filters :- Normal filters inherit from IAcitonFilter interface. Where as Async Action filters inherit from IAsyncActionFilter interface.

// Further it includes the Next() method or a delegate. If we don't call the next() delegate then our filter will be short-circuited

// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// Result filters :- 

// :- Runs immediately before and after an IActionResult executes.
// :- OnResultExecuting method ---->> It can access the IActionResult returned by action method
// ---->> It can continue executing the IActionResult normally, by not assigning "Result" property of context
// ---->> It can short circuit the action and return a different IActionResult.

// :- OnResultExecuted method ---->> It can manipulate the last minute changes in the response such as adding the necessary response headers
// ---->> It should not throw exceptions because, exceptions reaised in result filter would not be caugth by the Exception filter.


// -------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// Resource Filter :- Inherit from IAsyncResourceFilter 

// -------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// Authorization filter :- Runs before any other filter in the pipeline <<----- Must inherits from IAuthorization Filter or IAsyncAuthorizationFIlter

// :- OnAuthorize method ---->> Determines whether the user is Authorized for the request
//                      ---->> Short circuit the pipeline if the request is not Authorized
//                      ---->> Don't throws exceptions on this method, as they will not be handle by Exception filters.

// From HttpContext of this methods context we can get the Request Cookies and check the expected Key is present or not. If not then it means our User is not logged in so we dont want
// him to use the resources of our application. Then in that case we short circuit the reqest from here.

// -------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// Exception Filter :- Runs when any exception is raised during the filter pipeline.    <<---- Inherits from IAsyncExceptionFilter and it contains only single method
// Exception handling middleware is better choice than this becuase that is having more broader scope than this Exception filter