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
        public List<PersonResponse> GetAllPersons()
        {
            try
            {
                return _personsService.GetAllPersons();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        [HttpPost]
        [Route("[action]")]
        public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
        {
            try
            {
                if (ModelState.IsValid)
                    return _personsService.AddPerson(personAddRequest);
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
        public PersonResponse GetPersonByPersonId(Guid? PersonId)
        {
            try
            {
                return _personsService.GetPersonByPersonId(PersonId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        [HttpPost]
        [Route("[action]")]
        public PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest)
        {
            try
            {
                return _personsService.UpdatePerson(personUpdateRequest);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        [HttpDelete]
        [Route("[action]")]
        public bool DeletePerson(Guid PersonId)
        {
            try
            {
                return _personsService.DeletePerson(PersonId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
