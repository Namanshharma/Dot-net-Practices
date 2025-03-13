using CitiesManager.WebAPI.DatabaseContext;
using CitiesManager.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CitiesManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public CitiesController(ApplicationDBContext applicationDBContext) { _applicationDBContext = applicationDBContext; }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            return await _applicationDBContext.Cities.OrderByDescending(x => x.CityName).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(Guid id)
        {
            var city = await _applicationDBContext.Cities.FindAsync(id);
            if (city == null)
                return NotFound();
            return city;
        }
            [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(Guid id, City city) { }
    }
}