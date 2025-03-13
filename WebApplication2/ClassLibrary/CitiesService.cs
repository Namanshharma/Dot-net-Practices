using InterfaceClassLibrary;

namespace Services;

public class CitiesService : ICityServices
{
    private List<string> cities;
    private Guid ServiceId { get; set; }
    public CitiesService()
    {
        cities = new List<string> { "Amritsar", "Jalandhar", "Mohali", "Chandigarh", "Panchkula", "Hauz Khaz" };
    }
    public (List<string>, Guid) GetCities()
    {
        ServiceId = Guid.NewGuid();
        return (cities, ServiceId);
    }
    public string SetCity(string cityName)
    {
        cities.Add(cityName);
        return $"{cityName} is added successfully";
    }
}
