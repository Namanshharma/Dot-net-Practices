namespace Entities;

/// <summary>
/// Domain model for storing Contry Details
/// </summary>
public class Country
{
    public Guid CountryId { get; set; }
    public string? CountryName { get; set; }
}
