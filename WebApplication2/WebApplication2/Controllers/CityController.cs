using InterfaceClassLibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]         // by using this solid brackets and put inside "controller" in that will automatically takes CityController or we can also write ("/CityController")
    public class CityController : ControllerBase
    {
        private readonly ICityServices _citiesService1;
        public CityController(ICityServices cityServices1)  //  // By doing this way, this is called Constructor injection
        {
            // _citiesService = new CitiesService(); // here this is the bad practice that we are creating an instance of service but instead of this we need to register this service and then use it by using DI
            // right now it is called DIRECT DEPENDENCY 
            _citiesService1 = cityServices1;                  // DI is implemented here as it is a object from IOC container
        }
        [HttpGet]
        public ReturnObject GetCities()
        {
            var response = _citiesService1.GetCities();
            return new ReturnObject
            {
                City = response.Item1,
                ServiceId = response.Item2
            };
        }
        // [HttpGet]
        // public IEnumerable GetCities([FromServices] ICityServices _cityServices)     // by injecting service this way we call it a Method injection
        // {
        //     return _citiesService.GetCities();
        // }
    }

    public class ReturnObject
    {
        public List<string>? City { get; set; }
        public Guid? ServiceId { get; set; }
    }
}

// _citiesService = new CitiesService(); <<---- this is a problematic thing becoz by doing this controller is directly dependent on service. So the solution of this problem is DIP
// The upper approach have DEPENDENCY PROBLEM which means the higher level class is dependent on the lower level class. which creates a problem
// DIP ( DEPENDENCY INVERSION PRINCIPLE ) <<---- It says that the Higher level class must not be dependent on the lower level class instead both must depend upon ABSTRACTION.
// This comes from the Program.cs file :- ICityServices cityServices like from the IOC container