using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApplication2.Controllers
{
    public class CityController : ControllerBase
    {
        private readonly CitiesService _citiesService;
        public CityController()
        {
            _citiesService = new CitiesService();
        }
        [Route("/")]
        public IEnumerable GetCities()
        {
            return _citiesService.getCities();
        }
    }
}
