using CustomCountries.API.Models;
using CustomCountries.API.Repository;
using HotChocolate;

namespace CustomCountries.API.GraphQl.Mutations
{
    public class CountryMutation
    {
        public Country saveCountry(Country country, 
            [Service] DataBaseContext _dbContext,
            [Service] ICountryService countryService) =>     
            countryService.saveCountry(country, _dbContext);

        public Country removeCountry(Country country,
            [Service] DataBaseContext _dbContext,
            [Service] ICountryService countryService) =>
            countryService.removeCountry(country, _dbContext);
    }
}
