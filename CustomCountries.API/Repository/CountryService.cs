using CustomCountries.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCountries.API.Repository
{
    public class CountryService
    {
        public IQueryable<Country> GetCountries(DataBaseContext _dbContext) =>
            _dbContext.Countries;

        public Country saveCountry(Country country, DataBaseContext _dbContext)
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
