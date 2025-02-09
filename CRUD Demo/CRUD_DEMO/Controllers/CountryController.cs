using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;
namespace CRUD_DEMO.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountriesService _countriesService;
        private readonly IPersonsService _personsService;
        public CountryController(ICountriesService countriesService, IPersonsService personsService)
        {
            _countriesService = countriesService; _personsService = personsService;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<List<CountryResponse>> GetAllCountries()
        {
            try { return await _countriesService.GetAllCountries(); }
            catch (Exception ex) { throw new Exception(ex.Message, ex.InnerException); }
        }
    }
}
