using System.Reflection;
using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.DTO.Enums;
using Services.Helpers;
namespace Services;
public class PersonsService : IPersonsService
{
    // public readonly List<Person> _personList;
    public readonly CRUDDbContext _db;
    public readonly ICountriesService _countriesService;
    public PersonsService(ICountriesService countriesService, CRUDDbContext databaseDbContext)
    {
        _db = databaseDbContext;
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
            // _personList.Add(person);
            _db.Persons.Add(person);
            _db.SaveChanges();
            PersonResponse personResponse = person.ToPersonResponse();
            personResponse.Country = _countriesService?.GetCountryByCountryId(person.CountryId)?.CountryName;
            return personResponse;
        }
        else
            return new PersonResponse();
    }
    public List<PersonResponse> GetAllPersons()
    {
        // return _personList.Select(x => x.ToPersonResponse()).ToList();
        // return _db.Persons.Select(x => x.ToPersonResponse()).ToList();       // in this case we will encountered one error that cannot evaluate the expression in linq


        // List<Person> personList = _db.Persons.Select(x => x).ToList();
        // return personList.Select(x => x.ToPersonResponse()).ToList();

        // another way to implement this 
        return _db.Persons.ToList().Select(x => x.ToPersonResponse()).ToList();         // more optimized way
    }
    public PersonResponse GetPersonByPersonId(Guid? personId)
    {
        if (string.IsNullOrEmpty(personId.ToString()))
            throw new ArgumentNullException("Must provide Person ID");
        // Person? personDetails = _personList.FirstOrDefault(x => x.PersonId == personId);
        Person? personDetails = _db.Persons.FirstOrDefault(x => x.PersonId == personId);
        return personDetails == null ? throw new Exception() : personDetails.ToPersonResponse();
    }
    public List<PersonResponse> GetFilteredPerson(string? propertyName, string? searchString)   // TO DO 
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

    public List<PersonResponse> GetSortedPerson(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder)
    {
        if (string.IsNullOrEmpty(sortBy))
            return allPersons;

        List<PersonResponse> sortedPersons = (sortBy, sortOrder) switch
        {
            (nameof(PersonResponse.PersonName), SortOrderOptions.ASC) => allPersons.OrderBy(x => x.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),
            (nameof(PersonResponse.PersonName), SortOrderOptions.DESC) => allPersons.OrderByDescending(x => x.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),
            (nameof(PersonResponse.Email), SortOrderOptions.ASC) => allPersons.OrderBy(x => x.Email, StringComparer.OrdinalIgnoreCase).ToList(),
            (nameof(PersonResponse.Email), SortOrderOptions.DESC) => allPersons.OrderByDescending(x => x.Email, StringComparer.OrdinalIgnoreCase).ToList(),
            (nameof(PersonResponse.DateOfBirth), SortOrderOptions.ASC) => allPersons.OrderBy(x => x.DateOfBirth).ToList(),
            (nameof(PersonResponse.DateOfBirth), SortOrderOptions.DESC) => allPersons.OrderByDescending(x => x.DateOfBirth).ToList(),
            (nameof(PersonResponse.Age), SortOrderOptions.ASC) => allPersons.OrderBy(x => x.Age).ToList(),
            (nameof(PersonResponse.Age), SortOrderOptions.DESC) => allPersons.OrderByDescending(x => x.Age).ToList(),
            (nameof(PersonResponse.Gender), SortOrderOptions.ASC) => allPersons.OrderBy(x => x.Gender).ToList(),
            (nameof(PersonResponse.Gender), SortOrderOptions.DESC) => allPersons.OrderByDescending(x => x.Gender).ToList(),
            (nameof(PersonResponse.Country), SortOrderOptions.ASC) => allPersons.OrderBy(x => x.Country, StringComparer.OrdinalIgnoreCase).ToList(),
            (nameof(PersonResponse.Country), SortOrderOptions.DESC) => allPersons.OrderByDescending(x => x.Country, StringComparer.OrdinalIgnoreCase).ToList(),
            (nameof(PersonResponse.Address), SortOrderOptions.ASC) => allPersons.OrderBy(x => x.Address, StringComparer.OrdinalIgnoreCase).ToList(),
            (nameof(PersonResponse.Address), SortOrderOptions.DESC) => allPersons.OrderByDescending(x => x.Address, StringComparer.OrdinalIgnoreCase).ToList(),
            (nameof(PersonResponse.ReveiveNewsLetters), SortOrderOptions.ASC) => allPersons.OrderBy(x => x.ReveiveNewsLetters).ToList(),
            (nameof(PersonResponse.ReveiveNewsLetters), SortOrderOptions.DESC) => allPersons.OrderByDescending(x => x.ReveiveNewsLetters).ToList(),
            _ => allPersons
        };
        return sortedPersons;
    }
    public PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest)
    {
        if (personUpdateRequest == null) throw new ArgumentException(nameof(Person));
        ValidationHelper.ModelValidation(personUpdateRequest);
        // Person? matchingPerson = _personList.FirstOrDefault(x => x.PersonId == personUpdateRequest.PersonId);
        Person? matchingPerson = _db.Persons.FirstOrDefault(x => x.PersonId == personUpdateRequest.PersonId);
        if (matchingPerson == null)
        {
            throw new ArgumentException("Give person ID doesn't match");
        }

        matchingPerson.PersonName = personUpdateRequest.PersonName;
        matchingPerson.Address = personUpdateRequest.Address;
        matchingPerson.DateOfBirth = personUpdateRequest.DateOfBirth;
        matchingPerson.Email = personUpdateRequest.Email;
        matchingPerson.Gender = personUpdateRequest.Gender.ToString();
        matchingPerson.CountryId = personUpdateRequest.CountryId;
        matchingPerson.ReveiveNewsLetters = personUpdateRequest.ReveiveNewsLetters;

        _db.SaveChanges();
        return matchingPerson.ToPersonResponse();
    }

    public bool DeletePerson(Guid personId)
    {
        if (string.IsNullOrEmpty(personId.ToString())) throw new ArgumentNullException("Person ID can not be empty");

        // Person? matchedPerson = _personList.FirstOrDefault(x => x.PersonId == personId);
        Person? matchedPerson = _db.Persons.FirstOrDefault(x => x.PersonId == personId);
        if (matchedPerson == null) return false;
        // _personList.RemoveAll(temp => temp.PersonId == matchedPerson.PersonId);
        _db.Persons.Remove(_db.Persons.First(temp => temp.PersonId == matchedPerson.PersonId));
        _db.SaveChanges();
        return true;
    }
}