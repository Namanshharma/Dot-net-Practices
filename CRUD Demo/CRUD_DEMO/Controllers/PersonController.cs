using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;
namespace CRUD_DEMO.Controllers
{
    public class PersonController : Controller
    {
        private readonly ICountriesService _countriesService;
        private readonly IPersonsService _personsService;
        public PersonController(IPersonsService personsService, ICountriesService countriesService)
        {
            _countriesService = countriesService; _personsService = personsService;
        }
        // [Route("person/index")]
        // [Route("/")]
        public ActionResult Index()
        {
            List<PersonResponse> persons = _personsService.GetAllPersons();
            return View(persons);
        }
        // [Route("person/create")]
        // [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
