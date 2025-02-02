using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;
namespace CRUD_DEMO.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonAPIController : ControllerBase
    {
        private readonly ICountriesService _countriesService;
        private readonly IPersonsService _personsService;
        public PersonAPIController(IPersonsService personsService, ICountriesService countriesService)
        {
            _countriesService = countriesService; _personsService = personsService;
        }
        [Route("GetAllPersons")]
        public List<PersonResponse> GetAllPersons()
        {
            return _personsService.GetAllPersons();
        }
    }
}
