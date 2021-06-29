using CustomCountries.API.Models;
using CustomCountries.API.Repositories;
using HotChocolate;
using System;
using System.Linq;

namespace CustomCountries.API.Services
{
    public interface ICountryService
    {
        IQueryable<Country> GetCountries();
        Country SaveCountry(Country country);
        Country RemoveCountry(Country country);
    }

    public class CountryService : ICountryService
    {
        private readonly IRepCountry _repCountry;

        public CountryService(IRepCountry repCountry)
        {
            _repCountry = repCountry;
        }

        public IQueryable<Country> GetCountries() => _repCountry.GetCountries();

        public Country SaveCountry(Country country)
        {
            country.Validate();

            var countryRegistred = _repCountry.GetCountryByNumericCode(country.NumericCode);
            if (countryRegistred != null)
                _repCountry.removeCountry(countryRegistred);

            _repCountry.saveCountry(country);

            return country;
        }

        public Country RemoveCountry(Country country)
        {
            var countryRegistred = _repCountry.GetCountries().Where(p => p.NumericCode == country.NumericCode).FirstOrDefault();
            if (countryRegistred == null)
                throw new ArgumentException($"País com código {country.NumericCode} não encontrado.");

            _repCountry.removeCountry(countryRegistred);

            return country;
        }
    }
}
