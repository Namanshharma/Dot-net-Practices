using Microsoft.AspNetCore.Mvc.Filters;
namespace CRUD_DEMO.Filters.ActionFilters;
public class PersonListActionFilter : IActionFilter
{
    private readonly ILogger<PersonListActionFilter> _logger;
    public PersonListActionFilter(ILogger<PersonListActionFilter> logger)
    {
        _logger = logger;
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation("After the execution of Action Filter this OnActionExecuted method is called");
    }
    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation("Before the execution of Action Filter this OnActionExecuting method is called");
    }
}