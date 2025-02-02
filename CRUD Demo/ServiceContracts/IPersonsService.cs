using ServiceContracts.DTO;
using ServiceContracts.DTO.Enums;

namespace ServiceContracts;
public interface IPersonsService
{
    PersonResponse AddPerson(PersonAddRequest? personAddRequest);
    List<PersonResponse> GetAllPersons();
    PersonResponse GetPersonByPersonId(Guid? personId);
    List<PersonResponse> GetFilteredPerson(string? propertyName, string? searchString);
    List<PersonResponse> GetSortedPerson(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder);
    PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest);
    bool DeletePerson(Guid personId);
}
