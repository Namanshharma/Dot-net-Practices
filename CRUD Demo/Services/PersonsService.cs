using System.Reflection;
using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;
namespace Services;
public class PersonsService : IPersonsService
{
    public readonly List<Person> _personList;
    public readonly ICountriesService _countriesService;
    public PersonsService(CountriesService countriesService)
    {
        _personList = new List<Person>();
        _countriesService = countriesService;
    }
    public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
    {
        // if (personAddRequest == null) { throw new ArgumentNullException(nameof(personAddRequest)); }
        // if (string.IsNullOrEmpty(personAddRequest.PersonName)) { throw new ArgumentException("Person Name cannot be empty"); }
        // INSTEAD OF THIS IF CONDIIONT VALIDATION :- we will use Data Model validaitons by using Validation Context
        if (personAddRequest != null)
        {
            ValidationHelper.ModelValidation(personAddRequest);
            Person person = personAddRequest.ToPerson();
            person.PersonId = Guid.NewGuid();
            _personList.Add(person);
            PersonResponse personResponse = person.ToPersonResponse();
            personResponse.Country = _countriesService?.GetCountryByCountryId(person.CountryId)?.CountryName;
            return personResponse;
        }
        else
            return new PersonResponse();
    }
    public List<PersonResponse> GetAllPersons()
    {
        return _personList.Select(x => x.ToPersonResponse()).ToList();
    }
    public PersonResponse GetPersonByPersonId(Guid? personId)
    {
        if (string.IsNullOrEmpty(personId.ToString()))
            throw new ArgumentNullException("Must provide Person ID");
        Person? personDetails = _personList.FirstOrDefault(x => x.PersonId == personId);
        return personDetails == null ? throw new Exception() : personDetails.ToPersonResponse();
    }
    public List<PersonResponse> GetFilteredPerson(string? propertyName, string? searchString)
    {
        List<PersonResponse> allPersonList = GetAllPersons();
        List<PersonResponse> matchingPerson = allPersonList;
        if (string.IsNullOrEmpty(propertyName))
            return matchingPerson;

        if (!string.IsNullOrEmpty(propertyName) && !string.IsNullOrEmpty(searchString))
        {
            PropertyInfo? actualPropertyName = typeof(PersonResponse).GetProperty(propertyName, BindingFlags.IgnoreCase);
            // matchingPerson = matchingPerson.Where(x =>
            // {
            //     var value = actualPropertyName?.GetValue(x) as string;
            // });
        }
        return new List<PersonResponse>();
    }
}