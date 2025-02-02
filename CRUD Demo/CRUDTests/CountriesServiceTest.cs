using ServiceContracts;
using Services;

namespace CRUDTests;

public class CountriesServiceTest
{
    public readonly ICountriesService? _countriesService;

    public CountriesServiceTest(ICountriesService countriesService)
    {
        _countriesService = countriesService;
    }
    // When CountryAddRequest is null then it should throws Argument Null Exception
    // When country Name is null then it should throw Argument exception
}