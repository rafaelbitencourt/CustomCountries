using CustomCountries.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCountries.API.Repository
{
    public interface ICountryService
    {
        IQueryable<Country> GetCountries(DataBaseContext _dbContext);
        Country saveCountry(Country country, DataBaseContext _dbContext);
        Country removeCountry(Country country, DataBaseContext _dbContext);
    }

    public class CountryService : ICountryService
    {
        public IQueryable<Country> GetCountries(DataBaseContext _dbContext) =>
            _dbContext.Countries;

        public Country saveCountry(Country country, DataBaseContext _dbContext)
        {
            country.Validate();

            var countryRegistred = _dbContext.Countries.Find(country.NumericCode);
            if (countryRegistred != null)
                _dbContext.Countries.Remove(countryRegistred);

            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();

            return country;
        }

        public Country removeCountry(Country country, DataBaseContext _dbContext)
        {
            var countryRegistred = _dbContext.Countries.Find(country.NumericCode);
            if (countryRegistred == null)
                throw new Exception("País não encontrado.");

            _dbContext.Countries.Remove(countryRegistred);
            _dbContext.SaveChanges();

            return country;
        }
    }
}
