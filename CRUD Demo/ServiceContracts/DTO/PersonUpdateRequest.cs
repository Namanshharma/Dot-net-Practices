using System.ComponentModel.DataAnnotations;
using Entities;
using ServiceContracts.DTO.Enums;

namespace ServiceContracts.DTO;
public class PersonUpdateRequest
{
    [Required(ErrorMessage = "PersonId can not be blank")]
    public Guid PersonId { get; set; }
    [Required(ErrorMessage = "Person Name can not be blank")]
    public string? PersonName { get; set; }
    [Required(ErrorMessage = "Email can't be blank")]
    [EmailAddress(ErrorMessage = "Please enter valid email")]
    public string? Email { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public GenderEnumeration? Gender { get; set; }
    public Guid? CountryId { get; set; }
    public string? Address { get; set; }
    public bool? ReveiveNewsLetters { get; set; }

    public Person ToPerson()
    {
        return new Person
        {
            PersonId = PersonId,
            PersonName = PersonName,
            Email = Email,
            DateOfBirth = DateOfBirth,
            Gender = Gender.ToString(),
            Address = Address,
            CountryId = CountryId
        };
    }
}
