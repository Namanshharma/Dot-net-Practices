using Entities;

namespace ServiceContracts.DTO;
public class PersonResponse
{
    public Guid PersonId { get; set; }
    public string? PersonName { get; set; }
    public string? Email { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public Guid? CountryId { get; set; }
    public string? Country { get; set; }
    public string? Address { get; set; }
    public bool? ReveiveNewsLetters { get; set; }
    public string? Age { get; set; }
}
public static class PersonExtension
{
    public static PersonResponse ToPersonResponse(this Person person)
    {
        return new PersonResponse()
        {
            PersonId = person.PersonId,
            PersonName = person.PersonName,
            Email = person.Email,
            DateOfBirth = person.DateOfBirth,
            Address = person.Address,
            ReveiveNewsLetters = person.ReveiveNewsLetters,
            Gender = person.Gender,
            CountryId = person.CountryId,
            Age = (person.DateOfBirth != null) ? Math.Round((DateTime.Now - person.DateOfBirth.Value).TotalDays / 365.25).ToString() : null
        };
    }
}