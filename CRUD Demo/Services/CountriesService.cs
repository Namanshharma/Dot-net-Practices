﻿using Entities;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services;
public class CountriesService : ICountriesService
{
    private readonly CRUDDbContext _db;
    public CountriesService(CRUDDbContext db) { _db = db; }
    public async Task<CountryResponse> AddCountry(CountryAddRequest? countryAddRequest)
    {
        if (countryAddRequest == null) { throw new ArgumentNullException(nameof(countryAddRequest)); }
        if (countryAddRequest.CountryName == null) { throw new ArgumentNullException(nameof(countryAddRequest.CountryName)); }
        if (await _db.Countries.CountAsync(x => x.CountryName == countryAddRequest.CountryName) > 0) { throw new ArgumentException("Given Country name is already present"); }

        Country country = countryAddRequest.ToCountry();
        country.CountryId = Guid.NewGuid();
        _db.Countries.Add(country);
        await _db.SaveChangesAsync();

        return country.ToCountryResponse();
    }
    public async Task<List<CountryResponse>> GetAllCountries()
    {
        return await _db.Countries.Select(x => x.ToCountryResponse()).ToListAsync();
    }
    public async Task<CountryResponse>? GetCountryByCountryId(Guid? countryId)
    {
        if (countryId == null) { throw new ArgumentNullException(countryId.ToString() + "argument is null"); }
        Country? country = await _db.Countries.FirstOrDefaultAsync<Country>(x => x.CountryId == countryId);

        if (country == null) { return null; }
        return country?.ToCountryResponse();
    }
}
