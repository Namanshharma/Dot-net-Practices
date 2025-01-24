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
            _citiesService = new CitiesService();
        }
        [HttpGet]
        public IEnumerable GetCities()
        {
            return _citiesService.getCities();
        }
    }
}
