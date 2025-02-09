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
        public PersonAPIController(IPersonsService personsService, ICountriesService countriesService)
        {
            _countriesService = countriesService;
            _personsService = personsService;
        }
        [HttpGet]
        [Route("/")]
        public async Task<List<PersonResponse>> GetAllPersons()
        {
            try
            {
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
                if (ModelState.IsValid)
                    return await _personsService.AddPerson(personAddRequest);
                else
                    return new PersonResponse();
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