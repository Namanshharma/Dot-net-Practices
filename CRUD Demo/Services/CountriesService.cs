using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
namespace Services;
public class CountriesService : ICountriesService
{
    private readonly CRUDDbContext _db;
    public CountriesService(CRUDDbContext db) { _db = db; }
    public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
    {
        if (countryAddRequest == null) { throw new ArgumentNullException(nameof(countryAddRequest)); }
        if (countryAddRequest.CountryName == null) { throw new ArgumentNullException(nameof(countryAddRequest.CountryName)); }
        if (_db.Countries.Count(x => x.CountryName == countryAddRequest.CountryName) > 0) { throw new ArgumentException("Given Country name is already present"); }

        Country country = countryAddRequest.ToCountry();
        country.CountryId = Guid.NewGuid();
        _db.Countries.Add(country);
        _db.SaveChanges();                      

        return country.ToCountryResponse();
    }
    public List<CountryResponse> GetAllCountries()
    {
        return _db.Countries.Select(x => x.ToCountryResponse()).ToList();
    }
    public CountryResponse? GetCountryByCountryId(Guid? countryId)
    {
        if (countryId == null) { throw new ArgumentNullException(countryId.ToString() + "argument is null"); }
        Country? country = _db.Countries.FirstOrDefault<Country>(x => x.CountryId == countryId);
        if (country == null) { return null; }
        return country?.ToCountryResponse();
    }
}
