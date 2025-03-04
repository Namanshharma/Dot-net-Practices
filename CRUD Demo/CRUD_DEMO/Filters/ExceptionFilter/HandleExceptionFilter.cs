using Microsoft.AspNetCore.Mvc.Filters;
namespace CRUD_DEMO.Filters.ExceptionFilter;
public class HandleExceptionFilter : IExceptionFilter
{
    private readonly ILogger<HandleExceptionFilter> _logger;
    public HandleExceptionFilter(ILogger<HandleExceptionFilter> logger)
    {
        _logger = logger;
    }
    public void OnException(ExceptionContext context)
    {
          
    }
}
