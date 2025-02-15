using CRUD_DEMO.Filters.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;
namespace CRUD_DEMO.Controllers
{
    [Route("[controller]")]         // by default it create person/
    [ApiController]
    public class PersonAPIController : ControllerBase
    {
        private readonly ICountriesService _countriesService;
        private readonly IPersonsService _personsService;
        private readonly ILogger<PersonAPIController> _logger;
        public PersonAPIController(IPersonsService personsService, ICountriesService countriesService, ILogger<PersonAPIController> logger)
        {
            _countriesService = countriesService;
            _personsService = personsService;
            _logger = logger;
        }
        [HttpGet]
        [Route("/")]
        [TypeFilter(typeof(PersonListActionFilter))]            // by doing this we have added out Action filter 
        public async Task<List<PersonResponse>> GetAllPersons()
        {
            try
            {
                _logger.LogInformation("Reached At Get All persons Endpoint");
                return await _personsService.GetAllPersons();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<PersonResponse> AddPerson(PersonAddRequest? personAddRequest)
        {
            try
            {
                _logger.LogInformation("Reached At Add Person Endpoint");
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Payload of Add Person Endpoint", personAddRequest);
                    return await _personsService.AddPerson(personAddRequest);
                }
                else
                {
                    _logger.LogInformation("Payload is not valid");
                    return new PersonResponse();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<PersonResponse> GetPersonByPersonId(Guid? PersonId)
        {
            try
            {
                return await _personsService.GetPersonByPersonId(PersonId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<PersonResponse> UpdatePerson(PersonUpdateRequest? personUpdateRequest)
        {
            try
            {
                return await _personsService.UpdatePerson(personUpdateRequest);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        [HttpDelete]
        [Route("[action]")]
        public async Task<bool> DeletePerson(Guid PersonId)
        {
            try
            {
                return await _personsService.DeletePerson(PersonId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}