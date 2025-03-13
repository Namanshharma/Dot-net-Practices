using Microsoft.AspNetCore.Mvc;
namespace CitiesManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public string Method()
        {
            return "Hello";
        }
    }
}
