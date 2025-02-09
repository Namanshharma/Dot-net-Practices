using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities;
public class Person
{
    [Key]
    public Guid PersonId { get; set; }
    [StringLength(40)]
    public string? PersonName { get; set; }
    [StringLength(40)]
    public string? Email { get; set; }
    public DateTime? DateOfBirth { get; set; }
    [StringLength(6)]
    public string? Gender { get; set; }
    public Guid? CountryId { get; set; }
    [StringLength(200)]
    public string? Address { get; set; }
    public bool? ReveiveNewsLetters { get; set; }
    [ForeignKey("CountryId")]
    public virtual Country? Country { get; set; }
}

// [ForeignKey("CountryId")]
// public Country? Country { get; set; }        // but by using this when we try to fetch the data from DBSet then initally we need to Mention this property name
// Like _db.Person.Include("Country").ToList();                     // here Country is the name of property which we have mentioned in this Class

// We can create the extension method even for the Sealed class