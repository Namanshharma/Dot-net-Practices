using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services;

public class CountriesService : ICountriesService
{
    private readonly List<Country> _countries;
    public CountriesService(bool isInitialize = true)
    {
        _countries = new List<Country>();
        if (isInitialize)
        {
            _countries.AddRange(new List<Country>{
            new Country { CountryId = Guid.Parse("15e6d2c4-87ba-4120-a4f2-128739120dca"), CountryName = "India" },
            new Country { CountryId = Guid.Parse("7d5fdc7a-1c24-4d85-a322-9dd32b32c730"), CountryName = "Pankistan" },
            new Country { CountryId = Guid.Parse("d6e2bff4-2a60-4b65-a3a8-906713109c12"), CountryName = "China" },
            new Country { CountryId = Guid.Parse("a4a9fbf9-747f-4cb0-9606-4b2622d1a30a"), CountryName = "Nepal" },
            new Country { CountryId = Guid.Parse("a8ecceb1-bbfd-45a3-82b7-bd79667421c9"), CountryName = "Bhutan" }
            });
        }
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
