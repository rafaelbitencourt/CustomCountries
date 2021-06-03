using CustomCountries.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCountries.API.Repositories
{
    public interface IRepCountry
    {
        IQueryable<Country> GetCountries();
        Country GetCountryByNumericCode(string numericCode);
        void saveCountry(Country country);
        void removeCountry(Country country);
    }

    public class RepCountry : IRepCountry
    {
        private readonly DataBaseContext _dbContext;

        public RepCountry(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Country> GetCountries() =>
            _dbContext.Countries;

        public Country GetCountryByNumericCode(string numericCode) => 
            _dbContext.Countries.Find(numericCode);

        public void saveCountry(Country country)
        {
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
        }

        public void removeCountry(Country country)
        {
            _dbContext.Countries.Remove(country);
            _dbContext.SaveChanges();
        }
    }
}
