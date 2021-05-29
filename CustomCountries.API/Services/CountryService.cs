using CustomCountries.API.Models;
using HotChocolate;
using System;
using System.Linq;

namespace CustomCountries.API.Services
{
    public interface ICountryService
    {
        IQueryable<Country> GetCountries();
        Country saveCountry(Country country);
        Country removeCountry(Country country);
    }

    public class CountryService : ICountryService
    {
        private readonly DataBaseContext _dbContext;

        public CountryService(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Country> GetCountries() =>
            _dbContext.Countries;

        public Country saveCountry(Country country)
        {
            country.Validate();

            var countryRegistred = _dbContext.Countries.Find(country.NumericCode);
            if (countryRegistred != null)
                _dbContext.Countries.Remove(countryRegistred);

            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();

            return country;
        }

        public Country removeCountry(Country country)
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
