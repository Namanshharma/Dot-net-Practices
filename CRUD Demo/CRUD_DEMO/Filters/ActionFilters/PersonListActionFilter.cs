using Microsoft.AspNetCore.Mvc.Filters;
namespace CRUD_DEMO.Filters.ActionFilters;
public class PersonListActionFilter : IActionFilter // Always inherit from INTERFACE
{
    private readonly ILogger<PersonListActionFilter> _logger;
    private readonly string _key;
    private readonly string _value;
    // public PersonListActionFilter(ILogger<PersonListActionFilter> logger) { _logger = logger; }
    public PersonListActionFilter(ILogger<PersonListActionFilter> logger, string key, string value) { _logger = logger; _key = key; _value = value; }
    // in this way we can accept the arguments   <<----- also called parameterized action filter
    public void OnActionExecuted(ActionExecutedContext context)
    // it can manipulate the View Data
    // It can change the result returned from Aciton method
    // it can throw exceptions to either return the exception to the exception filter or return the error response to the browser
    {
        _logger.LogInformation("After the execution of Action Filter this OnActionExecuted method is called"); 
    }
    public void OnActionExecuting(ActionExecutingContext context)
    // in this method we can read the method parameters, check them and manipulate them as well
    // Also It can validate action method parameters as well. 
    // It can short circuit the action ( prevent the action method from execution ) and return a different IActionResult
    {
        _logger.LogInformation("Before the execution of Action Filter this OnActionExecuting method is called");
        string? z = Convert.ToString(context.ActionArguments["Email"]);
        string? z1 = context.ActionArguments["Email"]?.ToString();

    }
}