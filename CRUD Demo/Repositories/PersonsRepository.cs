using System.Linq.Expressions;
using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
namespace Repositories;
public class PersonsRepository : IPersonsRepository
{
    private readonly CRUDDbContext _db;
    public PersonsRepository(CRUDDbContext db) { _db = db; }
    public async Task<Person> AddPerson(Person Person)
    {
        _db.Persons.Add(Person);
        await _db.SaveChangesAsync();
        return Person;
    }
    public async Task<bool> DeletePerson(Guid personId)
    {
        _db.Persons.RemoveRange(_db.Persons.Where(x => x.PersonId == personId));
        int rows = await _db.SaveChangesAsync();
        return rows > 0;
    }
    public async Task<List<Person>> GetAllPersons()
    {
        return await _db.Persons.Include("Country").ToListAsync();
    }
    public async Task<List<Person>> GetFilteredPerson(Expression<Func<Person, bool>> predicate)
    {
        return await _db.Persons.Include("Country").Where(predicate).ToListAsync();
    }
    public async Task<Person> GetPersonByPersonId(Guid personId)
    {
        return await _db.Persons.Include("Country").FirstOrDefaultAsync(x => x.PersonId == personId);
    }
    public async Task<Person> UpdatePerson(Person personUpdateRequest)
    {
        Person? matchingPerson = await _db.Persons.Include("Country").FirstOrDefaultAsync(x => x.PersonId == personUpdateRequest.PersonId);
        if (matchingPerson == null)
            return personUpdateRequest;
        matchingPerson.PersonName = personUpdateRequest.PersonName;
        matchingPerson.Address = personUpdateRequest.Address;
        matchingPerson.DateOfBirth = personUpdateRequest.DateOfBirth;
        matchingPerson.Email = personUpdateRequest.Email;
        matchingPerson.Gender = personUpdateRequest.Gender;
        matchingPerson.CountryId = personUpdateRequest.CountryId;
        matchingPerson.ReveiveNewsLetters = personUpdateRequest.ReveiveNewsLetters;
        await _db.SaveChangesAsync();
        return matchingPerson;
    }
}
