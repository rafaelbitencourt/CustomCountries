using CustomCountries.API.Models;
using CustomCountries.API.Repositories;
using CustomCountries.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomCountries.Test
{
    public class RepCountryFake : IRepCountry
    {
        private readonly List<Country> _countries;
        public RepCountryFake()
        {
            _countries = new List<Country>()
            {
                new Country()
                {
                    NumericCode = "001",
                    Capital = "Brasília",
                    Area = 10000,
                    Population = 200000,
                    PopulationDensity = 500
                }
            };
        }

        public IQueryable<Country> GetCountries() =>
            _countries.AsQueryable();

       
        public Country GetCountryByNumericCode(string numericCode) =>
            _countries.Where(p => p.NumericCode == numericCode).FirstOrDefault();

        public void removeCountry(Country country) =>
            _countries.Remove(country);
        

        public void saveCountry(Country country) =>
            _countries.Add(country);
    }
}
