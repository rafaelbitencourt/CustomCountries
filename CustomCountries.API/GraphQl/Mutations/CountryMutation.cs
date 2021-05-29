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
            [Service] ICountryService countryService) =>     
            countryService.saveCountry(country);

        [Authorize]
        public Country removeCountry(Country country,
            [Service] ICountryService countryService) =>
            countryService.removeCountry(country);
    }
}
