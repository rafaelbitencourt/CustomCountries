using CustomCountries.API.Models;
using CustomCountries.API.Repository;
using HotChocolate;

namespace CustomCountries.API.GraphQl.Mutations
{
    public class CountryMutation
    {
        public Country saveCountry(Country country, 
            [Service] DataBaseContext _dbContext,
            [Service] CountryService countryService)
        {
            return countryService.saveCountry(country, _dbContext);
        }
    }
}
