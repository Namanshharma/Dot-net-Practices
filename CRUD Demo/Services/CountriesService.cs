using Entities;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services;
public class CountriesService : ICountriesService
{
    private readonly ICountriesRepository _countiresRepository;
    public CountriesService(ICountriesRepository countriesRepository) { _countiresRepository = countriesRepository; }
    public async Task<CountryResponse> AddCountry(CountryAddRequest? countryAddRequest)
    {
        if (countryAddRequest == null) { throw new ArgumentNullException(nameof(countryAddRequest)); }
        if (countryAddRequest.CountryName == null) { throw new ArgumentNullException(nameof(countryAddRequest.CountryName)); }
        // if (await _countiresRepository..CountAsync(x => x.CountryName == countryAddRequest.CountryName) > 0) { throw new ArgumentException("Given Country name is already present"); }

        Country country = countryAddRequest.ToCountry();
        country.CountryId = Guid.NewGuid();
        await _countiresRepository.AddCountry(country);
        return country.ToCountryResponse();
    }
    public async Task<List<CountryResponse>> GetAllCountries()
    {
        return (await _countiresRepository.GetAllCountries()).Select(x => x.ToCountryResponse()).ToList();
    }
    public async Task<CountryResponse>? GetCountryByCountryId(Guid? countryId)
    {
        if (countryId == null) { throw new ArgumentNullException(countryId.ToString() + "argument is null"); }
        Country? country = await _countiresRepository.GetCountryByCountryId(countryId.Value);

        if (country == null) { return null; }
        return country?.ToCountryResponse();
    }
}
