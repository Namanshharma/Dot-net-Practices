using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUD_DEMO.Filters.ActionFilters;
public class TestingActionFilter : IAsyncActionFilter //, IOrderedFilter
{
    private readonly ILogger<TestingActionFilter> _logger;
    private readonly string _key;
    private readonly string _value;
    // public int Order => throw new NotImplementedException();
    public TestingActionFilter(ILogger<TestingActionFilter> logger, string key, string Value)
    {
        _logger = logger; _key = key; _value = Value;
    }
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // OnExecuting Method logic need to be place here
        await next();                                           // calls the subsequent filter or action method 
        // OnExecuted method logic need to be place here
    }
}
