using System.Reflection;
using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.DTO.Enums;
using Services.Helpers;
namespace Services;
public class PersonsService : IPersonsService
{
    public readonly List<Person> _personList;
    public readonly ICountriesService _countriesService;
    public PersonsService(CountriesService countriesService, bool isInitialze = true)
    {
        _personList = new List<Person>();
        _countriesService = countriesService;

        if (isInitialze)
        {
            _personList.AddRange(new List<Person>
            {
                new Person{PersonId = Guid.Parse("ea1d955a-a2f5-475b-8a48-5dd9c2a61883"), PersonName = "Melinda" , Email = "mdouris0@github.io" , DateOfBirth = DateTime.ParseExact("1995-11-07", "yyyy-MM-dd", null), Gender = "Male" ,Address = "2178 Fair Oaks Park" , ReveiveNewsLetters = false, CountryId = Guid.Parse("15e6d2c4-87ba-4120-a4f2-128739120dca")},
                new Person{PersonId = Guid.Parse("3b7666cd-f0e5-4a00-8567-c559223c39dd"), PersonName = "Gibb" , Email = "gcrumb1@hubpages.com" , DateOfBirth = DateTime.ParseExact("2014-07-03", "yyyy-MM-dd", null), Gender = "Female" ,Address = "6443 Southridge Lane" , ReveiveNewsLetters = true, CountryId = Guid.Parse("d6e2bff4-2a60-4b65-a3a8-906713109c12")},
                new Person{PersonId = Guid.Parse("b38ddef5-6930-4b6d-a06b-e2d8c6c70ffe"), PersonName = "Enriqueta" , Email = "ecunniffe2@pen.io" , DateOfBirth = DateTime.ParseExact("1997-08-13", "yyyy-MM-dd", null), Gender = "Female" ,Address = "672 Sachtjen Park" , ReveiveNewsLetters = true, CountryId = Guid.Parse("a4a9fbf9-747f-4cb0-9606-4b2622d1a30a")}
            });
        }
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
        Person? matchingPerson = _personList.FirstOrDefault(x => x.PersonId == personUpdateRequest.PersonId);
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

        return matchingPerson.ToPersonResponse();
    }

    public bool DeletePerson(Guid personId)
    {
        if (string.IsNullOrEmpty(personId.ToString())) throw new ArgumentNullException("Person ID can not be empty");

        Person? matchedPerson = _personList.FirstOrDefault(x => x.PersonId == personId);
        if (matchedPerson == null) return false;
        _personList.RemoveAll(temp => temp.PersonId == matchedPerson.PersonId);
        return true;
    }
}