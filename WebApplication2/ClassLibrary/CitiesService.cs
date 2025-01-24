namespace Services;

public class CitiesService
{
    private List<string> cities;
    public CitiesService()
    {
        cities = new List<string> { "Amritsar", "Jalandhar", "Mohali", "Chandigarh", "Panchkula", "Hauz Khaz" };
    }
    // From the controller prespective :- Create a method which will fetch the data of cities
    public List<string> GetCities()
    {
        return cities;
    }
    public string SetCity(string cityName)
    {
        cities.Add(cityName);
        return $"{cityName} is added successfully";
    }
}
