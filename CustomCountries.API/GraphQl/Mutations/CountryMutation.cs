using CustomCountries.API.GraphQl.Models;
using CustomCountries.API.GraphQl.Types;
using CustomCountries.API.Models;
using HotChocolate;

namespace CustomCountries.API.GraphQl.Mutations
{
    public class CountryMutation
    {
        public Country setCountry(Country country, [Service] DataBaseContext _dbContext)
        {
            var countryRegistred = _dbContext.Countries.Find(country.NumericCode);
            if (countryRegistred != null)
                _dbContext.Countries.Remove(countryRegistred);
            
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();

            return country;
        }
    }
}
