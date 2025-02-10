using System.Linq.Expressions;
using Entities;

namespace RepositoryContracts;
public interface IPersonsRepository
{
    Task<Person> AddPerson(Person Person);
    Task<List<Person>> GetAllPersons();
    Task<Person> GetPersonByPersonId(Guid personId);
    Task<List<Person>> GetFilteredPerson(Expression<Func<Person, bool>> predicate);
    Task<Person> UpdatePerson(Person personUpdateRequest);
    Task<bool> DeletePerson(Guid personId);
}
