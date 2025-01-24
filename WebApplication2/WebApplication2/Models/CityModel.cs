using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class CityModel
    {
        [Key]
        public Guid CityId { get; set; }
        public string? CityName { get; set; }
    }
}