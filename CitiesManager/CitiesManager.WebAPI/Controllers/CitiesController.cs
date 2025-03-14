using System.Data;
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
        [HttpPut("{cityId}")]
        public async Task<IActionResult> PutCity(Guid cityId, City city)
        {
            if (cityId != city.CityId)
                return BadRequest();
            var existingCity = await _applicationDBContext.Cities.FindAsync(cityId);
            if (existingCity == null) return NotFound();
            existingCity.CityName = city.CityName;
            try
            {
                await _applicationDBContext.SaveChangesAsync();
            }
            catch (DBConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            if (_applicationDBContext.Cities == null) return Problem("Cities Entity is null");
            _applicationDBContext.Cities.Add(city);
            await _applicationDBContext.SaveChangesAsync();
            return CreatedAtAction("GetCity", new { cityId = city.CityId }, city);
        }
    }
}