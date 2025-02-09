using ServiceContracts.DTO;
using ServiceContracts.DTO.Enums;

namespace ServiceContracts;
public interface IPersonsService
{
    Task<PersonResponse> AddPerson(PersonAddRequest? personAddRequest);
    Task<List<PersonResponse>> GetAllPersons();
    Task<PersonResponse> GetPersonByPersonId(Guid? personId);
    Task<List<PersonResponse>> GetFilteredPerson(string? propertyName, string? searchString);
    Task<List<PersonResponse>> GetSortedPerson(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder);
    Task<PersonResponse> UpdatePerson(PersonUpdateRequest? personUpdateRequest);
    Task<bool> DeletePerson(Guid personId);
}
