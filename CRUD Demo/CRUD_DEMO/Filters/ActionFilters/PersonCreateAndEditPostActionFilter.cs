using CRUD_DEMO.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using ServiceContracts;

namespace CRUD_DEMO.Filters.ActionFilters;
public class PersonCreateAndEditPostActionFilter : IAsyncActionFilter
{
    private readonly ICountriesService? _countriesService;
    public PersonCreateAndEditPostActionFilter(ICountriesService countriesService)
    {
        _countriesService = countriesService;
    }
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.Controller is PersonAPIController personAPIController)
        {
            if(!personAPIController.ModelState.IsValid){
                
            }
        }
        await next();
    }
}
