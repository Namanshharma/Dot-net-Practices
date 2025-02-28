using Microsoft.AspNetCore.Mvc.Filters;
namespace CRUD_DEMO.Filters.ResultFilter;
public class PersonsListResultFilter : IAsyncResultFilter, IOrderedFilter
{
    public int Order => throw new NotImplementedException();
    private readonly ILogger<PersonsListResultFilter> _logger;
    public PersonsListResultFilter(ILogger<PersonsListResultFilter> logger) { _logger = logger; }
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        await next();
    }
}
