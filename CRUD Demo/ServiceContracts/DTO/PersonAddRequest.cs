using System.ComponentModel.DataAnnotations;
using Entities;
using ServiceContracts.DTO.Enums;
namespace ServiceContracts.DTO;
public class PersonAddRequest
{
    [Required(ErrorMessage = "Person Name can not be blank")]
    public string? PersonName { get; set; }
    [Required(ErrorMessage = "Email can't be blank")]
    [EmailAddress(ErrorMessage = "Please enter valid email")]
    public string? Email { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public GenderEnumeration? Gender { get; set; }
    public Guid? CountryId { get; set; }
    public string? Address { get; set; }
    public Person ToPerson()
    {
        return new Person()
        {
            PersonName = PersonName,
            Email = Email,
            DateOfBirth = DateOfBirth,
            Gender = Gender.ToString(),
            CountryId = CountryId,
            Address = Address
        };
    }
}
