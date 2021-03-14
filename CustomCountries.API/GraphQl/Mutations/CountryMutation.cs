using CustomCountries.API.Models;
using CustomCountries.API.Services;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;

namespace CustomCountries.API.GraphQl.Mutations
{
    public class CountryMutation
    {
        [Authorize]
        public Country saveCountry(Country country, 
            [Service] DataBaseContext _dbContext,
            [Service] ICountryService countryService) =>     
            countryService.saveCountry(country, _dbContext);

        [Authorize]
        public Country removeCountry(Country country,
            [Service] DataBaseContext _dbContext,
            [Service] ICountryService countryService) =>
            countryService.removeCountry(country, _dbContext);
    }
}
