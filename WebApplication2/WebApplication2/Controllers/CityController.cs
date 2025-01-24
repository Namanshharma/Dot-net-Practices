using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]         // by using this solid brackets and put inside "controller" in that will automatically takes CityController or we can also write ("/CityController")
    public class CityController : ControllerBase
    {
        private readonly CitiesService _citiesService;
        public CityController()
        {
            _citiesService = new CitiesService(); // here this is the bad practice that we are creating an instance of service but instead of this we need to register this service and then use it by using DI
                                                  // right now it is called DIRECT DEPENDENCY 
        }
        [HttpGet]
        public IEnumerable GetCities()
        {
            return _citiesService.GetCities();
        }
    }
}

// _citiesService = new CitiesService(); <<---- this is a problematic thing becoz by doing this controller is directly dependent on service. So the solution of this problem is DIP
// The upper approach have DEPENDENCY PROBLEM which means the higher level class is dependent on the lower level class. which creates a problem
// DIP ( DEPENDENCY INVERSION PRINCIPLE ) <<---- It says that the Higher level class must not be dependent on the lower level class instead both must depend upon ABSTRACTION.