using System.Reflection;
using Entities;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.DTO.Enums;
using Services.Helpers;
namespace Services;
public class PersonsService : IPersonsService
{
    public readonly CRUDDbContext _db;
    public readonly ICountriesService _countriesService;
    public PersonsService(ICountriesService countriesService, CRUDDbContext databaseDbContext)
    {
        _db = databaseDbContext;
        _countriesService = countriesService;
    }
    public async Task<PersonResponse> AddPerson(PersonAddRequest? personAddRequest)
    {
        if (personAddRequest != null)
        {
            ValidationHelper.ModelValidation(personAddRequest);

            Person person = personAddRequest.ToPerson();
            person.PersonId = Guid.NewGuid();
            // _db.Persons.Add(person);
            // _db.SaveChanges();
            int count = await _db.sp_AddPerson(person);       // when we want to add the data by using SP
            if (count > 0)
            {
                PersonResponse personResponse = person.ToPersonResponse();
                CountryResponse? countryResponse = await _countriesService?.GetCountryByCountryId(person.CountryId);
                if (countryResponse != null)
                    personResponse.Country = countryResponse.CountryName;
                return personResponse;
            }
            else
                return new PersonResponse();
        }
        else
            return new PersonResponse();
    }
    public async Task<List<PersonResponse>> GetAllPersons()
    {
        // List<Person> personList = _db.Persons.Select(x => x).ToList();  
        // return personList.Select(x => x.ToPersonResponse()).ToList();

        // another way to implement this 
        // return _db.Persons.ToList().Select(x => x.ToPersonResponse()).ToList();         // more optimized way is to convert first into array by using list() and then convert each row
        List<Person> persons = await _db.sp_GetAllPersons();
        return persons.Select(x => x.ToPersonResponse()).ToList();
    }
    public async Task<PersonResponse> GetPersonByPersonId(Guid? personId)
    {
        if (string.IsNullOrEmpty(personId.ToString()))
            throw new ArgumentNullException("Must provide Person ID");
        Person? personDetails = await _db.Persons.FirstOrDefaultAsync(x => x.PersonId == personId);
        return personDetails == null ? throw new Exception() : personDetails.ToPersonResponse();
    }
    public async Task<List<PersonResponse>> GetFilteredPerson(string? propertyName, string? searchString)   // TO DO 
    {
        List<PersonResponse> allPersonList = await GetAllPersons();
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
    public async Task<List<PersonResponse>> GetSortedPerson(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder)
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
    public async Task<PersonResponse> UpdatePerson(PersonUpdateRequest? personUpdateRequest)
    {
        if (personUpdateRequest == null) throw new ArgumentException(nameof(Person));
        ValidationHelper.ModelValidation(personUpdateRequest);

        Person? matchingPerson = await _db.Persons.FirstOrDefaultAsync(x => x.PersonId == personUpdateRequest.PersonId);
        if (matchingPerson == null)
            throw new ArgumentException("Give person ID doesn't match");

        matchingPerson.PersonName = personUpdateRequest.PersonName;
        matchingPerson.Address = personUpdateRequest.Address;
        matchingPerson.DateOfBirth = personUpdateRequest.DateOfBirth;
        matchingPerson.Email = personUpdateRequest.Email;
        matchingPerson.Gender = personUpdateRequest.Gender.ToString();
        matchingPerson.CountryId = personUpdateRequest.CountryId;
        matchingPerson.ReveiveNewsLetters = personUpdateRequest.ReveiveNewsLetters;
        await _db.SaveChangesAsync();

        return matchingPerson.ToPersonResponse();
    }
    public async Task<bool> DeletePerson(Guid personId)
    {
        if (string.IsNullOrEmpty(personId.ToString())) throw new ArgumentNullException("Person ID can not be empty");

        Person? matchedPerson = await _db.Persons.FirstOrDefaultAsync(x => x.PersonId == personId);
        if (matchedPerson == null) return false;

        _db.Persons.Remove(await _db.Persons.FirstAsync(temp => temp.PersonId == matchedPerson.PersonId));
        await _db.SaveChangesAsync();

        return true;
    }
}