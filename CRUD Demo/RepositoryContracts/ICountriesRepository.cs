using Entities;
namespace RepositoryContracts;
public interface ICountriesRepository
{
    Task<Country> AddCountry(Country? Country);
    Task<List<Country>> GetAllCountries();
    Task<Country>? GetCountryByCountryId(Guid countryId);
}
