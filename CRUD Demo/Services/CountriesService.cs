using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services;

public class CountriesService : ICountriesService
{
    private readonly List<Country> _countries;
    public CountriesService()
    {
        _countries = new List<Country>();
    }
    public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
    {
        if (countryAddRequest == null) { throw new ArgumentNullException(nameof(countryAddRequest)); }
        if (countryAddRequest.CountryName == null) { throw new ArgumentNullException(nameof(countryAddRequest.CountryName)); }
        if (_countries.Where(x => x.CountryName == countryAddRequest.CountryName).Count() > 0) { throw new ArgumentException("Given country already exists"); }
        Country country = countryAddRequest.ToCountry();
        country.CountryId = Guid.NewGuid();
        _countries.Add(country);
        return country.ToCountryResponse();
    }
    public List<CountryResponse> GetAllCountries()
    {
        return _countries.Select(x => x.ToCountryResponse()).ToList();
    }
    public CountryResponse? GetCountryByCountryId(Guid? countryId)
    {
        if (countryId == null) { throw new ArgumentNullException(countryId.ToString() + "argument is null"); }
        Country? country = _countries.FirstOrDefault<Country>(x => x.CountryId == countryId);
        if (country == null) { return null; }
        return country?.ToCountryResponse();
    }
}
