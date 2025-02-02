using ServiceContracts;
using Services;

namespace CRUDTests;

public class CountriesServiceTest
{
    public readonly ICountriesService? _countriesService;

    public CountriesServiceTest()
    {
        _countriesService = new CountriesService();
    }
    // When CountryAddRequest is null then it should throws Argument Null Exception
    // When country Name is null then it should throw Argument exception
}